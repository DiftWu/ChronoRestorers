using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Souk : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("С�졢С������߽��м��������ϵİ���������������һ������˽�������Ⱥ�ܼ���ȴ���������������ǵ�������͸������Ŀ־��벻�����ƺ��κ�һ�仰����������ɱ��֮����", "����"));
        dialogTexts.Add(new DialogData("(ѹ��������С��������ʵ�) ���ǿ�֪���س�Ϊ����˽��ԣ�", "���ռ�"));
        dialogTexts.Add(new DialogData("(���ŵػ������ܣ�����˵��) �ǻ����ʣ��ǡ�������塯������ʼ�ʰѸ������鶼���ˣ�������������ʿ��ɱ���������յ�˼���类�������Ļ��ҿ���˵����", "������"));
        dialogTexts.Add(new DialogData("(̾Ϣһ������������������) ����֮������һ�����۶����ҡ������������ۣ������ɱͷ��������Ǹ���������������˿��������ܳ��ã�", "���ռ�"));

        DialogManager.Show(dialogTexts);

    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
