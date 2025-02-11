using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Transition : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("(����Ӱ���߳��������ͳ�)���Ǵ�Խ���˹�ȥ���س�������ʷ�Ѿ����ֻ��ң�Ψ��������ʷ���ܹ黹���ǵ�����", "������"));
        dialogTexts.Add(new DialogData("(�侲�ع۲����ܣ�������)����Ҫ���������ʷ��", "С��", () => Show_Example(0)));
        dialogTexts.Add(new DialogData("(���ޱ���)����������ͳһ���£���/color:yellow/��һͳ/color:white/�Ļ�ʯ��δ��ȫ��ʵ�����Ǳ��������ȷ�����뼯Ȩ���ƶȣ���������ͳ�Ρ�", "������",() => Hide_Example(0)));
        dialogTexts.Add(new DialogData("(�������ü)���뼯Ȩ�������ܰ���æ��", "С��"));
        dialogTexts.Add(new DialogData("(����һЦ)ʱ�佫֤��һ�С�����ǶԻ�����ȡ���ǵ�������ҳ���ʷ����ȷ�𰸡�", "������"));
        dialogTexts.Add(new DialogData("(�ᶨ�ؿ���С��)���Ǳ���һ�ԡ�", "С��",() => Show_Example(1)));

        DialogManager.Show(dialogTexts);
    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }

    private void Hide_Example(int index)
    {
        Example[index].SetActive(false);
    }
}
