using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // ゲームオーバー画面に遷移する処理
        SceneManager.LoadScene("GameOver");
    }
}
