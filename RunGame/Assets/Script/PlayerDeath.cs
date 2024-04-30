using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public float deathYPosition = -4f; // ゲームオーバーとなるY座標の閾値

    void Update()
    {
        if (transform.position.y <= deathYPosition)
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
