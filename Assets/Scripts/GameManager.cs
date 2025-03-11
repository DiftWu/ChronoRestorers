using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName = "С��";
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
        Debug.Log("�û������ѱ���: " + filePath);
    }

    public void LoadUserData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, this);
            Debug.Log("�û������Ѽ���");
        }
        else
        {
            Debug.LogWarning("δ�ҵ��û������ļ���ʹ��Ĭ������");
        }
    }
}
