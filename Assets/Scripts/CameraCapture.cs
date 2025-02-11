using UnityEngine;
using UnityEngine.UI;

public class CameraCapture : MonoBehaviour
{
    private WebCamTexture webCamTexture;

    void Start()
    {
        // 初始化摄像头
        webCamTexture = new WebCamTexture();

        // 获取 RawImage 并设置摄像头纹理
        RawImage rawImage = GetComponent<RawImage>();
        if (rawImage != null)
        {
            rawImage.texture = webCamTexture;
        }

        // 启动摄像头
        webCamTexture.Play();
    }

    public Texture2D GetCurrentFrame()
    {
        // 获取当前帧
        Texture2D frame = new Texture2D(webCamTexture.width, webCamTexture.height);
        frame.SetPixels32(webCamTexture.GetPixels32());
        frame.Apply();
        return frame;
    }

    void OnDestroy()
    {
        // 停止摄像头
        webCamTexture.Stop();
    }
}
