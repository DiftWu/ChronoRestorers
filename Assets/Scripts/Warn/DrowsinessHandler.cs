using UnityEngine;
using UnityEngine.UI;
using Unity.Barracuda;

public class DrowsinessHandler : MonoBehaviour
{
    public CameraCapture cameraCapture;
    public EmotionDetection emotionDetection;
    public GameObject alertPanel;
    public Text alertText;

    private float drowsyCounter = 0f;
    private const float drowsyThreshold = 5f;
    private string[] labels = { "����", "���", "����", "����", "����", "����", "����" };

    private float detectionTimer = 0f; // ��ʱ��
    private const float detectionInterval = 0.5f; // ���������λ���룩

    private RenderTexture renderTexture; // Ԥ�����RenderTexture
    private Texture2D resizedTexture; // Ԥ�����Texture2D

    void Start()
    {
        // ��ʼ����Դ
        renderTexture = new RenderTexture(48, 48, 0, RenderTextureFormat.ARGB32);
        resizedTexture = new Texture2D(48, 48, TextureFormat.RGB24, false);

        // ��ʼ���������
        alertPanel.SetActive(false);
    }

    void Update()
    {
        // ���¼���ʱ��
        detectionTimer += Time.deltaTime;
        if (detectionTimer < detectionInterval)
        {
            return; // ���δ�����ʱ�䣬����������߼�
        }

        detectionTimer = 0f; // ���ü�ʱ��

        // ��ȡ����ͷ�ĵ�ǰ֡
        Texture2D frame = cameraCapture.GetCurrentFrame();

        if (frame == null)
        {
            Debug.LogWarning("Camera frame is null!");
            return;
        }

        // Ԥ����֡
        Tensor inputTensor = PreprocessFrame(frame);

        // Ԥ������
        float[] predictions = emotionDetection.Predict(inputTensor);

        // �ͷ� Tensor ������Դй¶
        inputTensor.Dispose();

        if (predictions == null || predictions.Length == 0)
        {
            Debug.LogWarning("Model prediction is empty or null!");
            return;
        }

        // ���ģ��������������ڱ�ǩ����ȡǰ 7 ��
        if (predictions.Length != labels.Length)
        {
            float[] truncatedPredictions = new float[labels.Length];
            System.Array.Copy(predictions, truncatedPredictions, labels.Length);
            predictions = truncatedPredictions;
        }

        // ���ģ��Ԥ����
        //Debug.Log("Model Predictions: " + string.Join(", ", predictions));

        // ��ȡ���ֵ������
        int maxIndex = System.Array.IndexOf(predictions, Mathf.Max(predictions));
        string emotion = labels[maxIndex];

        // �����ǰ��������
        Debug.Log($"Detected Emotion: {emotion}");

        // �������״̬
        if (emotion == "����" || emotion == "����")
        {
            drowsyCounter += Time.deltaTime;
            if (drowsyCounter >= drowsyThreshold)
            {
                ShowAlert("��⵽��������������");
                Debug.Log("Drowsiness Detected: TRUE");
            }
        }
        else
        {
            drowsyCounter = 0f;
            HideAlert();
            Debug.Log("Drowsiness Detected: FALSE");
        }
    }

    void ShowAlert(string message)
    {
        alertPanel.SetActive(true);
        alertText.text = message;
    }

    void HideAlert()
    {
        alertPanel.SetActive(false);
    }

    Tensor PreprocessFrame(Texture2D frame)
    {
        // ��ԭʼ������Ƶ� RenderTexture ��
        RenderTexture.active = renderTexture;
        Graphics.Blit(frame, renderTexture);

        // �� RenderTexture ��ȡ�������ݵ� Texture2D
        resizedTexture.ReadPixels(new Rect(0, 0, 48, 48), 0, 0);
        resizedTexture.Apply();

        // ��ͼ��ת��Ϊ�Ҷ�ֵ����
        Color32[] pixels = resizedTexture.GetPixels32();
        float[] grayscale = new float[48 * 48];
        for (int i = 0; i < pixels.Length; i++)
        {
            grayscale[i] = (pixels[i].r * 0.2989f + pixels[i].g * 0.5870f + pixels[i].b * 0.1140f) / 255.0f;
        }

        // ���� Tensor
        return new Tensor(1, 48, 48, 1, grayscale);
    }

    void OnDestroy()
    {
        // �ͷ���Դ
        if (renderTexture != null)
        {
            renderTexture.Release();
        }

        if (resizedTexture != null)
        {
            Destroy(resizedTexture);
        }
    }
}
