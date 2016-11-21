using UnityEngine;

/// <summary>
/// ボール
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    /// <summary>
    /// 速度係数
    /// </summary>
    private const float Speed = 5.0f;

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
    /// 落下開始
    /// </summary>
    public void AddFource()
    {
        this.rigid.AddForce((transform.forward + transform.right) * Speed, ForceMode.VelocityChange);
    }
}
