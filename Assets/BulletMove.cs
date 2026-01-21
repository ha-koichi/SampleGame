using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 10.0f;

    void Start()
    {
        // 右方向に発射！
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * speed;
        // 3秒後に自動で消える（画面外対策）
        Destroy(gameObject, 3.0f);
    }
}