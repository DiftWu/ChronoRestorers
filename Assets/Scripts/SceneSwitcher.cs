using UnityEngine;
using UnityEngine.SceneManagement;  // 导入场景管理库

public class SceneSwitcher : MonoBehaviour
{
    // 场景名称，可以在 Inspector 中指定
    public string sceneName;

    public void SwitchScene()
    {
        // 使用 SceneManager 加载指定的场景
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("未指定场景名称");
        }
    }
}
