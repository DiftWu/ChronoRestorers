using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using System.IO;

public class Farmland : MonoBehaviour
{
    public DialogManager DialogManager;
    public GameObject ob;

    public GameObject[] Example;

    void Start()
    {
        ob.SetActive(false);
    }
    private void Awake()
    {
        var dialogTexts = new List<DialogData>();
        var dialogTexts_en = new List<DialogData>();

        dialogTexts.Add(new DialogData("烈日当空，干裂的田地中，农夫们正弯腰劳作，疲惫与绝望写在他们的脸上。两位年迈的农夫坐在田埂边，满脸愁容，目光呆滞，似乎已被生活的重压压垮。", "场景"));
        dialogTexts.Add(new DialogData("(抬头望天叹息一声，满脸无奈)这天哪……赋税一年比一年重，徭役连年不断，田里的庄稼还没长好，就要被朝廷抽去修什么陵墓、宫殿，日子怎生是个尽头啊！", "农夫甲"));
        dialogTexts.Add(new DialogData("(用袖子擦去汗水，声音虚弱，透着疲态)是啊。徭役连连，田里的劳力都被征走了。就算地里再多下工夫，收成也是少得可怜。秦朝好大喜功，咱们这等小民也不过是任人驱使的牛马。", "农夫乙"));
        dialogTexts.Add(new DialogData("(小红听闻此言，心头一震，目光沉痛，悄然记下秦朝徭役严苛、赋税压人的情形。)", "场景"));
        dialogTexts.Add(new DialogData("就在这时，一队官兵注意到了此处。", "场景"));
        dialogTexts.Add(new DialogData("那边的，你们在做什么，接受检查！", "官兵"));
        dialogTexts.Add(new DialogData("欸，你们快走吧，就从这麦田中逃跑吧。", "农夫甲"));

        dialogTexts_en.Add(new DialogData("Under the scorching sun, farmers toil in the parched fields, exhaustion and despair written on their faces. Two elderly farmers sit by the field ridge, their faces lined with worry, eyes dull - seemingly crushed by life's burdens.", "Scene"));
        dialogTexts_en.Add(new DialogData("(Looking up at the sky with a sigh, face full of resignation) Oh heavens... The taxes grow heavier each year, and the corvée labor never ends. Before our crops can even mature, the court takes us away to build tombs and palaces. When will this suffering end?", "Farmer A"));
        dialogTexts_en.Add(new DialogData("(Wiping sweat with sleeve, voice weak and tired) Indeed. With endless forced labor, all our field workers get conscripted. No matter how hard we work the land, the harvest remains pitifully small. The Qin dynasty chases grandiose achievements while common folk like us are treated as mere beasts of burden.", "Farmer B"));
        dialogTexts_en.Add(new DialogData("(Xiao Hong hears this and is deeply moved, her pained eyes silently recording the Qin dynasty's harsh corvée labor and oppressive taxation.)", "Scene"));
        dialogTexts_en.Add(new DialogData("Just then, a squad of government soldiers notices the group.", "Scene"));
        dialogTexts_en.Add(new DialogData("You there! What are you doing? Submit for inspection!", "Soldier"));
        dialogTexts_en.Add(new DialogData("Hey, you'd better leave quickly. Escape through the wheat field.", "Farmer A"));

        DialogManager.Show(dialogTexts);

    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
