using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 敵の設計図
    public float interval = 2.0f;  // 何秒おきに出すか
    float timer;

    void Update()
    {
        timer += Time.deltaTime; // 時間をカウント

        if (timer >= interval)
        {
            // 敵を生み出す（場所はスポナーと同じ位置、回転はなし）
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            
            timer = 0; // タイマーをリセット
        }
    }
}