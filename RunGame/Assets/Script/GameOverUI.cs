using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text elapsedTimeText;

    void Start()
    {
        float elapsedTime = PlayerPrefs.GetFloat("ElapsedTime", 0f);
        string minutes = ((int)elapsedTime / 60).ToString();
        string seconds = (elapsedTime % 60).ToString("f2");
        elapsedTimeText.text = "Time: " + minutes + ":" + seconds;
        TimeManager.SaveElapsedTime(); // 経過時間をリセット
    }
}
