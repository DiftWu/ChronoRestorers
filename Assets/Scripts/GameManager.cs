using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName = "小红";
    public int level = 1;
    public int score = 0;
    public List<string> notebookEntries = new List<string>();

    private string filePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            filePath = Application.persistentDataPath + "/userdata.json";
            LoadUserData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(this, true);
        File.WriteAllText(filePath, json);
        Debug.Log("用户数据已保存: " + filePath);
    }

    public void LoadUserData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, this);
            Debug.Log("用户数据已加载");
        }
        else
        {
            Debug.LogWarning("未找到用户数据文件，使用默认数据");
        }
    }
}
