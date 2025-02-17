using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using System;
using System.Net.Http.Headers;

public class QuestionAI : MonoBehaviour
{
    // �Ի�����
    public Text dialogText;

    // ��������
    public InputField playerInputField;

    // ���Ͱ�ť
    public Button sendButton;

    // HttpClient ʵ��
    private static readonly HttpClient httpClient = new HttpClient();

    // API Key
    private string apiKey;

    // Start is called before the first frame update
    void Start()
    {
        // ��ȡAPI Key
        apiKey = "sk-7a4ff79eeb054defadda915cf1afce19";

        dialogText.text = "NPC:����xxx�������������������ʡ�";

        if (string.IsNullOrEmpty(apiKey))
        {
            Debug.LogError("API Key δ���á���ȷ���������� 'DASHSCOPE_API_KEY' �����á�");
            return;
        }

        // �󶨷��Ͱ�ť�ĵ���¼�
        sendButton.onClick.AddListener(OnSendButtonClicked);
    }

    private async void OnSendButtonClicked()
    {
        string playerInput = playerInputField.text;
        if (string.IsNullOrEmpty(playerInput))
        {
            Debug.Log("���벻��Ϊ�ա�");
            return;
        }

        // ��������
        playerInputField.text = "";

        // ��ʾ��ҵ����루���ǾɶԻ���
        dialogText.text = $"���: {playerInput}\n";

        // ��������ģ��API
        string npcResponse = await SendChatRequest(playerInput);

        // ��ʾNPC����Ӧ�����ǾɶԻ���
        dialogText.text += $"NPC: {npcResponse}\n";
    }

    // ������������
    private async Task<string> SendChatRequest(string userMessage)
    {
        string url = "https://dashscope.aliyuncs.com/compatible-mode/v1/chat/completions";

        string jsonContent = @$"{{
            ""model"": ""qwen-plus"",
            ""messages"": [
                {{
                    ""role"": ""system"",
                    ""content"": ""You are a helpful assistant.""
                }},
                {{
                    ""role"": ""user"", 
                    ""content"": ""{userMessage}""
                }}
            ]
        }}";

        using (var content = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
        {
            // ��������ͷ
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // �������󲢻�ȡ��Ӧ
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            // ������Ӧ
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                // ����JSON��Ӧ
                var responseData = JsonUtility.FromJson<ChatResponse>(result);
                if (responseData.choices != null && responseData.choices.Length > 0)
                {
                    return responseData.choices[0].message.content;
                }
                else
                {
                    return "δ�յ���Ч�Ļظ���";
                }
            }
            else
            {
                return $"����ʧ��: {response.StatusCode}";
            }
        }
    }

    // �������ڽ���JSON��Ӧ����
    [System.Serializable]
    private class ChatResponse
    {
        public Choice[] choices;
    }

    [System.Serializable]
    private class Choice
    {
        public Message message;
    }

    [System.Serializable]
    private class Message
    {
        public string content;
    }
}
