using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuizUIManager : MonoBehaviour
{
    [Header("��������������QuizManager��")]
    public QuizManager quizManager;  // ���� Inspector ������֮ǰ�� QuizManager ����

    [Header("��Ŀ�ı���ʾ")]
    public Text questionText;        // ������ʾ��Ŀ����

    [Header("ѡ���� UI ���")]
    public GameObject choicePanel;   // ����ѡ���ⰴť�����
    public Button[] choiceButtons;   // Ԥ�����ú���������4����ť��
    public Text[] choiceButtonTexts; // ��Ӧ��ť�ϵ��ı����

    [Header("�ж��� UI ���")]
    public GameObject judgePanel;    // �����ж��ⰴť�����
    public Button trueButton;        // ��True����ť
    public Button falseButton;       // ��False����ť

    [Header("����� UI ���")]
    public GameObject fillPanel;     // �����������ύ��ť�����
    public InputField fillInputField;// ��������
    public Button submitButton;      // ������ύ��ť

    private List<Question> questions;  // ���� QuizManager �������ѡȡ����Ŀ�б�
    private int currentQuestionIndex = 0;

    void Start()
    {
        // ��� QuizManager �����Ƿ���ȷ
        if (quizManager == null)
        {
            Debug.LogError("QuizUIManager��δ���� QuizManager ���ã�");
            return;
        }

        // ��ȡ��Ŀ�б�
        questions = quizManager.selectedQuestions;
        Debug.Log(quizManager.selectedQuestions.Count);
        if (questions == null || questions.Count == 0)
        {
            questionText.text = "�����û����Ŀ�����飡";
            return;
        }

        // Ϊ������ť�󶨵���¼������� Inspector �а󶨣��˴����������ʾ����
        // ѡ���ⰴť��
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            int index = i; // �ֲ��������� i
            choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(index));
        }

        // �ж��ⰴť��
        trueButton.onClick.AddListener(() => OnJudgeSelected(true));
        falseButton.onClick.AddListener(() => OnJudgeSelected(false));

        // ������ύ��ť��
        submitButton.onClick.AddListener(OnFillSubmitted);

        // ��ʾ��һ��
        ShowQuestion(questions[currentQuestionIndex]);
    }

    /// <summary>
    /// ������Ŀ������ʾ��Ӧ UI ���
    /// </summary>
    void ShowQuestion(Question question)
    {
        // �������������
        choicePanel.SetActive(false);
        judgePanel.SetActive(false);
        fillPanel.SetActive(false);

        // ��ʾ��Ŀ�ı�
        questionText.text = question.questionText;

        // �������ʹ���Ӧ���
        switch (question.type.ToLower())
        {
            case "choice":
                if (question.options != null && question.options.Length > 0)
                {
                    choicePanel.SetActive(true);
                    // ������ť����ʾѡ���ı�
                    for (int i = 0; i < choiceButtons.Length; i++)
                    {
                        if (i < question.options.Length)
                        {
                            choiceButtons[i].gameObject.SetActive(true);
                            choiceButtonTexts[i].text = question.options[i];
                        }
                        else
                        {
                            // ���ѡ���������㣬���ض���İ�ť
                            choiceButtons[i].gameObject.SetActive(false);
                        }
                    }
                }
                break;
            case "judge":
                judgePanel.SetActive(true);
                // �˴���ť�ı����ڱ༭��������Ϊ True �� False
                break;
            case "fill":
                fillPanel.SetActive(true);
                fillInputField.text = ""; // ��������
                break;
            default:
                Debug.LogError("δ֪���ͣ�" + question.type);
                break;
        }
    }

    /// <summary>
    /// ѡ���ⰴť����¼�������ѡ��������
    /// </summary>
    /// <param name="optionIndex">��ť����</param>
    public void OnChoiceSelected(int optionIndex)
    {
        Question currentQuestion = questions[currentQuestionIndex];
        if (currentQuestion.options == null || optionIndex >= currentQuestion.options.Length)
        {
            Debug.LogError("ѡ����ѡ����������");
            return;
        }
        string selectedAnswer = currentQuestion.options[optionIndex];
        CheckAnswer(selectedAnswer, currentQuestion);
    }

    /// <summary>
    /// �ж��ⰴť����¼������벼��ֵ��
    /// </summary>
    /// <param name="answer">�û�ѡ��Ĵ�</param>
    public void OnJudgeSelected(bool answer)
    {
        Question currentQuestion = questions[currentQuestionIndex];
        string selectedAnswer = answer.ToString(); // ת��Ϊ�ַ��� "True" �� "False"
        CheckAnswer(selectedAnswer, currentQuestion);
    }

    /// <summary>
    /// ������ύ��ť����¼�
    /// </summary>
    public void OnFillSubmitted()
    {
        Question currentQuestion = questions[currentQuestionIndex];
        string userAnswer = fillInputField.text.Trim();
        CheckAnswer(userAnswer, currentQuestion);
    }

    /// <summary>
    /// ����û����Ƿ���ȷ�����л���һ��
    /// </summary>
    /// <param name="userAnswer">�û���</param>
    /// <param name="currentQuestion">��ǰ��Ŀ</param>
    void CheckAnswer(string userAnswer, Question currentQuestion)
    {
        // �˴����Դ�Сд�Ƚϴ𰸣��ɸ�����Ҫ��չ��
        bool isCorrect = userAnswer.Equals(currentQuestion.correctAnswer, System.StringComparison.OrdinalIgnoreCase);

        // �����������ڴ˴�������ʾ��ͳ�Ʒ���
        Debug.Log("��Ŀ��" + currentQuestion.questionText);
        Debug.Log("���Ĵ𰸣�" + userAnswer + "����ȷ�𰸣�" + currentQuestion.correctAnswer + "�������" + (isCorrect ? "��ȷ" : "����"));

        // �л�����һ��
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Count)
        {
            ShowQuestion(questions[currentQuestionIndex]);
        }
        else
        {
            // ������ϣ���ʾ������Ϣ���������������
            questionText.text = "������ϣ�";
            choicePanel.SetActive(false);
            judgePanel.SetActive(false);
            fillPanel.SetActive(false);

            // �ӳ�һ���ر� questionText
            StartCoroutine(HideQuestionTextAfterDelay(1f));
        }
    }

    IEnumerator HideQuestionTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        questionText.text = "";
    }
}
