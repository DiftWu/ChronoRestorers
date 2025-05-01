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
        var dialogTexts_en = new List<DialogData>();

        dialogTexts.Add(new DialogData("小红、小蓝来到城外的牢房。牢房内昏暗潮湿，墙壁斑驳，囚犯们个个身负鞭痕，瘦骨嶙峋，眼中尽是绝望与无助。狱卒冷眼旁观，面无表情，耳边只听得囚犯们的低声呻吟。", "场景"));
        dialogTexts.Add(new DialogData("(声音冷漠，眉头紧锁) 你们问这些做甚？这牢里的人，一个个都犯了秦律，不是流放就是受刑。轻则流放，重则斩首，全家老小也不能幸免。", "狱卒"));
        dialogTexts.Add(new DialogData("(虚弱地抬起头，眼中布满血丝，语气充满哀愁) 大人，小人实在无力缴清赋税，才被判入此地。可怜家中亲族，虽不曾犯事，却因我一人之罪，被官府拖去服役，家破人亡……我……我罪该万死，却不愿家人陪葬啊！", "囚犯"));
        dialogTexts.Add(new DialogData("小蓝低头叹息，听闻这无辜连坐之苦，心中黯然，将秦律之苛记在心头。", "场景"));

        dialogTexts_en.Add(new DialogData("Xiao Hong and Xiao Lan arrived at the prison outside the city. The cell was dark and damp, with peeling walls. The prisoners, all bearing whip marks and emaciated, had eyes full of despair and helplessness. The jailer watched coldly, expressionless, while the faint moans of prisoners filled the air.", "Scene"));
        dialogTexts_en.Add(new DialogData("(Cold voice, frowning) Why do you ask? Everyone here has violated Qin laws - they're either exiled or punished. Light punishments mean exile, severe ones mean beheading, and their entire families can't escape either.", "Jailer"));
        dialogTexts_en.Add(new DialogData("(Lifting head weakly, bloodshot eyes full of sorrow) Sir... I was truly unable to pay the taxes, so I was sentenced here. My poor family... though innocent... was dragged into forced labor because of my crime... home destroyed, lives ruined... I... I deserve death, but not my family!", "Prisoner"));
        dialogTexts_en.Add(new DialogData("Xiao Lan lowered her head and sighed. Hearing of this unjust collective punishment, her heart darkened as she noted the harshness of Qin's laws.", "Scene"));

        DialogManager.Show(dialogTexts);

    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
