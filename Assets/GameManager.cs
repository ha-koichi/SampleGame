using UnityEngine;
using TMPro; // UIを扱うために必要

public class GameManager : MonoBehaviour
{
    public float timeToClear = 20.0f; // 20秒でクリア
    public TextMeshProUGUI clearText; // 画面の文字
    
    float timer;
    bool isCleared = false;

    void Update()
    {
        if (isCleared) return; // クリア済みなら何もしない

        timer += Time.deltaTime;

        if (timer >= timeToClear)
        {
            ClearGame();
        }
    }

    void ClearGame()
    {
        isCleared = true;
        clearText.gameObject.SetActive(true); // 文字を表示
        
        // 敵の生成を止める
        GetComponent<Spawner>().enabled = false;
        
        Debug.Log("クリア！");
    }
}