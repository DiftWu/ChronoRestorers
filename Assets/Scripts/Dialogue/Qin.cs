using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using System.IO;

public class Qin : MonoBehaviour
{
    public DialogManager DialogManager;
    public GameObject Dialog;
    public bool isActive = false;
 
    public GameObject[] Example;

    void Start()
    {
        Dialog.SetActive(false);
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
        if(isActive)
        {
            var dialogTexts = new List<DialogData>();
            var text = new DialogData("臣认为，称_______，合情合理。", "小蓝");
            text.SelectList.Add("Wrong", "A.秦王");
            text.SelectList.Add("Correct", "B.皇帝");
            text.SelectList.Add("Wrong", "C.皇");
            text.Callback = () => Check_Correct();

            dialogTexts.Add(new DialogData("秦宫大殿高耸巍峨，装饰奢华。秦始皇的威严笼罩整个殿堂。大臣们列队而立，气氛肃穆。小红和小蓝悄然穿越于此，隐于大臣之间，聆听关于治理国家的争论。", "场景", () => Show_Example(0)));
            dialogTexts.Add(new DialogData("（在小红和小蓝身后悄然现身，轻声说道）秦王嬴政，数十载谋划，终于一统天下。自二十五年起，他先灭韩，开战国之首，接着挥师东进，破赵于长平，击魏于大梁，强齐弱楚皆被陛下逐一瓦解。/color:yellow/六国皆望风而降，华夏终于一统。/color:white//size:init/此番议论非同小可，任何细微之失皆可动摇整个王朝的根基，务必仔细聆听。", "神秘人", () => Hide_Example(0)));
            dialogTexts.Add(new DialogData("（微微点头，神情专注，眼中闪过一丝紧张）", "小红"));
            dialogTexts.Add(new DialogData("（步前几步，神情庄重，语气中透着敬畏）陛下功德无量，平定六合，统一华夏，空前绝后，乃前古未有之伟业。‘秦王’之称，已不足以彰显陛下丰功伟绩。臣斗胆认为，陛下应另取尊称，以显其超凡之功。", "大臣甲"));
            dialogTexts.Add(new DialogData("（眉头微皱，语气恭敬却不无忧虑）臣以为，‘秦王’之称早已为天下所熟知，若骤然更改，恐徒生动荡。民心不稳，国基不固，陛下万望三思。", "大臣乙"));
            dialogTexts.Add(new DialogData("（目光扫过众臣）若仍称‘秦王’，岂不显得陛下功业与那些王侯无异？天下共尊，功业无双，既已超越古之三皇五帝，陛下理应效法古制，称‘皇’。‘皇’之名，方能匹配陛下所成伟业，昭告天下，陛下乃天命所归。", "大臣丙"));
            dialogTexts.Add(new DialogData("（缓缓抬眸，沉吟片刻，点头附和）丞相所言甚是。若仅称‘秦王’，确不足以彰显陛下之功。‘皇’字在前，加‘帝’字于后，称‘始皇帝’，方能真正彰显陛下之无上威名，前无古人，后无来者，万世共仰！", "大臣丁"));

            dialogTexts.Add(new DialogData("陛下的称号应为何？", "卫兵"));
            dialogTexts.Add(text);

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

    private void Check_Correct()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("（微微一笑）朕便从今日起称为‘皇帝’，以示天命在我！", "嬴政"));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        { 
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("（拔剑攻击）用此称呼，岂不贬低陛下之功？", "卫兵"));

            DialogManager.Show(dialogTexts);
        }
        else
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("Right. You don't have to get the answer."));

            DialogManager.Show(dialogTexts);
        }
    }
}
