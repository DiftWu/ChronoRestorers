using UnityEngine;

public class CameraAspectRatio : MonoBehaviour
{
    public float targetAspect = 16f / 9f;  // 目标纵横比，比如16:9

    void Start()
    {
        // 获取当前屏幕纵横比
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // 计算比例差异
        float scaleHeight = windowAspect / targetAspect;

        // 获取当前摄像机
        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1.0f)
        {
            // 如果当前窗口比目标更宽，需要在高度上加黑边
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            // 如果窗口更窄，需要在宽度上加黑边
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}

