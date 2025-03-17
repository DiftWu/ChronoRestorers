using UnityEngine;

public class QuestionBankLoader : MonoBehaviour
{
    [HideInInspector]
    public QuestionList questionList; // ���غ���������

    public TextAsset customJsonFile; // �Զ�������� JSON �ļ�

    void Awake()
    {
        LoadQuestionBank();
    }

    /// <summary>
    /// �� Resources �ļ����м������ JSON �ļ�������
    /// </summary>
    void LoadQuestionBank()
    {
        TextAsset jsonTextFile = customJsonFile != null ? customJsonFile : Resources.Load<TextAsset>("QuestionBank");
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
