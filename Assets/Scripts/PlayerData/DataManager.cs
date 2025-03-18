using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    private string filePath;

    public PlayerData playerData = new PlayerData(); // 存储当前玩家数据

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            filePath = Application.persistentDataPath + "/playerData.json";
            LoadPlayerData(); // 启动时自动加载数据
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 保存玩家数据到 JSON 文件
    public void SavePlayerData()
    {
        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(filePath, json);
        Debug.Log("数据已保存: " + json);
        Debug.Log("存档路径: " + Application.persistentDataPath);
    }

    // 从 JSON 文件加载玩家数据
    public void LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("数据已加载: " + json);
        }
        else
        {
            Debug.LogWarning("未找到存档文件，使用默认数据");
            playerData = new PlayerData { playerName = "默认玩家", playerScore = 0, distracted = 0, voiceuse = 0, ChapterOneFalse = 0, ChapterOneRight = 0, ChapterTwoFalse = 0, ChapterTwoRight = 0};
        }
    }
}
