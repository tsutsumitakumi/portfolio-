using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public float deathYPosition = -4f; // �Q�[���I�[�o�[�ƂȂ�Y���W��臒l

    void Update()
    {
        if (transform.position.y <= deathYPosition)
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
