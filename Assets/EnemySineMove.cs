using UnityEngine;

public class EnemySineMove : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 左への速さ
    public float amplitude = 2.0f; // 揺れ幅（上下にどれくらい動くか）
    public float frequency = 2.0f; // 揺れる速さ
    
    float startY;

    void Start()
    {
        // 出現した時の高さを基準にする
        startY = transform.position.y;
    }

    void Update()
    {
        // 1. 左へ移動
        float nextX = transform.position.x - (moveSpeed * Time.deltaTime);

        // 2. 上下の揺れを計算 (サイン関数)
        float nextY = startY + Mathf.Sin(Time.time * frequency) * amplitude;

        // 3. 位置を更新
        transform.position = new Vector3(nextX, nextY, 0);

        // 画面外に出たら消す
        if (transform.position.x < -10) Destroy(gameObject);
    }

    // 敵側のスクリプトに追記
    void OnTriggerEnter2D(Collider2D other)
    {
        // 当たった相手のタグ（または名前）が Bullet だったら
        if (other.gameObject.name.Contains("Bullet"))
        {
            Destroy(other.gameObject); // 弾を消す
            Destroy(gameObject);       // 自分（敵）を消す
        }
    }
}