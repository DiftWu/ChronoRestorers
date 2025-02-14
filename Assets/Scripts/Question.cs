using System;
using UnityEngine;

[Serializable]
public class Question
{
    public int id;
    public string knowledgePoint; // 知识点分类，例如 "Math", "Science"
    public string type;           // 题型："choice"（选择题）、"judge"（判断题）、"fill"（填空题）
    public string questionText;   // 题目内容
    public string[] options;      // 选项（仅适用于选择题）
    public string correctAnswer;  // 正确答案
}
