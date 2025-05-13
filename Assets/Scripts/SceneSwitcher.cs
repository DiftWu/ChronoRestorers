using UnityEngine;
using UnityEngine.SceneManagement;  // ���볡�������

public class SceneSwitcher : MonoBehaviour
{
    // �������ƣ������� Inspector ��ָ��
    public string sceneName;

    public void SwitchScene()
    {
        // ʹ�� SceneManager ����ָ���ĳ���
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("δָ����������");
        }
    }

    public void QuitGame()
    {
        // �ڱ༭������Ч��ֻ�ڴ�������Ϸ����Ч
        Application.Quit();

        // �༭���в�����
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
