using UnityEngine;

public class QuestionBankLoader : MonoBehaviour
{
    [HideInInspector]
    public QuestionList questionList; // ���غ���������

    void Awake()
    {
        LoadQuestionBank();
    }

    /// <summary>
    /// �� Resources �ļ����м������ JSON �ļ�������
    /// </summary>
    void LoadQuestionBank()
    {
        // �� Resources ���� JSON �ļ�
        TextAsset jsonTextFile = Resources.Load<TextAsset>("QuestionBank");
        if (jsonTextFile != null)
        {
            // ���� JsonUtility �����л� JSON ���ݵ� QuestionList ������
            questionList = JsonUtility.FromJson<QuestionList>(jsonTextFile.text);
            Debug.Log("�ɹ�������⣬�� " + questionList.questions.Length + " ���⡣");
        }
        else
        {
            Debug.LogError("δ�ҵ� QuestionBank.json �ļ�����ȷ���ļ����� Resources �ļ����С�");
        }
    }
}
