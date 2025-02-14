using UnityEngine;

public class QuestionBankLoader : MonoBehaviour
{
    [HideInInspector]
    public QuestionList questionList; // 加载后的题库数据

    void Awake()
    {
        LoadQuestionBank();
    }

    /// <summary>
    /// 从 Resources 文件夹中加载题库 JSON 文件并解析
    /// </summary>
    void LoadQuestionBank()
    {
        // 从 Resources 加载 JSON 文件
        TextAsset jsonTextFile = Resources.Load<TextAsset>("QuestionBank");
        if (jsonTextFile != null)
        {
            // 利用 JsonUtility 反序列化 JSON 数据到 QuestionList 对象中
            questionList = JsonUtility.FromJson<QuestionList>(jsonTextFile.text);
            Debug.Log("成功加载题库，共 " + questionList.questions.Length + " 道题。");
        }
        else
        {
            Debug.LogError("未找到 QuestionBank.json 文件，请确认文件放在 Resources 文件夹中。");
        }
    }
}
