using UnityEngine;
using UnityEngine.UI;

public class CameraCapture : MonoBehaviour
{
    private WebCamTexture webCamTexture;

    void Start()
    {
        // ��ʼ������ͷ
        webCamTexture = new WebCamTexture();

        // ��ȡ RawImage ����������ͷ����
        RawImage rawImage = GetComponent<RawImage>();
        if (rawImage != null)
        {
            rawImage.texture = webCamTexture;
        }

        // ��������ͷ
        webCamTexture.Play();
    }

    public Texture2D GetCurrentFrame()
    {
        // ��ȡ��ǰ֡
        Texture2D frame = new Texture2D(webCamTexture.width, webCamTexture.height);
        frame.SetPixels32(webCamTexture.GetPixels32());
        frame.Apply();
        return frame;
    }

    void OnDestroy()
    {
        // ֹͣ����ͷ
        webCamTexture.Stop();
    }
}
