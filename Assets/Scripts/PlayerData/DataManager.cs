using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    private string filePath;

    public PlayerData playerData = new PlayerData(); // �洢��ǰ�������

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            filePath = Application.persistentDataPath + "/playerData.json";
            LoadPlayerData(); // ����ʱ�Զ���������
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ����������ݵ� JSON �ļ�
    public void SavePlayerData()
    {
        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(filePath, json);
        Debug.Log("�����ѱ���: " + json);
        Debug.Log("�浵·��: " + Application.persistentDataPath);
    }

    // �� JSON �ļ������������
    public void LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("�����Ѽ���: " + json);
        }
        else
        {
            Debug.LogWarning("δ�ҵ��浵�ļ���ʹ��Ĭ������");
            playerData = new PlayerData { playerName = "Ĭ�����", playerScore = 0, distracted = 0, voiceuse = 0, ChapterOneFalse = 0, ChapterOneRight = 0, ChapterTwoFalse = 0, ChapterTwoRight = 0};
        }
    }
}
