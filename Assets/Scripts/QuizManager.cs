using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class QuizManager : MonoBehaviour
{
    [Header("������������")]
    public QuestionBankLoader questionBankLoader; 

    [Header("ÿ��֪ʶ�������ȡ����Ŀ����")]
    public int questionsPerKnowledgePoint = 1;  

    // �洢����ѡȡ����Ŀ�б�
    public List<Question> selectedQuestions = new List<Question>();

    void Start()
    {
        // ����Ƿ���ȷ��ֵ
        if (questionBankLoader == null)
        {
            Debug.LogError("QuizManager ��δ���� QuestionBankLoader ���ã�");
            return;
        }

        if (questionBankLoader.questionList == null || questionBankLoader.questionList.questions == null)
        {
            Debug.LogError("�����û�м��ص���Ŀ������ JSON �ļ���");
            return;
        }

        // ����֪ʶ�����Ŀ���з���
        var groupedQuestions = questionBankLoader.questionList.questions.GroupBy(q => q.knowledgePoint);

        // ���ÿ��֪ʶ����飬�����ȡָ����������Ŀ
        foreach (var group in groupedQuestions)
        {
            List<Question> groupList = group.ToList();

            // �Ը÷�����Ŀ�б����������ң�Fisher-Yates ϴ���㷨��
            ShuffleList(groupList);

            // ���㱾��ʵ�ʳ�ȡ����������ֹ�������㣩
            int countToSelect = Mathf.Min(questionsPerKnowledgePoint, groupList.Count);
            for (int i = 0; i < countToSelect; i++)
            {
                selectedQuestions.Add(groupList[i]);
            }
        }

        Debug.Log("����ѡȡ�� " + selectedQuestions.Count + " ����Ŀ��");

        // ���ԣ��ڿ���̨���ÿ��ѡ�е���Ŀ
        foreach (var q in selectedQuestions)
        {
            Debug.Log("��" + q.knowledgePoint + "�� " + q.questionText);
        }
    }

    /// <summary>
    /// ʹ�� Fisher-Yates �㷨������� List ��˳��
    /// </summary>
    void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
