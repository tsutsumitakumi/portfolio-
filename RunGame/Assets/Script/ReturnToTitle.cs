using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    public string titleSceneName = "Title"; // �^�C�g����ʂ̃V�[����

    public void ReturnToTitleScreen()
    {
        // �^�C�g����ʂɖ߂鏈��
        SceneManager.LoadScene(titleSceneName);
    }
}
