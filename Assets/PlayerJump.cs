using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5.0f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // マウスの左クリック、または画面タップで反応
        if (Input.GetMouseButtonDown(0))
        {
            // 上方向に瞬間的に速度をつける
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    // 敵（Trigger設定のもの）に触れた瞬間に呼ばれる
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Enemy" || other.gameObject.name == "Enemy(Clone)")
        {
            Debug.Log("ゲームオーバー！");
            // プレイヤーを消す
            Destroy(gameObject);
        }
    }
}