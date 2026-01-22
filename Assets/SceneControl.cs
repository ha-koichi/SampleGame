using UnityEngine;
using UnityEngine.SceneManagement; // シーン切り替えに必要

public class SceneControl : MonoBehaviour
{
    public void Retry()
    {
        // 今開いているシーンの名前を取得して、もう一度読み込む
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        // もし時間を止めていた場合は、動くように戻す
        Time.timeScale = 1f;
    }
}