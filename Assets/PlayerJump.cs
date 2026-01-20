using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5.0f;
    public float moveSpeed = 5.0f; // 横移動のスピードを追加
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

        // --- ジャンプの処理（既存） ---
        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        // --- 横移動の処理（追加） ---
        // 左右の入力（矢印キーやA/Dキー）を取得 (-1.0 ～ 1.0)
        float xInput = Input.GetAxis("Horizontal");

        // 現在の縦の速度（y）は維持したまま、横の速度（x）だけ書き換える
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
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