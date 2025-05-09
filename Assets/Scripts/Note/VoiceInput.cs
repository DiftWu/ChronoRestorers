using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Linq;

public class VoiceInput : MonoBehaviour
{
    public static VoiceInput Instance;

    private const string STTURL = "wss://iat-api.xfyun.cn/v2/iat";
    private const string TTSURL = "wss://tts-api.xfyun.cn/v2/tts";
    private const string APPID = "d75296e3";
    private const string APISecret = "ODljYzU3YzgyYmNjZDA1YjFiMGNlZmRi"; 
    private const string APIKey = "98f60de36371ea80002053e0644598f7";

    private ClientWebSocket webSocket;


    private void Awake()
    {
        //��ʼ������
        Instance = this;
    }


    public async Task<string> SpeechToText(JObject request)
    {
        //��ȡ��������
        byte[] bytes = Convert.FromBase64String(request["data"].ToString());
        //��������
        await Connect(STTURL);
        //������Ϣ
        await STTSendMessage(bytes);
        //������Ϣ
        string text = await STTReceiveMessage();
        //�رս���
        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);

        //��������Json����
        JObject response = new JObject();
        response["text"] = text;
        //��ӦPost����
        return response.ToString();
    }


    public async Task<string> TextToSpeech(JObject request)
    {
        //��ȡ��������
        string text = request["text"].ToString();
        string voice = request["voice"].ToString();
        //��������
        await Connect(TTSURL);
        //������Ϣ
        await TTSSendMessage(text, voice);
        //������Ϣ
        string base64String = await TTSReceiveMessage();
        //�رս���
        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);

        //��������Json����
        JObject response = new JObject();
        response["data"] = base64String;
        //��ӦPost����
        return response.ToString();

    }


    /// <summary>
    /// ����Ѷ��API
    /// </summary>
    /// <returns></returns>
    private async Task Connect(string url)
    {
        //�½�ClientWebSocket
        webSocket = new ClientWebSocket();
        //ʹ��WebSocket����Ѷ�ɵķ���
        await webSocket.ConnectAsync(new Uri(GetUrl(url)), CancellationToken.None);
        //await Console.Out.WriteLineAsync("Ѷ��WebSocket���ӳɹ�");
    }


    /// <summary>
    /// Ѷ������ת�ı���������Ϣ
    /// </summary>
    private async Task STTSendMessage(byte[] bytes)
    {
        //״ֵ̬ 0�����1֡��1�����м�֡��2�����β֡
        int status;
        int remainLength = bytes.Length;
        //�ֶη�����Ϣ
        while (remainLength > 0)
        {
            byte[] currBytes;
            if (remainLength > 1280)
            {
                status = remainLength == bytes.Length ? 0 : 1;
                currBytes = new byte[1280];
                Array.Copy(bytes, bytes.Length - remainLength, currBytes, 0, 1280);
                remainLength -= 1280;
            }
            else
            {
                status = 2;
                currBytes = new byte[remainLength];
                Array.Copy(bytes, bytes.Length - remainLength, currBytes, 0, remainLength);
                remainLength = 0;
            }

            JObject jsonData = STTCreateJsonData(status, currBytes);
            byte[] messageBytes = Encoding.UTF8.GetBytes(jsonData.ToString());
            await webSocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
            //�ȴ�30ms
            await Task.Delay(20);
            //Console.WriteLine("������Ϣ��"+jsonData.ToString());
        }
        //Console.WriteLine("���ݷ������");
    }

    /// <summary>
    /// Ѷ������ת�ı���������Ҫ���͵�Json����
    /// </summary>
    /// <param name="status"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    private JObject STTCreateJsonData(int status, byte[] bytes)
    {
        JObject requestObj = new JObject();
        JObject commonJson = new JObject();
        commonJson["app_id"] = APPID;
        requestObj["common"] = commonJson;
        JObject bussinessJson = new JObject();
        bussinessJson["language"] = "zh_cn";
        bussinessJson["domain"] = "iat";
        bussinessJson["accent"] = "mandarin";
        bussinessJson["dwa"] = "wpgs";
        requestObj["business"] = bussinessJson;
        JObject dataJson = new JObject();
        dataJson["status"] = status;
        dataJson["format"] = "audio/L16;rate=16000";
        dataJson["encoding"] = "raw";
        dataJson["audio"] = Convert.ToBase64String(bytes);
        requestObj["data"] = dataJson;
        return requestObj;
    }

    /// <summary>
    /// Ѷ������ת�ı���������Ϣ
    /// </summary>
    /// <returns></returns>
    private async Task<string> STTReceiveMessage()
    {
        //webSocket.
        //״ֵ̬
        int status = 0;
        string finalText = string.Empty;
        while (status != 2)
        {
            byte[] buffer = new byte[8 * 1024];
            WebSocketReceiveResult webSocketReceiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, webSocketReceiveResult.Count);
            //await Console.Out.WriteLineAsync("receivedMessage��" + receivedMessage);
            finalText += STTParseMessage(receivedMessage, out status);
        }
        Debug.Log("Ѷ������ת�ı���" + finalText);
        return finalText;

    }
    /// <summary>
    /// Ѷ������ת�ı��������յ���Json��Ϣ
    /// </summary>
    /// <param name="message"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    private string STTParseMessage(string message, out int status)
    {
        JObject jObject = JObject.Parse(message);

        int code = (int)jObject["code"];
        if (code != 0)//ʧ��
        {
            string errMsg = jObject["message"].ToString();
            Debug.LogError("Ѷ������ת�ı�������Json��Ϣʧ�ܣ�������Ϣ��" + errMsg);
        }
        else//�ɹ�
        {
            string result = string.Empty;
            foreach (JObject i in jObject["data"]["result"]["ws"])
            {
                foreach (JObject w in i["cw"])
                {
                    result += w["w"].ToString();
                }
            }
            //״ֵ̬
            //ʶ�����Ƿ������ʶ��
            //0��ʶ��ĵ�һ����
            //1��ʶ���м���
            //2��ʶ�����һ����
            status = (int)jObject["data"]["status"];
            return result;
        }
        status = -1;
        return string.Empty;
    }


    /// <summary>
    /// Ѷ���ı�ת������������Ϣ
    /// </summary>
    private async Task TTSSendMessage(string text, string voice)
    {
        //����������Ҫ��Json�ַ���
        JObject jsonData = TTSCreateJsonData(text, voice);
        byte[] messageBytes = Encoding.UTF8.GetBytes(jsonData.ToString());
        //������Ϣ
        await webSocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
    }


    /// <summary>
    /// Ѷ���ı�ת������������Ҫ���͵�Json����
    /// </summary>
    /// <param name="status"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    private JObject TTSCreateJsonData(string text, string voice)
    {
        JObject requestObj = new JObject();
        JObject commonJson = new JObject();
        commonJson["app_id"] = APPID;
        requestObj["common"] = commonJson;
        JObject bussinessJson = new JObject();
        bussinessJson["aue"] = "raw";
        bussinessJson["vcn"] = voice;
        bussinessJson["speed"] = 50;
        bussinessJson["volume"] = 50;
        bussinessJson["pitch"] = 50;
        bussinessJson["tte"] = "UTF8";
        requestObj["business"] = bussinessJson;
        JObject dataJson = new JObject();
        dataJson["status"] = 2;
        dataJson["text"] = Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        requestObj["data"] = dataJson;
        return requestObj;
    }


    /// <summary>
    /// Ѷ���ı�ת������������Ϣ
    /// </summary>
    /// <returns>�����ϳɺ��base64�ַ���</returns>
    private async Task<string> TTSReceiveMessage()
    {
        //webSocket.
        //״ֵ̬
        int status = 0;
        List<byte> bytes = new List<byte>();
        while (status != 2)
        {
            bool receivedCompleted = false;
            string receivedMessage = string.Empty;
            while (!receivedCompleted)
            {
                byte[] buffer = new byte[8 * 1024];
                WebSocketReceiveResult webSocketReceiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                receivedMessage += Encoding.UTF8.GetString(buffer, 0, webSocketReceiveResult.Count);
                receivedCompleted = webSocketReceiveResult.Count != 8 * 1024;
            }
            //await Console.Out.WriteLineAsync("receivedMessage��" + receivedMessage);
            bytes.AddRange(Convert.FromBase64String(TTSParseMessage(receivedMessage, out status)).ToList());
            //finalAudioBase64String += TTSParseMessage(receivedMessage, out status).TrimEnd('=');
        }
        string finalAudioBase64String = Convert.ToBase64String(bytes.ToArray());
        //await Console.Out.WriteLineAsync("Ѷ������ת�ı���" + finalAudioBase64String);
        return finalAudioBase64String;


    }

    /// <summary>
    /// Ѷ���ı�ת�����������յ���Json��Ϣ
    /// </summary>
    /// <param name="message"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    private string TTSParseMessage(string message, out int status)
    {
        Debug.Log("Raw JSON response: " + message);

        JObject jObject = JObject.Parse(message);
        if (jObject["message"].ToString() == "success")
        {
            if (jObject["data"] != null)
            {
                if (jObject["data"]["audio"] != null)
                {
                    if ((int)jObject["data"]["status"] == 2)
                    {
                        status = 2;
                    }
                    else
                    {
                        status = 1;
                    }
                    return jObject["data"]["audio"].ToString();

                }
            }
            Debug.LogError("ERROR:TTSParseMessageʧ�ܣ�dataΪ��");
            status = 0;
            return string.Empty;
        }
        else
        {
            Debug.LogError("ERROR:TTSParseMessageʧ�ܣ�������Ϣ��" + jObject["message"].ToString());
            status = 0;
            return string.Empty;
        }

    }



    #region ����URL
    private string GetUrl(string url)
    {
        Uri uri = new Uri(url);
        //�ٷ��ĵ�Ҫ��ʱ�������UTC+0��GMTʱ����RFC1123��ʽ(Thu, 01 Aug 2019 01:53:21 GMT)��
        string date = DateTime.Now.ToString("r");
        //��װ���ɼ�Ȩ
        string authorization = ComposeAuthUrl(uri, date);
        //�������ռ�Ȩ
        string uriStr = $"{uri}?authorization={authorization}&date={date}&host={uri.Host}";
        //�������ɺ��Url
        return uriStr;
    }
    /// <summary>
    /// ��װ���ɼ�Ȩ
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="date"></param>
    /// <returns>���ձ����ļ�Ȩ</returns>
    private string ComposeAuthUrl(Uri uri, string date)
    {
        string signature; //���ձ�����ǩ��
        string authorization_origin; //ԭʼ��Ȩ
                                     //ԭʼǩ��
        string signature_origin = string.Format("host: " + uri.Host + "\ndate: " + date + "\nGET " + uri.AbsolutePath + " HTTP/1.1");
        //ʹ��hmac-sha256�㷨���ܺ��signature
        string signature_sha = HmacSHA256(signature_origin, APISecret); //ʹ��hmac - sha256�㷨���apiSecret��signature_originǩ��
        signature = signature_sha;
        string auth = "api_key=\"{0}\", algorithm=\"{1}\", headers=\"{2}\", signature=\"{3}\"";
        authorization_origin = string.Format(auth, APIKey, "hmac-sha256", "host date request-line", signature); //�������ܣ�APIKey,�����㷨����headers�ǲ���ǩ���Ĳ���(�ò������ǹ̶���"host date request-line")�����ɵ�ǩ��
        return ToBase64String(authorization_origin);
    }

    /// <summary>
    /// �����㷨HmacSHA256  
    /// </summary>
    /// <param name="secret"></param>
    /// <param name="signKey"></param>
    /// <returns></returns>
    private static string HmacSHA256(string secret, string signKey)
    {
        string signRet = string.Empty;
        using (HMACSHA256 mac = new HMACSHA256(Encoding.UTF8.GetBytes(signKey)))
        {
            byte[] hash = mac.ComputeHash(Encoding.UTF8.GetBytes(secret));
            signRet = Convert.ToBase64String(hash);
        }
        return signRet;
    }

    /// <summary>
    /// UTF�ַ���ת��Base64�ַ���
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static string ToBase64String(string value)
    {
        if (value == null || value == "")
        {
            return "";
        }
        byte[] bytes = Encoding.UTF8.GetBytes(value);
        return Convert.ToBase64String(bytes);
    }

    #endregion
}

