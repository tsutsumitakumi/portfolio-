using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public string startSceneName = "Start"; // �^�C�g����ʂ̃V�[����

    public void ReturnToTitleScreen()
    {
        // �^�C�g����ʂɖ߂鏈��
        SceneManager.LoadScene(startSceneName);
    }
}