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

        dialogTexts.Add(new DialogData("(从阴影中走出，声音低沉)你们穿越到了过去的秦朝，而历史已经出现混乱，唯有修正历史才能归还你们的命运", "神秘人"));
        dialogTexts.Add(new DialogData("(冷静地观察四周，轻声问)我们要如何修正历史？", "小红", () => Show_Example(0)));
        dialogTexts.Add(new DialogData("(面无表情)秦王嬴政虽统一天下，但/color:yellow/大一统/color:white/的基石尚未完全夯实。你们必须帮助他确立中央集权的制度，巩固他的统治。", "神秘人",() => Hide_Example(0)));
        dialogTexts.Add(new DialogData("(困惑地皱眉)中央集权？我们能帮上忙吗？", "小蓝"));
        dialogTexts.Add(new DialogData("(冷冷一笑)时间将证明一切。与大臣们对话，获取他们的意见，找出历史的正确答案。", "神秘人"));
        dialogTexts.Add(new DialogData("(坚定地看向小蓝)我们必须一试。", "小红",() => Show_Example(1)));

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
