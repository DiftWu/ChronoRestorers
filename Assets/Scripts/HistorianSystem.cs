using UnityEngine;

public class HistorianSystem : MonoBehaviour
{
    public GameObject HistorianPanel; // ʷ�����
    public GameObject NotebookSystemPanel; // �ʼǱ����
    public GameObject Feature2Panel; // ����2���
    public GameObject Feature3Panel; // ����3���

    void Start()
    {
        // ��ʼ����ʷ�����͹������
        HistorianPanel.SetActive(false);
        NotebookSystemPanel.SetActive(false);
        Feature2Panel.SetActive(false);
        Feature3Panel.SetActive(false);
    }

    public void ToggleHistorianPanel()
    {
        // �л�ʷ��������ʾ״̬
        HistorianPanel.SetActive(!HistorianPanel.activeSelf);
    }

    public void OpenNotebookSystem()
    {
        // �򿪱ʼǱ�ϵͳ��壬���������������
        NotebookSystemPanel.SetActive(true);
        Feature2Panel.SetActive(false);
        Feature3Panel.SetActive(false);
    }

    public void OpenFeature2()
    {
        // �򿪹���2��壬���������������
        NotebookSystemPanel.SetActive(false);
        Feature2Panel.SetActive(true);
        Feature3Panel.SetActive(false);
    }

    public void OpenFeature3()
    {
        // �򿪹���3��壬���������������
        NotebookSystemPanel.SetActive(false);
        Feature2Panel.SetActive(false);
        Feature3Panel.SetActive(true);
    }
}
