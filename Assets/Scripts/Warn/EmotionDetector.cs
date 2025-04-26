using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.UI; 

public class EmotionDetector : MonoBehaviour
{
    private Process pythonProcess;
    private StreamReader outputReader;
    private bool isMindWandering = false;

    [Header("警告UI")]
    public GameObject warningPanel;

    void Start()
    {
        StartPythonScript();
        StartCoroutine(ReadPythonOutput());

        if (warningPanel != null)
            warningPanel.SetActive(false);
    }

    void StartPythonScript()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "C:/WORK/ChronoRestorers/Library/Face/python.exe";
        startInfo.Arguments = "detect_drowsiness.py";
        startInfo.WorkingDirectory = Application.dataPath + "/../Library/Face";
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.CreateNoWindow = true;

        pythonProcess = new Process();
        pythonProcess.StartInfo = startInfo;
        pythonProcess.Start();

        outputReader = pythonProcess.StandardOutput;
    }

    IEnumerator ReadPythonOutput()
    {
        while (!outputReader.EndOfStream)
        {
            string line = outputReader.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                ProcessOutput(line);
            }
            yield return null;
        }
    }

    void ProcessOutput(string line)
    {
        UnityEngine.Debug.Log("[Python] " + line);

        if (line.StartsWith("Emotion:"))
        {
            string emotion = line.Substring(8);
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
        UnityEngine.Debug.LogWarning("检测到走神！请集中注意力！");
        if (warningPanel != null)
            warningPanel.SetActive(true);
    }

    void OnApplicationQuit()
    {
        if (pythonProcess != null && !pythonProcess.HasExited)
        {
            pythonProcess.Kill();
            pythonProcess.Dispose();
        }
    }
}
