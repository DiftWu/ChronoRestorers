using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    public Camera mainCamera;   // 摄像机
    public SpriteRenderer spriteRenderer;  // 背景图片的 SpriteRenderer

    void Start()
    {
        AdjustBackgroundSize();
    }

    void AdjustBackgroundSize()
    {
        // 获取图片的宽高比
        float spriteHeight = spriteRenderer.sprite.bounds.size.y;
        float spriteWidth = spriteRenderer.sprite.bounds.size.x;

        // 获取摄像机的视野高度
        float cameraHeight = mainCamera.orthographicSize * 2f;

        // 计算摄像机视野的宽度
        float cameraWidth = cameraHeight * Screen.width / Screen.height;

        // 计算缩放比例
        Vector2 scale = new Vector2(cameraWidth / spriteWidth, cameraHeight / spriteHeight);

        // 应用缩放比例
        transform.localScale = scale;
    }
}
