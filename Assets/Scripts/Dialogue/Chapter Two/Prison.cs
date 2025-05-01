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

        dialogTexts.Add(new DialogData("С�졢С������������η����η��ڻ谵��ʪ��ǽ�ڰ߲��������Ǹ������޺ۣ��ݹ���ᾣ����о��Ǿ��������������������Թۣ����ޱ��飬����ֻ���������ǵĵ���������", "����"));
        dialogTexts.Add(new DialogData("(������Į��üͷ����) ��������Щ��������������ˣ�һ�������������ɣ��������ž������̡��������ţ�����ն�ף�ȫ����СҲ�������⡣", "����"));
        dialogTexts.Add(new DialogData("(������̧��ͷ�����в���Ѫ˿��������������) ���ˣ�С��ʵ���������帳˰���ű�����˵ء������������壬�䲻�����£�ȴ����һ��֮����ٸ���ȥ���ۣ��������������ҡ��������������ȴ��Ը�������ᰡ��", "����"));
        dialogTexts.Add(new DialogData("С����ͷ̾Ϣ���������޹�����֮�࣬������Ȼ��������֮��������ͷ��", "����"));

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
