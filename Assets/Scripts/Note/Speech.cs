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
    [HideInInspector]
    public AudioSource audioSource;

    private AudioClip recordedAudioClip;

    public InputField resultInputField;
    public Text recordButtonText;

    private Stopwatch stopwatch;
    private bool recording = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        recordButtonText.text = " ";

        // �����������ϳ�
        SendTextToSpeechMsg("��ð�������Ѷ���������֣�", auidoClip =>
        {
            audioSource.clip = auidoClip;
            audioSource.Play();
        });
    }

    #region ¼����ʶ��

    public void OnButtonClick()
    {
        if (!recording)
        {
            recording = true;
            recordButtonText.text = "¼����...";
            StartRecord();
            DataManager.Instance.playerData.voiceuse++;
        }
        else
        {
            recording = false;
            EndRecord((text, _) =>
            {
                stopwatch.Stop();
                UnityEngine.Debug.Log($"Ѷ������ת�ı��ɹ����ı�Ϊ��{text}");
                recordButtonText.text = " ";
                resultInputField.text = text;
                UnityEngine.Debug.Log($"ʶ�𻨷�ʱ��: {stopwatch.ElapsedMilliseconds} ����");
            });
        }
    }

    public void StartRecord()
    {
        recordedAudioClip = Microphone.Start(null, true, 40, 16000);
    }

    public void EndRecord(Action<string, AudioClip> speechToTextCallback)
    {
        if (speechToTextCallback == null) return;

        Microphone.End(null);
        recordedAudioClip = TrimSilence(recordedAudioClip, 0.01f);

        stopwatch = new Stopwatch();
        stopwatch.Start();

        SendSpeechToTextMsg(recordedAudioClip, text =>
        {
            speechToTextCallback.Invoke(text, recordedAudioClip);
        });
    }

    public void SendSpeechToTextMsg(AudioClip audioClip, Action<string> callback)
    {
        byte[] bytes = AudioClipToBytes(audioClip);

        JObject jObject = new JObject
        {
            ["data"] = Convert.ToBase64String(bytes)
        };

        StartCoroutine(SendSpeechToTextMsgCoroutine(jObject, callback));
    }

    private IEnumerator SendSpeechToTextMsgCoroutine(JObject message, Action<string> callback)
    {
        Task<string> resultJson = VoiceInput.Instance.SpeechToText(message);
        yield return new WaitUntil(() => resultJson.IsCompleted);

        if (resultJson.Status == TaskStatus.RanToCompletion)
        {
            JObject obj = JObject.Parse(resultJson.Result);
            string text = obj["text"]?.ToString() ?? string.Empty;
            callback.Invoke(text);
        }
        else
        {
            UnityEngine.Debug.LogError("Ѷ������ת�ı���Ϣ����ʧ��");
            callback.Invoke(string.Empty);
        }
    }

    #endregion

    #region �ı�ת�����������棩

    public void SendTextToSpeechMsg(string text, Action<AudioClip> callback)
    {
        JObject jObject = new JObject
        {
            ["text"] = text,
            ["voice"] = "xiaoyan"
        };

        StartCoroutine(SendTextToSpeechMsgCoroutine(jObject, callback));
    }

    private IEnumerator SendTextToSpeechMsgCoroutine(JObject message, Action<AudioClip> callback)
    {
        Task<string> resultJson = VoiceInput.Instance.TextToSpeech(message);
        yield return new WaitUntil(() => resultJson.IsCompleted);

        if (resultJson.Status == TaskStatus.RanToCompletion)
        {
            JObject obj = JObject.Parse(resultJson.Result);

            string audioBase64 = obj["data"]?["audio"]?.ToString();

            if (string.IsNullOrEmpty(audioBase64))
            {
                UnityEngine.Debug.LogError("Ѷ�ɷ��ص� audio �ֶ�Ϊ�գ�");
                callback.Invoke(null);
                yield break;
            }

            float[] audioData = BytesToFloat(Convert.FromBase64String(audioBase64));

            if (audioData.Length == 0)
            {
                UnityEngine.Debug.LogError($"Ѷ���ı�ת����ʧ�ܣ�������Ϣ��{resultJson.Result}");
                callback.Invoke(null);
            }
            else
            {
                AudioClip audioClip = AudioClip.Create("SynthesizedAudio", audioData.Length, 1, 16000, false);
                audioClip.SetData(audioData, 0);
                callback.Invoke(audioClip);
            }
        }
        else
        {
            UnityEngine.Debug.LogError($"Ѷ���ı�ת������Ϣ����ʧ�ܣ�������Ϣ��{resultJson.Result}");
            callback.Invoke(null);
        }
    }

    #endregion

    #region ���ߺ���

    private static byte[] AudioClipToBytes(AudioClip audioClip)
    {
        float[] data = new float[audioClip.samples];
        audioClip.GetData(data, 0);

        int rescaleFactor = 32767;
        byte[] outData = new byte[data.Length * 2];

        for (int i = 0; i < data.Length; i++)
        {
            short tempShort = (short)(data[i] * rescaleFactor);
            byte[] tempData = BitConverter.GetBytes(tempShort);
            outData[i * 2] = tempData[0];
            outData[i * 2 + 1] = tempData[1];
        }

        return outData;
    }

    private static float[] BytesToFloat(byte[] byteArray)
    {
        float[] soundData = new float[byteArray.Length / 2];
        for (int i = 0; i < soundData.Length; i++)
        {
            soundData[i] = BytesToSingle(byteArray[i * 2], byteArray[i * 2 + 1]);
        }
        return soundData;
    }

    private static float BytesToSingle(byte firstByte, byte secondByte)
    {
        short s;
        if (BitConverter.IsLittleEndian)
            s = (short)((secondByte << 8) | firstByte);
        else
            s = (short)((firstByte << 8) | secondByte);

        return s / 32768.0f;
    }

    private static AudioClip TrimSilence(AudioClip clip, float min)
    {
        var samples = new float[clip.samples];
        clip.GetData(samples, 0);
        return TrimSilence(new List<float>(samples), min, clip.channels, clip.frequency);
    }

    private static AudioClip TrimSilence(List<float> samples, float min, int channels, int hz, bool _3D = false)
    {
        int i;

        for (i = 0; i < samples.Count; i++)
        {
            if (Mathf.Abs(samples[i]) > min) break;
        }

        i = Mathf.Max(i - (int)(hz * 0.1f), 0);
        samples.RemoveRange(0, i);

        for (i = samples.Count - 1; i > 0; i--)
        {
            if (Mathf.Abs(samples[i]) > min) break;
        }

        i = Mathf.Min(i + (int)(hz * 0.1f), samples.Count - 1);
        samples.RemoveRange(i, samples.Count - i);

        if (samples.Count == 0)
        {
            UnityEngine.Debug.LogWarning("�޳����AudioClip����Ϊ0");
            return null;
        }

        var clip = AudioClip.Create("TrimmedClip", samples.Count, channels, hz, _3D);
        clip.SetData(samples.ToArray(), 0);

        return clip;
    }

    #endregion
}
