using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Farmland : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("烈日当空，干裂的田地中，农夫们正弯腰劳作，疲惫与绝望写在他们的脸上。两位年迈的农夫坐在田埂边，满脸愁容，目光呆滞，似乎已被生活的重压压垮。", "场景"));
        dialogTexts.Add(new DialogData("(抬头望天叹息一声，满脸无奈)这天哪……赋税一年比一年重，徭役连年不断，田里的庄稼还没长好，就要被朝廷抽去修什么陵墓、宫殿，日子怎生是个尽头啊！", "农夫甲"));
        dialogTexts.Add(new DialogData("(用袖子擦去汗水，声音虚弱，透着疲态)是啊。徭役连连，田里的劳力都被征走了。就算地里再多下工夫，收成也是少得可怜。秦朝好大喜功，咱们这等小民也不过是任人驱使的牛马。", "农夫乙"));
        dialogTexts.Add(new DialogData("(小红听闻此言，心头一震，目光沉痛，悄然记下秦朝徭役严苛、赋税压人的情形。)", "场景"));

        DialogManager.Show(dialogTexts);

    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
