using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Prison : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("小红、小蓝来到城外的牢房。牢房内昏暗潮湿，墙壁斑驳，囚犯们个个身负鞭痕，瘦骨嶙峋，眼中尽是绝望与无助。狱卒冷眼旁观，面无表情，耳边只听得囚犯们的低声呻吟。", "场景"));
        dialogTexts.Add(new DialogData("(声音冷漠，眉头紧锁) 你们问这些做甚？这牢里的人，一个个都犯了秦律，不是流放就是受刑。轻则流放，重则斩首，全家老小也不能幸免。", "狱卒"));
        dialogTexts.Add(new DialogData("(虚弱地抬起头，眼中布满血丝，语气充满哀愁) 大人，小人实在无力缴清赋税，才被判入此地。可怜家中亲族，虽不曾犯事，却因我一人之罪，被官府拖去服役，家破人亡……我……我罪该万死，却不愿家人陪葬啊！", "囚犯"));
        dialogTexts.Add(new DialogData("小蓝低头叹息，听闻这无辜连坐之苦，心中黯然，将秦律之苛记在心头。", "场景"));
  
        DialogManager.Show(dialogTexts);

    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
