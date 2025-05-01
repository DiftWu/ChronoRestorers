using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class EmotionDetector : MonoBehaviour
{
    private static EmotionDetector instance;  // 单例模式
    private Process pythonProcess;
    private StreamReader outputReader;
    private Thread readThread;
    private bool isRunning = false;
    private bool isMindWandering = false;

    [Header("警告UI")]
    public GameObject warningPanel;

    private ConcurrentQueue<System.Action> mainThreadActions = new ConcurrentQueue<System.Action>(); // 主线程任务队列

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        StartPythonScript();

        isRunning = true;
        readThread = new Thread(ReadPythonOutputThread);
        readThread.Start();

        if (warningPanel != null)
            warningPanel.SetActive(false);
    }

    void StartPythonScript()
    {
        string faceFolder = Path.Combine(Application.streamingAssetsPath, "Face");
        string pythonExePath = Path.Combine(faceFolder, "python.exe");
        string scriptPath = Path.Combine(faceFolder, "detect_drowsiness.py");

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = pythonExePath,
            Arguments = scriptPath,
            WorkingDirectory = faceFolder,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        pythonProcess = new Process();
        pythonProcess.StartInfo = startInfo;
        pythonProcess.Start();

        outputReader = pythonProcess.StandardOutput;
    }

    void ReadPythonOutputThread()
    {
        while (isRunning && !outputReader.EndOfStream)
        {
            string line = outputReader.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                ProcessOutput(line);
            }
        }
    }

    void ProcessOutput(string line)
    {
        UnityEngine.Debug.Log("[Python] " + line);

        if (line.StartsWith("Emotion:"))
        {
            string emotion = line.Substring(8);
            // TODO: 根据 emotion 做其他处理
        }
        else if (line.StartsWith("Status:"))
        {
            string status = line.Substring(7);
            if (status == "mind-wandering")
            {
                if (!isMindWandering)
                {
                    isMindWandering = true;
                    ShowMindWanderingWarning();
                }
            }
        }
    }

    void ShowMindWanderingWarning()
    {
        // 将弹窗操作放到主线程执行
        mainThreadActions.Enqueue(() =>
        {
            UnityEngine.Debug.LogWarning("检测到走神！请集中注意力！");
            if (warningPanel != null)
                warningPanel.SetActive(true);
        });
    }

    void Update()
    {
        // 主线程每一帧执行排队的任务
        while (mainThreadActions.TryDequeue(out var action))
        {
            action?.Invoke();
        }
    }

    void OnApplicationQuit()
    {
        isRunning = false;

        if (readThread != null && readThread.IsAlive)
        {
            readThread.Join();
        }

        if (pythonProcess != null && !pythonProcess.HasExited)
        {
            pythonProcess.Kill();
            pythonProcess.Dispose();
        }
    }
}
