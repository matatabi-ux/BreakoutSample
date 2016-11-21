using UnityEngine;

/// <summary>
/// ラケット
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Racket : MonoBehaviour
{
    /// <summary>
    /// メインシーン
    /// </summary>
    [SerializeField]
    private MainScene scene;

    /// <summary>
    /// 加速度係数
    /// </summary>
    private const float Accel = 1000.0f;

    /// <summary>
    /// 物理計算コンポーネント
    /// </summary>
    private Rigidbody rigid;

    /// <summary>
    /// 初期処理
    /// </summary>
    public void Awake()
    {
        this.rigid = this.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 定期更新
    /// </summary>
    public void FixedUpdate()
    {
        this.rigid.AddForce(transform.right * (Input.GetAxisRaw("Horizontal") + this.scene.InputManager.AxisXDelta) * Accel, ForceMode.Impulse);
        this.scene.InputManager.AxisXDelta = 0f;
    }
}
