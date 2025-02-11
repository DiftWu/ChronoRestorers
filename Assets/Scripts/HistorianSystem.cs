using UnityEngine;

public class HistorianSystem : MonoBehaviour
{
    public GameObject HistorianPanel; // 史官面板
    public GameObject NotebookSystemPanel; // 笔记本面板
    public GameObject Feature2Panel; // 功能2面板
    public GameObject Feature3Panel; // 功能3面板

    void Start()
    {
        // 初始隐藏史官面板和功能面板
        HistorianPanel.SetActive(false);
        NotebookSystemPanel.SetActive(false);
        Feature2Panel.SetActive(false);
        Feature3Panel.SetActive(false);
    }

    public void ToggleHistorianPanel()
    {
        // 切换史官面板的显示状态
        HistorianPanel.SetActive(!HistorianPanel.activeSelf);
    }

    public void OpenNotebookSystem()
    {
        // 打开笔记本系统面板，隐藏其他功能面板
        NotebookSystemPanel.SetActive(true);
        Feature2Panel.SetActive(false);
        Feature3Panel.SetActive(false);
    }

    public void OpenFeature2()
    {
        // 打开功能2面板，隐藏其他功能面板
        NotebookSystemPanel.SetActive(false);
        Feature2Panel.SetActive(true);
        Feature3Panel.SetActive(false);
    }

    public void OpenFeature3()
    {
        // 打开功能3面板，隐藏其他功能面板
        NotebookSystemPanel.SetActive(false);
        Feature2Panel.SetActive(false);
        Feature3Panel.SetActive(true);
    }
}
