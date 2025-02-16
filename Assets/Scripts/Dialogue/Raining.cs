using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using System.IO;

public class Raining : MonoBehaviour
{
    public DialogManager DialogManager;
    public GameObject Dialog;
    public bool isActive = false;

    public GameObject[] Example;

    void Start()
    {
        //Dialog.SetActive(false);
    }

    private void Update()
    {
        if (isActive) Awake();
    }

    public void Show()
    {
        Dialog.SetActive(true);
        isActive = true;
    }

    private void Awake()
    {
        if (isActive)
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("大泽乡，天空阴云密布，空气中弥漫着湿冷与压抑。陈胜、吴广带领的900名戍卒因遇大雨阻道，无法按期到达戍守地。众人神情疲惫，行路艰难，脚下泥泞不堪，前途未卜，名誉岌岌可危。雨水滴落在每个人的肩头，仿佛压得他们更加沉重。秦朝的暴政笼罩如同这压顶的天空，让人难以喘息。", "场景"));
            dialogTexts.Add(new DialogData("(抬头望向乌云密布的天际，轻声叹息）雨未停，路难行。再不动身，误了时辰，只怕性命难保。", "戍卒甲"));
            dialogTexts.Add(new DialogData("(愤懑地踢开脚边的泥土，语气中透着无奈）误期即斩，若是赶上了，戍守也是死路一条。天高地远，我等不过是朝廷的草芥，哪里有活路？", "戍卒乙"));
            dialogTexts.Add(new DialogData("(冷静扫视众人，语气低沉而坚定）错过时限，按律当斩。你我皆知，朝廷苛法严刑，谁能幸免？不如……与其坐以待毙，不如搏一条生路。", "吴广"));
            dialogTexts.Add(new DialogData("(目光如炬，声音愈发坚定）“天下大乱，百姓苦不堪言。征发无休，赋役连年，秦朝暴虐，视我等如牛马。今日误期即死，若去戍守，亦不过为朝廷之刍狗，性命难保。与其苟活，不如反抗！堂堂壮士，何不以一战求存，王侯将相,宁有种乎！", "陈胜"));
            dialogTexts.Add(new DialogData("(目光闪烁，语气中带着一丝颤抖与期待）陈大人所言极是！与其被斩，不如举旗反秦，拼得一命！", "戍卒甲"));
            dialogTexts.Add(new DialogData("(满怀激情地附和）正是如此！反秦暴政，解救百姓！", "戍卒乙"));
            dialogTexts.Add(new DialogData("(众人情绪高涨，纷纷应和，呼声如雷。陈胜与吴广的号召点燃了戍卒们内心的怒火，雨中策反成功，反秦的怒火在大泽乡燃起。）", "旁白"));

            DialogManager.Show(dialogTexts);
            isActive = false;
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
