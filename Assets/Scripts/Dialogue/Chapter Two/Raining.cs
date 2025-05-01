using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Raining : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    public void Awake()
    {
        var dialogTexts = new List<DialogData>();
        var dialogTexts_en = new List<DialogData>();

        dialogTexts.Add(new DialogData("大泽乡，天空阴云密布，空气中弥漫着湿冷与压抑。陈胜、吴广带领的900名戍卒因遇大雨阻道，无法按期到达戍守地。众人神情疲惫，行路艰难，脚下泥泞不堪，前途未卜，名誉岌岌可危。雨水滴落在每个人的肩头，仿佛压得他们更加沉重。秦朝的暴政笼罩如同这压顶的天空，让人难以喘息。", "场景"));
        dialogTexts.Add(new DialogData("(抬头望向乌云密布的天际，轻声叹息）雨未停，路难行。再不动身，误了时辰，只怕性命难保。", "戍卒甲"));
        dialogTexts.Add(new DialogData("(愤懑地踢开脚边的泥土，语气中透着无奈）误期即斩，若是赶上了，戍守也是死路一条。天高地远，我等不过是朝廷的草芥，哪里有活路？", "戍卒乙"));
        dialogTexts.Add(new DialogData("(冷静扫视众人，语气低沉而坚定）错过时限，按律当斩。你我皆知，朝廷苛法严刑，谁能幸免？不如……与其坐以待毙，不如搏一条生路。", "吴广"));
        dialogTexts.Add(new DialogData("(目光如炬，声音愈发坚定）“天下大乱，百姓苦不堪言。征发无休，赋役连年，秦朝暴虐，视我等如牛马。今日误期即死，若去戍守，亦不过为朝廷之刍狗，性命难保。与其苟活，不如反抗！堂堂壮士，何不以一战求存，王侯将相,宁有种乎！", "陈胜"));
        dialogTexts.Add(new DialogData("(目光闪烁，语气中带着一丝颤抖与期待）陈大人所言极是！与其被斩，不如举旗反秦，拼得一命！", "戍卒甲"));
        dialogTexts.Add(new DialogData("(满怀激情地附和）正是如此！反秦暴政，解救百姓！", "戍卒乙"));
        dialogTexts.Add(new DialogData("(众人情绪高涨，纷纷应和，呼声如雷。陈胜与吴广的号召点燃了戍卒们内心的怒火，雨中策反成功，反秦的怒火在大泽乡燃起。）", "旁白"));

        dialogTexts_en.Add(new DialogData("In Daze Village, dark clouds blanketed the sky as a damp, oppressive air hung heavy. Chen Sheng and Wu Guang's 900 garrison soldiers, delayed by torrential rains, couldn't reach their post on time. Exhausted and struggling through the mud, their future uncertain and honor at stake, each raindrop on their shoulders seemed to weigh them down further. The Qin dynasty's tyranny loomed like the stormy sky itself, making it hard to breathe.", "Scene"));
        dialogTexts_en.Add(new DialogData("(Looking up at the clouded sky with a quiet sigh) The rain won't stop, the road's impassable. If we don't move soon and miss the deadline, our lives are forfeit.", "Soldier A"));
        dialogTexts_en.Add(new DialogData("(Kicking mud angrily, voice full of resignation) Late arrival means execution - but even if we make it, garrison duty is another death sentence. We're just worthless grass to the court - where's our path to survival?", "Soldier B"));
        dialogTexts_en.Add(new DialogData("(Scanning the crowd calmly with determined tone) Missing the deadline means death by law. We all know the court's harsh punishments spare none. Rather than waiting for death... shouldn't we fight for survival?", "Wu Guang"));
        dialogTexts_en.Add(new DialogData("(Eyes blazing, voice growing stronger) The realm is in chaos, the people suffer endlessly. Conscription without end, neverending taxes and labor - the Qin tyranny treats us like beasts! Today, being late means death, but garrison duty would make us sacrificial lambs anyway. Rather than living meekly, let's rebel! Are we not men as good as any noble or king? Who says kings and generals are born to their stations?", "Chen Sheng"));
        dialogTexts_en.Add(new DialogData("(Eyes flashing with tremulous hope) Lord Chen speaks truth! Better to raise the rebel banner than be executed!", "Soldier A"));
        dialogTexts_en.Add(new DialogData("(Passionately agreeing) Exactly! Overthrow Qin's tyranny, save our people!", "Soldier B"));
        dialogTexts_en.Add(new DialogData("(The crowd's fervor erupts in thunderous agreement. Chen Sheng and Wu Guang's words ignite the soldiers' fury. Their rebellion succeeds in the rain, and the flames of revolution kindle in Daze Village.)", "Narrator"));

        DialogManager.Show(dialogTexts);

    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
