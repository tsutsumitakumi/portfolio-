using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    // �o�ߎ��Ԃ�ۑ����郁�\�b�h
    public static void SaveElapsedTime()
    {
        //�o�ߎ��Ԃ�ۑ�
        PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);
        // �ύX��ۑ�
        PlayerPrefs.Save();
    }
}
