using System;
using UnityEngine;

[Serializable]
public class Question
{
    public int id;
    public string knowledgePoint; // ֪ʶ����࣬���� "Math", "Science"
    public string type;           // ���ͣ�"choice"��ѡ���⣩��"judge"���ж��⣩��"fill"������⣩
    public string questionText;   // ��Ŀ����
    public string[] options;      // ѡ���������ѡ���⣩
    public string correctAnswer;  // ��ȷ��
}
