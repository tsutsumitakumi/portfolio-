using UnityEngine;
using UnityEngine.UI;

public class ElapsedTimeDisplay : MonoBehaviour
{
    public Text elapsedTimeText;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;

        string minutes = ((int)elapsedTime / 60).ToString();
        string seconds = (elapsedTime % 60).ToString("f2");

        // Textコンポーネントに表示する文字
        elapsedTimeText.text = "Time: " + minutes + ":" + seconds;
    }
}
