using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class QuizManager : MonoBehaviour
{
    [Header("题库加载器引用")]
    public QuestionBankLoader questionBankLoader; 

    [Header("每个知识点随机抽取的题目数量")]
    public int questionsPerKnowledgePoint = 1;  

    // 存储最终选取的题目列表
    public List<Question> selectedQuestions = new List<Question>();

    void Start()
    {
        // 检查是否正确赋值
        if (questionBankLoader == null)
        {
            Debug.LogError("QuizManager 中未设置 QuestionBankLoader 引用！");
            return;
        }

        if (questionBankLoader.questionList == null || questionBankLoader.questionList.questions == null)
        {
            Debug.LogError("题库中没有加载到题目，请检查 JSON 文件！");
            return;
        }

        // 按照知识点对题目进行分组
        var groupedQuestions = questionBankLoader.questionList.questions.GroupBy(q => q.knowledgePoint);

        // 针对每个知识点分组，随机抽取指定数量的题目
        foreach (var group in groupedQuestions)
        {
            List<Question> groupList = group.ToList();

            // 对该分组题目列表进行随机打乱（Fisher-Yates 洗牌算法）
            ShuffleList(groupList);

            // 计算本组实际抽取的题数（防止数量不足）
            int countToSelect = Mathf.Min(questionsPerKnowledgePoint, groupList.Count);
            for (int i = 0; i < countToSelect; i++)
            {
                selectedQuestions.Add(groupList[i]);
            }
        }

        Debug.Log("本次选取了 " + selectedQuestions.Count + " 道题目。");

        // 测试：在控制台输出每道选中的题目
        foreach (var q in selectedQuestions)
        {
            Debug.Log("【" + q.knowledgePoint + "】 " + q.questionText);
        }
    }

    /// <summary>
    /// 使用 Fisher-Yates 算法随机打乱 List 的顺序
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
