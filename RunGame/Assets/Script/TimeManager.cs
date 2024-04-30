using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    // 経過時間を保存するメソッド
    public static void SaveElapsedTime()
    {
        //経過時間を保存
        PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);
        // 変更を保存
        PlayerPrefs.Save();
    }
}
