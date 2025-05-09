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
        var dialogTexts_en = new List<DialogData>();

        dialogTexts.Add(new DialogData("(����Ӱ���߳��������ͳ�)���Ǵ�Խ���˹�ȥ���س�������ʷ�Ѿ����ֻ��ң�Ψ��������ʷ���ܹ黹���ǵ�����", "������"));
        dialogTexts.Add(new DialogData("(�侲�ع۲����ܣ�������)����Ҫ���������ʷ��", "С��", () => Show_Example(0)));
        dialogTexts.Add(new DialogData("(���ޱ���)����������ͳһ���£���/color:yellow/��һͳ/color:white/�Ļ�ʯ��δ��ȫ��ʵ�����Ǳ��������ȷ�����뼯Ȩ���ƶȣ���������ͳ�Ρ�", "������",() => Hide_Example(0)));
        dialogTexts.Add(new DialogData("(�������ü)���뼯Ȩ�������ܰ���æ��", "С��"));
        dialogTexts.Add(new DialogData("(����һЦ)ʱ�佫֤��һ�С�����ǶԻ�����ȡ���ǵ�������ҳ���ʷ����ȷ�𰸡�", "������"));
        dialogTexts.Add(new DialogData("(�ᶨ�ؿ���С��)���Ǳ���һ�ԡ�", "С��",() => Show_Example(1)));

        dialogTexts_en.Add(new DialogData("(Emerging from the shadows, speaking in a deep voice) You've traveled back to the Qin dynasty, but history has been disrupted. Only by correcting it can you restore your destinies.", "Mysterious Figure"));
        dialogTexts_en.Add(new DialogData("(Calmly observing surroundings, asking softly) How do we correct history?", "Xiao Hong", () => Show_Example(0)));
        dialogTexts_en.Add(new DialogData("(Expressionless) Although Emperor Qin Shi Huang unified the realm, the foundation of /color:yellow/centralized power/color:white/ isn't fully established yet. You must help him implement the centralized authority system and consolidate his rule.", "Mysterious Figure", () => Hide_Example(0)));
        dialogTexts_en.Add(new DialogData("(Frowning in confusion) Centralized authority? Can we really help with that?", "Xiao Lan"));
        dialogTexts_en.Add(new DialogData("(Smiling coldly) Time will tell everything. Speak with the ministers, gather their opinions, and find the correct path in history.", "Mysterious Figure"));
        dialogTexts_en.Add(new DialogData("(Looking firmly at Xiao Lan) We have to try.", "Xiao Hong", () => Show_Example(1)));

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

    private void Hide_Example(int index)
    {
        Example[index].SetActive(false);
    }
}
