using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

// 笔记类，表示每一条笔记
[System.Serializable]
public class Note
{
    public int id;  // 笔记的唯一编号
    public string content;

    public Note(int id, string content)
    {
        this.id = id;
        this.content = content;
    }
}

// 用来保存整个笔记列表的类
[System.Serializable]
public class NoteList
{
    public List<Note> notes;

    public NoteList(List<Note> notes)
    {
        this.notes = notes;
    }
}

public class NotebookManager : MonoBehaviour
{
    public GameObject notebookPanel;  // 笔记本面板
    public InputField inputField;     // 输入框
    public Text notesDisplay;         // 显示笔记的文本
    public Button addNoteButton;      // “+”按钮
    public Button removeNoteButton;   // “-”按钮
    private List<Note> notes = new List<Note>();  // 存储笔记的列表
    private string saveFilePath;  // 保存文件路径
    private int nextNoteId = 1;  // 下一个笔记的编号
    private int noteCount = 0;  // 笔记的数目

    void Start()
    {
        // 初始化时隐藏笔记本
        notebookPanel.SetActive(false);
        saveFilePath = Path.Combine(Application.persistentDataPath, "notes.json");  // 笔记保存路径
        LoadNotes();  // 启动时加载笔记

        addNoteButton.onClick.AddListener(AddNote);
        removeNoteButton.onClick.AddListener(RemoveNote);

    }

    void Update()
    {
        // 按下键盘的“N”键打开/关闭笔记本
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNotebook();
        }
    }

    // 打开/关闭笔记本
    public void ToggleNotebook()
    {
        notebookPanel.SetActive(!notebookPanel.activeSelf);
    }

    // 添加笔记
    public void AddNote()
    {
        inputField.DeactivateInputField();  // 强制提交输入
        if (!string.IsNullOrEmpty(inputField.text))
        {
            notes.Add(new Note(nextNoteId, inputField.text));
            inputField.text = "";  // 清空输入框
            nextNoteId++;  // 增加下一个笔记的编号
            noteCount++;  // 增加笔记数
            SaveNotes();  // 保存笔记
            UpdateNotesDisplay();  // 更新笔记显示
        }
        else
        {
            Debug.LogWarning("Input field is empty, cannot add note");
        }
    }

    // 删除最后一条笔记
    public void RemoveNote()
    {
        if (noteCount > 0)
        {
            Note maxIdNote = notes[0];

            // 找到编号最大的笔记
            foreach (Note note in notes)
            {
                if (note.id > maxIdNote.id)
                {
                    maxIdNote = note;
                }
            }

            notes.Remove(maxIdNote);  // 删除编号最大的笔记
            nextNoteId--;  // 减小下一个笔记的编号
            noteCount--;  // 减小笔记数
            SaveNotes();  // 保存更改后的笔记
            UpdateNotesDisplay();  // 更新显示
        }
        else
        {
            Debug.LogWarning("No notes to remove");
        }
    }

    // 更新笔记显示
    private void UpdateNotesDisplay()
    {
        notesDisplay.text = "";  // 清空显示文本

        if (noteCount == 0)
        {
            notesDisplay.text = "No notes available.";  // 当没有笔记时显示提示
        }
        else
        {
            foreach (Note note in notes)
            {
                notesDisplay.text += $"{note.id}: {note.content}\n";  // 显示每条笔记的编号和内容
                //notesDisplay.text += $"ID: {note.id},count:{noteCount}, Content: {note.content}\n";  // 显示每条笔记的编号和内容
            }
        }

        // 强制刷新 UI
        Canvas.ForceUpdateCanvases();
    }


    // 保存笔记到文件
    private void SaveNotes()
    {
        string json = JsonUtility.ToJson(new NoteList(notes), true);  // 将笔记列表转换为 JSON
        File.WriteAllText(saveFilePath, json);  // 将 JSON 写入文件
        Debug.Log("Notes saved to " + saveFilePath);
    }

    // 从文件加载笔记
    private void LoadNotes()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);  // 读取文件内容
            NoteList loadedNotes = JsonUtility.FromJson<NoteList>(json);  // 反序列化 JSON
            notes = loadedNotes.notes;

            // 确定当前的最大编号，并设置 nextNoteId
            if (notes.Count > 0)
            {
                nextNoteId = 1;  // 如果没有笔记，将编号设为 1
                noteCount = notes.Count;
                int maxId = 0;
                foreach (Note note in notes)
                {
                    if (note.id > maxId)
                    {
                        maxId = note.id;
                    }
                }
                nextNoteId = maxId + 1;  // 设置下一个笔记的编号为最大编号的下一个
            }
            else
            {
                nextNoteId = 1;  // 如果没有笔记，将编号设为 1
            }

            UpdateNotesDisplay();  // 更新显示
        }
        else
        {
            Debug.Log("No saved notes found.");
            nextNoteId = 1;  // 如果文件不存在，将编号设为 1
        }
    }
}
