using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

// �ʼ��࣬��ʾÿһ���ʼ�
[System.Serializable]
public class Note
{
    public int id;  // �ʼǵ�Ψһ���
    public string content;

    public Note(int id, string content)
    {
        this.id = id;
        this.content = content;
    }
}

// �������������ʼ��б����
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
    public GameObject notebookPanel;  // �ʼǱ����
    public InputField inputField;     // �����
    public Text notesDisplay;         // ��ʾ�ʼǵ��ı�
    public Button addNoteButton;      // ��+����ť
    public Button removeNoteButton;   // ��-����ť
    private List<Note> notes = new List<Note>();  // �洢�ʼǵ��б�
    private string saveFilePath;  // �����ļ�·��
    private int nextNoteId = 1;  // ��һ���ʼǵı��
    private int noteCount = 0;  // �ʼǵ���Ŀ

    void Start()
    {
        // ��ʼ��ʱ���رʼǱ�
        notebookPanel.SetActive(false);
        saveFilePath = Path.Combine(Application.persistentDataPath, "notes.json");  // �ʼǱ���·��
        LoadNotes();  // ����ʱ���رʼ�

        addNoteButton.onClick.AddListener(AddNote);
        removeNoteButton.onClick.AddListener(RemoveNote);

    }

    void Update()
    {
        // ���¼��̵ġ�N������/�رձʼǱ�
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNotebook();
        }
    }

    // ��/�رձʼǱ�
    public void ToggleNotebook()
    {
        notebookPanel.SetActive(!notebookPanel.activeSelf);
    }

    // ��ӱʼ�
    public void AddNote()
    {
        inputField.DeactivateInputField();  // ǿ���ύ����
        if (!string.IsNullOrEmpty(inputField.text))
        {
            notes.Add(new Note(nextNoteId, inputField.text));
            inputField.text = "";  // ��������
            nextNoteId++;  // ������һ���ʼǵı��
            noteCount++;  // ���ӱʼ���
            SaveNotes();  // ����ʼ�
            UpdateNotesDisplay();  // ���±ʼ���ʾ
        }
        else
        {
            Debug.LogWarning("Input field is empty, cannot add note");
        }
    }

    // ɾ�����һ���ʼ�
    public void RemoveNote()
    {
        if (noteCount > 0)
        {
            Note maxIdNote = notes[0];

            // �ҵ�������ıʼ�
            foreach (Note note in notes)
            {
                if (note.id > maxIdNote.id)
                {
                    maxIdNote = note;
                }
            }

            notes.Remove(maxIdNote);  // ɾ��������ıʼ�
            nextNoteId--;  // ��С��һ���ʼǵı��
            noteCount--;  // ��С�ʼ���
            SaveNotes();  // ������ĺ�ıʼ�
            UpdateNotesDisplay();  // ������ʾ
        }
        else
        {
            Debug.LogWarning("No notes to remove");
        }
    }

    // ���±ʼ���ʾ
    private void UpdateNotesDisplay()
    {
        notesDisplay.text = "";  // �����ʾ�ı�

        if (noteCount == 0)
        {
            notesDisplay.text = "No notes available.";  // ��û�бʼ�ʱ��ʾ��ʾ
        }
        else
        {
            foreach (Note note in notes)
            {
                notesDisplay.text += $"{note.id}: {note.content}\n";  // ��ʾÿ���ʼǵı�ź�����
                //notesDisplay.text += $"ID: {note.id},count:{noteCount}, Content: {note.content}\n";  // ��ʾÿ���ʼǵı�ź�����
            }
        }

        // ǿ��ˢ�� UI
        Canvas.ForceUpdateCanvases();
    }


    // ����ʼǵ��ļ�
    private void SaveNotes()
    {
        string json = JsonUtility.ToJson(new NoteList(notes), true);  // ���ʼ��б�ת��Ϊ JSON
        File.WriteAllText(saveFilePath, json);  // �� JSON д���ļ�
        Debug.Log("Notes saved to " + saveFilePath);
    }

    // ���ļ����رʼ�
    private void LoadNotes()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);  // ��ȡ�ļ�����
            NoteList loadedNotes = JsonUtility.FromJson<NoteList>(json);  // �����л� JSON
            notes = loadedNotes.notes;

            // ȷ����ǰ������ţ������� nextNoteId
            if (notes.Count > 0)
            {
                nextNoteId = 1;  // ���û�бʼǣ��������Ϊ 1
                noteCount = notes.Count;
                int maxId = 0;
                foreach (Note note in notes)
                {
                    if (note.id > maxId)
                    {
                        maxId = note.id;
                    }
                }
                nextNoteId = maxId + 1;  // ������һ���ʼǵı��Ϊ����ŵ���һ��
            }
            else
            {
                nextNoteId = 1;  // ���û�бʼǣ��������Ϊ 1
            }

            UpdateNotesDisplay();  // ������ʾ
        }
        else
        {
            Debug.Log("No saved notes found.");
            nextNoteId = 1;  // ����ļ������ڣ��������Ϊ 1
        }
    }
}
