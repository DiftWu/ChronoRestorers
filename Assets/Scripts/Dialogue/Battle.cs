using Doublsb.Dialog;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    private void Awake()
    {
        Debug.Log("isFirst after scene switch: " + PlayerPrefs.GetInt("isFirst"));

        var dialogTexts = new List<DialogData>();
        var dialogTexts_en = new List<DialogData>();

        dialogTexts.Add(new DialogData("��̽����ͬʱ����Ҳ���ܱ����صĹ��﷢�ֶ������뵽����Ŀռ���", "������"));
        dialogTexts.Add(new DialogData("������ʾͨ��ս�����ܹ�����߽⿪���⣬�����뿪", "������"));

        dialogTexts_en.Add(new DialogData("While exploring, you may be discovered by hidden monsters and pulled into a strange space.", "Mystery Man"));
        dialogTexts_en.Add(new DialogData("Defeat the monsters in battle or solve the puzzles as instructed to proceed.", "Mystery Man"));

        if (DataManager.Instance.playerData.usingEnglish)
        {
            DialogManager.Show(dialogTexts_en);
        }
        else
        {
            DialogManager.Show(dialogTexts);
        }
    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
