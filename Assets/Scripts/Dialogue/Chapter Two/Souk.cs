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
        var dialogTexts_en = new List<DialogData>();

        dialogTexts.Add(new DialogData("С�졢С������߽��м��������ϵİ���������������һ������˽�������Ⱥ�ܼ���ȴ���������������ǵ�������͸������Ŀ־��벻�����ƺ��κ�һ�仰����������ɱ��֮����", "����"));
        dialogTexts.Add(new DialogData("(ѹ��������С��������ʵ�) ���ǿ�֪���س�Ϊ����˽��ԣ�", "���ռ�"));
        dialogTexts.Add(new DialogData("(���ŵػ������ܣ�����˵��) �ǻ����ʣ��ǡ�������塯������ʼ�ʰѸ������鶼���ˣ�������������ʿ��ɱ���������յ�˼���类�������Ļ��ҿ���˵����", "������"));
        dialogTexts.Add(new DialogData("(̾Ϣһ������������������) ����֮������һ�����۶����ҡ������������ۣ������ɱͷ��������Ǹ���������������˿��������ܳ��ã�", "���ռ�"));

        dialogTexts_en.Add(new DialogData("Xiao Hong and Xiao Lan entered the marketplace, where townsfolk gathered in small clusters, whispering furtively. Despite the crowd, there was little noise - people's eyes filled with deep fear and unease, as if any word might bring fatal consequences.", "Scene"));
        dialogTexts_en.Add(new DialogData("(Speaking in hushed, cautious tones) Do you know why the Qin dynasty silences speech so completely?", "Villager A"));
        dialogTexts_en.Add(new DialogData("(Nervously glancing around, whispering) Need you ask? The 'Burning of Books and Burying of Scholars'! The First Emperor burned all non-Qin books and executed Confucian scholars and alchemists. Our minds have been shackled - who dares speak freely now?", "Villager B"));
        dialogTexts_en.Add(new DialogData("(Sighing with resignation) In these times, even the slightest criticism is forbidden. A wise man's comment becomes a capital offense, leaving the people silent as cicadas in winter. How can such tyranny endure?", "Villager A"));

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
