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

    public void QuitGame()
    {
        // 在编辑器中无效，只在打包后的游戏中有效
        Application.Quit();

        // 编辑器中测试用
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
