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
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("��̽����ͬʱ����Ҳ���ܱ����صĹ��﷢�ֶ������뵽����Ŀռ���", "������"));
        dialogTexts.Add(new DialogData("������ʾͨ��ս�����ܹ�����߽⿪���⣬�����뿪", "������"));

        DialogManager.Show(dialogTexts);

    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
