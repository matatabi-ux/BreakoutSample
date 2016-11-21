using UnityEngine;

/// <summary>
/// 失敗判定壁
/// </summary>
public class MissWall : MonoBehaviour
{
    /// <summary>
    /// メインシーン
    /// </summary>
    [SerializeField]
    private MainScene scene;

    /// <summary>
    /// 衝突イベントハンドラ
    /// </summary>
    /// <param name="collision">衝突情報</param>
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            this.scene.Miss();
        }
    }
}
