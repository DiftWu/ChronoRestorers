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

        dialogTexts.Add(new DialogData("小红、小蓝随后走进市集，集市上的百姓三三两两聚在一起，窃窃私语。尽管人群密集，却少有喧哗，百姓们的眼神中透着深深的恐惧与不安，似乎任何一句话都可能惹来杀身之祸。", "场景"));
        dialogTexts.Add(new DialogData("(压低声音，小心翼翼地问道) 你们可知，秦朝为何如此禁言？", "百姓甲"));
        dialogTexts.Add(new DialogData("(紧张地环顾四周，低声说道) 那还用问？是‘焚书坑儒’啊！秦始皇把各国的书都烧了，还把儒生、方士坑杀殆尽，百姓的思想早被禁锢，哪还敢开口说话？", "百姓乙"));
        dialogTexts.Add(new DialogData("(叹息一声，眼神中满是无奈) 当今之世，连一点议论都不敢。智者稍有议论，便成了杀头的罪，百姓们个个噤若寒蝉。如此苛政，岂能长久？", "百姓甲"));

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
