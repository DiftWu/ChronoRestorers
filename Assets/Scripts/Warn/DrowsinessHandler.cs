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
    private string[] labels = { "生气", "厌恶", "害怕", "开心", "悲伤", "惊讶", "正常" };

    private float detectionTimer = 0f; // 定时器
    private const float detectionInterval = 0.5f; // 检测间隔（单位：秒）

    private RenderTexture renderTexture; // 预分配的RenderTexture
    private Texture2D resizedTexture; // 预分配的Texture2D

    void Start()
    {
        // 初始化资源
        renderTexture = new RenderTexture(48, 48, 0, RenderTextureFormat.ARGB32);
        resizedTexture = new Texture2D(48, 48, TextureFormat.RGB24, false);

        // 初始化警告面板
        alertPanel.SetActive(false);
    }

    void Update()
    {
        // 更新检测计时器
        detectionTimer += Time.deltaTime;
        if (detectionTimer < detectionInterval)
        {
            return; // 如果未到检测时间，则跳过检测逻辑
        }

        detectionTimer = 0f; // 重置计时器

        // 获取摄像头的当前帧
        Texture2D frame = cameraCapture.GetCurrentFrame();

        if (frame == null)
        {
            Debug.LogWarning("Camera frame is null!");
            return;
        }

        // 预处理帧
        Tensor inputTensor = PreprocessFrame(frame);

        // 预测情绪
        float[] predictions = emotionDetection.Predict(inputTensor);

        // 释放 Tensor 避免资源泄露
        inputTensor.Dispose();

        if (predictions == null || predictions.Length == 0)
        {
            Debug.LogWarning("Model prediction is empty or null!");
            return;
        }

        // 如果模型输出的数量多于标签，截取前 7 项
        if (predictions.Length != labels.Length)
        {
            float[] truncatedPredictions = new float[labels.Length];
            System.Array.Copy(predictions, truncatedPredictions, labels.Length);
            predictions = truncatedPredictions;
        }

        // 输出模型预测结果
        //Debug.Log("Model Predictions: " + string.Join(", ", predictions));

        // 获取最大值的索引
        int maxIndex = System.Array.IndexOf(predictions, Mathf.Max(predictions));
        string emotion = labels[maxIndex];

        // 输出当前检测的情绪
        Debug.Log($"Detected Emotion: {emotion}");

        // 检测走神状态
        if (emotion == "悲伤" || emotion == "正常")
        {
            drowsyCounter += Time.deltaTime;
            if (drowsyCounter >= drowsyThreshold)
            {
                ShowAlert("检测到您可能正在走神！");
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
        // 将原始纹理绘制到 RenderTexture 上
        RenderTexture.active = renderTexture;
        Graphics.Blit(frame, renderTexture);

        // 从 RenderTexture 读取像素数据到 Texture2D
        resizedTexture.ReadPixels(new Rect(0, 0, 48, 48), 0, 0);
        resizedTexture.Apply();

        // 将图像转换为灰度值数组
        Color32[] pixels = resizedTexture.GetPixels32();
        float[] grayscale = new float[48 * 48];
        for (int i = 0; i < pixels.Length; i++)
        {
            grayscale[i] = (pixels[i].r * 0.2989f + pixels[i].g * 0.5870f + pixels[i].b * 0.1140f) / 255.0f;
        }

        // 创建 Tensor
        return new Tensor(1, 48, 48, 1, grayscale);
    }

    void OnDestroy()
    {
        // 释放资源
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
