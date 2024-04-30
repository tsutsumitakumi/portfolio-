using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    public string titleSceneName = "Title"; // タイトル画面のシーン名

    public void ReturnToTitleScreen()
    {
        // タイトル画面に戻る処理
        SceneManager.LoadScene(titleSceneName);
    }
}
