using BreakoutSample.UwpPlugin;
using UnityEngine;

/// <summary>
/// メインシーン
/// </summary>
public class MainScene : MonoBehaviour
{
    /// <summary>
    /// ラケット
    /// </summary>
    [SerializeField]
    private GameObject racket;

    /// <summary>
    /// ボール
    /// </summary>
    [SerializeField]
    private GameObject ball;

    /// <summary>
    /// プレイ中フラグ
    /// </summary>
    private bool isPlaying = false;

    /// <summary>
    /// 入力管理クラス
    /// </summary>
    public InputManager InputManager { get; private set; }

    /// <summary>
    /// 初期処理
    /// </summary>
    public void Awake()
    {
        this.InputManager = InputManager.Instance;
        UnityEngine.WSA.Application.InvokeOnUIThread(() =>
        {
            this.InputManager.Initialize();
        }, false);
        this.isPlaying = false;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public void Update()
    {
        if (!this.isPlaying)
        {
            this.ball.transform.position = new Vector3(this.racket.transform.position.x, 0, this.racket.transform.position.z + 0.25f);

            // 開始前に Surfave Dial がクリックされたらボールに力を与えて動かし始める
            if (Input.GetButtonDown("Submit") || this.InputManager.IsButtonClicked)
            {
                this.ball.SendMessage("AddFource");
                this.isPlaying = true;

                // クリックフラグは降ろしておく
                this.InputManager.IsButtonClicked = false;
            }
        }
    }

    /// <summary>
    /// ミスイベントハンドラ
    /// </summary>
    public void Miss()
    {
        this.ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.InputManager.IsButtonClicked = false;
        this.isPlaying = false;
    }
}
