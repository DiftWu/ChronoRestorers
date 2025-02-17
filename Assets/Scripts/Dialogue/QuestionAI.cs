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
    // 对话内容
    public Text dialogText;

    // 玩家输入框
    public InputField playerInputField;

    // 发送按钮
    public Button sendButton;

    // HttpClient 实例
    private static readonly HttpClient httpClient = new HttpClient();

    // API Key
    private string apiKey;

    // Start is called before the first frame update
    void Start()
    {
        // 获取API Key
        apiKey = "sk-7a4ff79eeb054defadda915cf1afce19";

        dialogText.text = "NPC:我是xxx，您可以任意向我提问。";

        if (string.IsNullOrEmpty(apiKey))
        {
            Debug.LogError("API Key 未设置。请确保环境变量 'DASHSCOPE_API_KEY' 已设置。");
            return;
        }

        // 绑定发送按钮的点击事件
        sendButton.onClick.AddListener(OnSendButtonClicked);
    }

    private async void OnSendButtonClicked()
    {
        string playerInput = playerInputField.text;
        if (string.IsNullOrEmpty(playerInput))
        {
            Debug.Log("输入不能为空。");
            return;
        }

        // 清空输入框
        playerInputField.text = "";

        // 显示玩家的输入（覆盖旧对话）
        dialogText.text = $"玩家: {playerInput}\n";

        // 发送请求到模型API
        string npcResponse = await SendChatRequest(playerInput);

        // 显示NPC的响应（覆盖旧对话）
        dialogText.text += $"NPC: {npcResponse}\n";
    }

    // 发送聊天请求
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
            // 设置请求头
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // 发送请求并获取响应
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            // 处理响应
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                // 解析JSON响应
                var responseData = JsonUtility.FromJson<ChatResponse>(result);
                if (responseData.choices != null && responseData.choices.Length > 0)
                {
                    return responseData.choices[0].message.content;
                }
                else
                {
                    return "未收到有效的回复。";
                }
            }
            else
            {
                return $"请求失败: {response.StatusCode}";
            }
        }
    }

    // 定义用于解析JSON响应的类
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
