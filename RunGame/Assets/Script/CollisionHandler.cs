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
        // �Q�[���I�[�o�[��ʂɑJ�ڂ��鏈��
        SceneManager.LoadScene("GameOver");
    }
}
