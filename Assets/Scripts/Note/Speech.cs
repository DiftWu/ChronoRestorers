using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public class Speech : MonoBehaviour
{
    /// <summary>��ǰ�����AudioSource���<summary>
    [HideInInspector]
    public AudioSource audioSource;

    /// <summary>�û�¼�����Ƶ</summary>
    private AudioClip recordedAudioClip;

    // ���һ��InputField����
    public InputField resultInputField;
    public Text recordButtonText; // ������ʾ��ť�ϵ��ı�
    private Stopwatch stopwatch; // ���һ����ʱ��

    private void Start()
    {
        //��ȡAudioSource���
        audioSource = GetComponent<AudioSource>();

        // ��ʼ����ť�ı�
        recordButtonText.text = " ";


        //������[!��Ҫ����]���˲���Ϊ�첽��ɣ���Ҫһ��ʱ������ִ��=>{}��Ĵ��롣
        SendTextToSpeechMsg("��ð�������Ѷ���������֣�", auidoClip =>
        {
            audioSource.clip = auidoClip;
            audioSource.Play();
        });
    }

    #region ����ת�ı� ������

    private bool recording = false;

    /// <summary>
    /// �� ¼����ť ����ʱ����
    /// </summary>
    public void OnButtonClick()
    {
        if (recording == false)
        {
            recording = true;
            recordButtonText.text = "¼����..."; // ���°�ť�ı�Ϊ��¼����...��

            //��ʼ¼��[!��Ҫ����]
            StartRecord();
            DataManager.Instance.playerData.voiceuse++; // ��¼ʹ����������Ĵ���
        }
        else
        {
            recording = false;
            //����¼��[!��Ҫ����]
            EndRecord((text, _) =>
            {
                stopwatch.Stop(); // ֹͣ��ʱ
                UnityEngine.Debug.Log($"Ѷ������ת�ı��ɹ����ı�Ϊ��{text}");
                recordButtonText.text = " "; // ���°�ť�ı�Ϊ��
                resultInputField.text = text; // ��ʾʶ����ı�
                UnityEngine.Debug.Log($"ʶ�𻨷ѵ�ʱ��: {stopwatch.ElapsedMilliseconds} ����"); // ��ӡʶ��ʱ��
            });
        }
    }

    #endregion

    #region Ѷ���ı�ת����

    /// <summary>
    /// ��XunFei������Ϣ�����ȴ��䷵��
    /// </summary>
    /// <param name="text">�ı�</param>
    /// <param name="chatGLMCallback">�ص�����</param>
    public void SendTextToSpeechMsg(string text, Action<AudioClip> callback)
    {
        //����Json�ַ���
        JObject jObject = new JObject();
        jObject["text"] = text;
        //���Ը��ĳ�����Ҫ������������������Ѷ�ɿ���̨�в鿴
        jObject["voice"] = "xiaoyan";
        //������Ϣ
        StartCoroutine(SendTextToSpeechMsgCoroutine(jObject, callback));
    }

    /// <summary>
    /// ��XunFei������Ϣ��Э��
    /// </summary>
    /// <param name="message"></param>
    /// <param name="callback">�յ���Ϣ��Ļص�����</param>
    /// <returns></returns>
    private IEnumerator SendTextToSpeechMsgCoroutine(JObject message, Action<AudioClip> callback)
    {
        //��������
        Task<string> resultJson = VoiceInput.Instance.TextToSpeech(message);
        //�ȴ�������Ϣ
        yield return new WaitUntil(() => resultJson.IsCompleted);

        //�ɹ����յ���Ϣ
        if (resultJson.Status == TaskStatus.RanToCompletion)
        {
            //����Json�ַ���
            JObject obj = JObject.Parse(resultJson.Result);
            //��ȡ��Ƶ���ݣ�base64�ַ�����
            string text = obj["data"].ToString();
            //������Ƶ����
            float[] audioData = BytesToFloat(Convert.FromBase64String(text));

            if (audioData.Length == 0)//Ѷ���ı�ת����ʧ��
            {
                UnityEngine.Debug.Log($"Ѷ���ı�ת����ʧ�ܣ��������������ı�Ϊ�ջ���ȷ��������������Ϊ0��������Ϣ��{resultJson.Result}");
                //ʧ�ܻص�
                callback.Invoke(null);
            }
            //����AudioClip
            AudioClip audioClip = AudioClip.Create("SynthesizedAudio", audioData.Length, 1, 16000, false);
            audioClip.SetData(audioData, 0);

            //Debug.Log("Ѷ���ı�ת�����ɹ�");
            //�ص�
            callback.Invoke(audioClip);
        }
        else
        {
            UnityEngine.Debug.Log($"Ѷ���ı�ת������Ϣ����ʧ�ܣ�������Ϣ��{resultJson.Result}");
            //ʧ�ܻص�
            callback.Invoke(null);
        }

    }



    /// <summary>
    /// byte[]����ת��ΪAudioClip�ɶ�ȡ��float[]����
    /// </summary>
    /// <param name="byteArray"></param>
    /// <returns></returns>
    private static float[] BytesToFloat(byte[] byteArray)
    {
        float[] sounddata = new float[byteArray.Length / 2];
        for (int i = 0; i < sounddata.Length; i++)
        {
            sounddata[i] = bytesToFloat(byteArray[i * 2], byteArray[i * 2 + 1]);
        }
        return sounddata;
    }
    private static float bytesToFloat(byte firstByte, byte secondByte)
    {
        // convert two bytes to one short (little endian)
        //С�˺ʹ��˳��Ҫ����
        short s;
        if (BitConverter.IsLittleEndian)
            s = (short)((secondByte << 8) | firstByte);
        else
            s = (short)((firstByte << 8) | secondByte);
        // convert to range from -1 to (just below) 1
        return s / 32768.0F;
    }


    #endregion


    #region Ѷ������ת�ı�


    /// <summary>
    /// ��ʼ¼��
    /// </summary>
    public void StartRecord()
    {
        //��ʼ¼��Ƶ���40�룩
        recordedAudioClip = Microphone.Start(null, true, 40, 16000); 
    }

    /// <summary>
    /// ����¼��
    /// </summary>
    /// <param name="speechToTextCallback">����ת�ı��ɹ���Ļص�����</param>
    public void EndRecord(Action<string, AudioClip> speechToTextCallback)
    {
        //ȡ����¼��
        if (speechToTextCallback == null) return;

        //¼������
        Microphone.End(null);

        //ȥ����û��������Ƭ��
        recordedAudioClip = TrimSilence(recordedAudioClip, 0.01f);

        // ��¼��������������ʱ������ʼ�����ϴ���ʶ���ʱ��
        stopwatch = new Stopwatch();
        stopwatch.Start();

        //������Ϣ
        SendSpeechToTextMsg(recordedAudioClip, text =>
        {
            //�ص�
            speechToTextCallback.Invoke(text, recordedAudioClip);
        });
    }


    /// <summary>
    /// ��XunFei������Ϣ�����ȴ��䷵��
    /// </summary>
    /// <param name="strContent">��Ƶ����</param>
    /// <param name="chatGLMCallback">�ص�����</param>
    public void SendSpeechToTextMsg(AudioClip audioClip, Action<string> callback)
    {
        byte[] bytes = AudioClipToBytes(audioClip);
        //����Json�ַ���
        JObject jObject = new JObject();
        jObject["data"] = Convert.ToBase64String(bytes);
        //������Ϣ
        StartCoroutine(SendSpeechToTextMsgCoroutine(jObject, callback));
    }

    /// <summary>
    /// ��XunFei������Ϣ��Э��
    /// </summary>
    /// <param name="message"></param>
    /// <param name="callback">�յ���Ϣ��Ļص�����</param>
    /// <returns></returns>
    private IEnumerator SendSpeechToTextMsgCoroutine(JObject message, Action<string> callback)
    {
        //��������
        Task<string> resultJson = VoiceInput.Instance.SpeechToText(message);
        //�ȴ�������Ϣ
        yield return new WaitUntil(() => resultJson.IsCompleted);

        //�ɹ����յ���Ϣ
        if (resultJson.Status == TaskStatus.RanToCompletion)
        {
            //����Json�ַ���
            JObject obj = JObject.Parse(resultJson.Result);
            //��ȡ���ƶ�
            string text = obj["text"].ToString();
            //Debug.Log("Ѷ������ת�ı���" + text);
            //�ص�
            callback.Invoke(text);
        }
        else
        {
            UnityEngine.Debug.Log("Ѷ������ת�ı���Ϣ����ʧ��");
            //ʧ�ܻص�
            callback.Invoke(string.Empty);
        }

    }


    /// <summary>
    /// ��AudioClipת����byte[]����
    /// </summary>
    /// <param name="audioClip">Unity�е���Ƶ����</param>
    /// <returns>byte[]����</returns>
    private static byte[] AudioClipToBytes(AudioClip audioClip)
    {
        float[] data = new float[audioClip.samples];
        audioClip.GetData(data, 0);
        int rescaleFactor = 32767; //to convert float to Int16
        byte[] outData = new byte[data.Length * 2];
        for (int i = 0; i < data.Length; i++)
        {
            short temshort = (short)(data[i] * rescaleFactor);
            byte[] temdata = BitConverter.GetBytes(temshort);
            outData[i * 2] = temdata[0];
            outData[i * 2 + 1] = temdata[1];
        }
        return outData;
    }

    /// <summary>
    /// �޳���Ĭ����
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="min"></param>
    /// <returns></returns>
    private static AudioClip TrimSilence(AudioClip clip, float min)
    {
        var samples = new float[clip.samples];
        clip.GetData(samples, 0);

        return TrimSilence(new List<float>(samples), min, clip.channels, clip.frequency);
    }

    private static AudioClip TrimSilence(List<float> samples, float min, int channels, int hz, bool _3D = false)
    {
        int origSamples = samples.Count;

        int i;

        for (i = 0; i < samples.Count; i++)
        {
            if (Mathf.Abs(samples[i]) > min)
            {
                break;
            }
        }

        i -= (int)(hz * .1f);
        i = Mathf.Max(i, 0);

        // Remove start silence
        samples.RemoveRange(0, i);

        for (i = samples.Count - 1; i > 0; i--)
        {
            if (Mathf.Abs(samples[i]) > min)
            {
                break;
            }
        }

        // Add some tail onto it
        i += (int)(hz * .1f);
        i = Mathf.Min(i, samples.Count - 1);
        samples.RemoveRange(i, samples.Count - i);


        if (samples.Count == 0)
        {
            UnityEngine.Debug.Log("�޳����AudioClip����Ϊ0");
            return null;
        }

        var clip = AudioClip.Create("TempClip", samples.Count, channels, hz, _3D);
        clip.SetData(samples.ToArray(), 0);

        return clip;
    }

    #endregion
}
