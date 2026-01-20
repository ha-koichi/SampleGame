using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    void Update()
    {
        // 毎フレーム、左方向に移動させる
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // 画面の左端（-10あたり）まで行ったら自分を消す
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}