using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject groundEnemyPrefab; // 地上型の設計図
    public GameObject airEnemyPrefab;    // 空中型の設計図
    public float interval = 2.0f;  // 何秒おきに出すか
    float timer;

    void Update()
    {
        timer += Time.deltaTime; // 時間をカウント

        if (timer >= interval)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                SpawnEnemy();
                timer = 0;
            }
        }
    }

    void SpawnEnemy()
    {
        // 0か1をランダムに決める (0なら地上、1なら空中)
        int randomType = Random.Range(0, 2);

        if (randomType == 0)
        {
            // --- 地上型の出現 ---
            // Y座標を地面の高さ（例：-3.5）に固定
            Vector3 spawnPos = new Vector3(transform.position.x, -3.5f, 0);
            Instantiate(groundEnemyPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            // --- 空中型の出現 ---
            // Y座標を高い範囲（例：0 ～ 3.0）でランダムにする
            Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(0f, 3.0f), 0);
            Instantiate(airEnemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}