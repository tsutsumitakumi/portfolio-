using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public string startSceneName = "Start"; // タイトル画面のシーン名

    public void ReturnToTitleScreen()
    {
        // タイトル画面に戻る処理
        SceneManager.LoadScene(startSceneName);
    }
}