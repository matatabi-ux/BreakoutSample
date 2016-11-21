using UnityEngine;

/// <summary>
/// ブロック
/// </summary>
public class Block : MonoBehaviour
{
    /// <summary>
    /// 色マテリアル
    /// </summary>
    [SerializeField]
    private Material[] colors;

    /// <summary>
    /// レンダラ
    /// </summary>
    private Renderer materialRenderer;

    /// <summary>
    /// 衝突カウンタ
    /// </summary>
    private int count = 0;

    /// <summary>
    /// 初期処理
    /// </summary>
    public void Awake()
    {
        this.count = 0;
        this.materialRenderer = this.GetComponent<Renderer>();
    }

    /// <summary>
    /// 衝突イベントハンドラ
    /// </summary>
    /// <param name="collision">衝突情報</param>
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            this.count++;

            // ブロックの色を変える
            if (this.colors.Length > this.count)
            {
                this.materialRenderer.material = colors[count];
                return;
            }

            Destroy(this.gameObject);
        }
    }
}
