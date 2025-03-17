using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuizUIManager : MonoBehaviour
{
    [Header("引用题库管理器（QuizManager）")]
    public QuizManager quizManager;  // 请在 Inspector 中拖入之前的 QuizManager 对象

    [Header("题目文本显示")]
    public Text questionText;        // 用于显示题目内容

    [Header("选择题 UI 面板")]
    public GameObject choicePanel;   // 包含选择题按钮的面板
    public Button[] choiceButtons;   // 预先设置好数量（如4个按钮）
    public Text[] choiceButtonTexts; // 对应按钮上的文本组件

    [Header("判断题 UI 面板")]
    public GameObject judgePanel;    // 包含判断题按钮的面板
    public Button trueButton;        // “True”按钮
    public Button falseButton;       // “False”按钮

    [Header("填空题 UI 面板")]
    public GameObject fillPanel;     // 包含输入框和提交按钮的面板
    public InputField fillInputField;// 填空输入框
    public Button submitButton;      // 填空题提交按钮

    private List<Question> questions;  // 来自 QuizManager 中已随机选取的题目列表
    private int currentQuestionIndex = 0;

    void Start()
    {
        // 检查 QuizManager 引用是否正确
        if (quizManager == null)
        {
            Debug.LogError("QuizUIManager：未设置 QuizManager 引用！");
            return;
        }

        // 获取题目列表
        questions = quizManager.selectedQuestions;
        Debug.Log(quizManager.selectedQuestions.Count);
        if (questions == null || questions.Count == 0)
        {
            questionText.text = "题库中没有题目，请检查！";
            return;
        }

        // 为各个按钮绑定点击事件（可在 Inspector 中绑定，此处给出代码绑定示例）
        // 选择题按钮绑定
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            int index = i; // 局部变量保存 i
            choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(index));
        }

        // 判断题按钮绑定
        trueButton.onClick.AddListener(() => OnJudgeSelected(true));
        falseButton.onClick.AddListener(() => OnJudgeSelected(false));

        // 填空题提交按钮绑定
        submitButton.onClick.AddListener(OnFillSubmitted);

        // 显示第一题
        ShowQuestion(questions[currentQuestionIndex]);
    }

    /// <summary>
    /// 根据题目类型显示对应 UI 面板
    /// </summary>
    void ShowQuestion(Question question)
    {
        // 先隐藏所有面板
        choicePanel.SetActive(false);
        judgePanel.SetActive(false);
        fillPanel.SetActive(false);

        // 显示题目文本
        questionText.text = question.questionText;

        // 根据题型打开相应面板
        switch (question.type.ToLower())
        {
            case "choice":
                if (question.options != null && question.options.Length > 0)
                {
                    choicePanel.SetActive(true);
                    // 遍历按钮，显示选项文本
                    for (int i = 0; i < choiceButtons.Length; i++)
                    {
                        if (i < question.options.Length)
                        {
                            choiceButtons[i].gameObject.SetActive(true);
                            choiceButtonTexts[i].text = question.options[i];
                        }
                        else
                        {
                            // 如果选项数量不足，隐藏多余的按钮
                            choiceButtons[i].gameObject.SetActive(false);
                        }
                    }
                }
                break;
            case "judge":
                judgePanel.SetActive(true);
                // 此处按钮文本已在编辑器中设置为 True 和 False
                break;
            case "fill":
                fillPanel.SetActive(true);
                fillInputField.text = ""; // 清空输入框
                break;
            default:
                Debug.LogError("未知题型：" + question.type);
                break;
        }
    }

    /// <summary>
    /// 选择题按钮点击事件（传入选项索引）
    /// </summary>
    /// <param name="optionIndex">按钮索引</param>
    public void OnChoiceSelected(int optionIndex)
    {
        Question currentQuestion = questions[currentQuestionIndex];
        if (currentQuestion.options == null || optionIndex >= currentQuestion.options.Length)
        {
            Debug.LogError("选择题选项索引错误！");
            return;
        }
        string selectedAnswer = currentQuestion.options[optionIndex];
        CheckAnswer(selectedAnswer, currentQuestion);
    }

    /// <summary>
    /// 判断题按钮点击事件（传入布尔值）
    /// </summary>
    /// <param name="answer">用户选择的答案</param>
    public void OnJudgeSelected(bool answer)
    {
        Question currentQuestion = questions[currentQuestionIndex];
        string selectedAnswer = answer.ToString(); // 转换为字符串 "True" 或 "False"
        CheckAnswer(selectedAnswer, currentQuestion);
    }

    /// <summary>
    /// 填空题提交按钮点击事件
    /// </summary>
    public void OnFillSubmitted()
    {
        Question currentQuestion = questions[currentQuestionIndex];
        string userAnswer = fillInputField.text.Trim();
        CheckAnswer(userAnswer, currentQuestion);
    }

    /// <summary>
    /// 检查用户答案是否正确，并切换下一题
    /// </summary>
    /// <param name="userAnswer">用户答案</param>
    /// <param name="currentQuestion">当前题目</param>
    void CheckAnswer(string userAnswer, Question currentQuestion)
    {
        // 此处忽略大小写比较答案（可根据需要扩展）
        bool isCorrect = userAnswer.Equals(currentQuestion.correctAnswer, System.StringComparison.OrdinalIgnoreCase);

        // 输出结果，可在此处弹出提示或统计分数
        Debug.Log("题目：" + currentQuestion.questionText);
        Debug.Log("您的答案：" + userAnswer + "，正确答案：" + currentQuestion.correctAnswer + "，结果：" + (isCorrect ? "正确" : "错误"));

        // 切换到下一题
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Count)
        {
            ShowQuestion(questions[currentQuestionIndex]);
        }
        else
        {
            // 答题完毕，提示结束信息，并隐藏所有面板
            questionText.text = "答题完毕！";
            choicePanel.SetActive(false);
            judgePanel.SetActive(false);
            fillPanel.SetActive(false);

            // 延迟一秒后关闭 questionText
            StartCoroutine(HideQuestionTextAfterDelay(1f));
        }
    }

    IEnumerator HideQuestionTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        questionText.text = "";
    }
}
