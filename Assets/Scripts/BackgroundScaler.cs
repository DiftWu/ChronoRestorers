using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    public Camera mainCamera;   // �����
    public SpriteRenderer spriteRenderer;  // ����ͼƬ�� SpriteRenderer

    void Start()
    {
        AdjustBackgroundSize();
    }

    void AdjustBackgroundSize()
    {
        // ��ȡͼƬ�Ŀ�߱�
        float spriteHeight = spriteRenderer.sprite.bounds.size.y;
        float spriteWidth = spriteRenderer.sprite.bounds.size.x;

        // ��ȡ���������Ұ�߶�
        float cameraHeight = mainCamera.orthographicSize * 2f;

        // �����������Ұ�Ŀ��
        float cameraWidth = cameraHeight * Screen.width / Screen.height;

        // �������ű���
        Vector2 scale = new Vector2(cameraWidth / spriteWidth, cameraHeight / spriteHeight);

        // Ӧ�����ű���
        transform.localScale = scale;
    }
}
