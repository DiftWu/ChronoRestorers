using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Tent : MonoBehaviour
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
        var dialogTexts = new List<DialogData>();
        var text1 = new DialogData("(思索后回答) ________________________。", "小红");
        text1.SelectList.Add("Wrong", "A.赋税减轻，徭役减少");
        text1.SelectList.Add("Correct", "B.赋税沉重，徭役连年不断");
        text1.SelectList.Add("Wrong", "C.没有赋税和徭役，民众生活安逸");
        text1.SelectList.Add("Wrong", "D.赋税与徭役只在部分地区推行");
        text1.Callback = () => Check_Correct1();

        var text2 = new DialogData("民众稍有不慎即________，一人犯法，_______都要受到牵连。", "小蓝");
        //text2.SelectList.Add("Wrong", "A.秦王");
        text2.SelectList.Add("Correct", "B.触犯法律；亲属和邻里");
        //text2.SelectList.Add("Wrong", "C.皇");
        text2.Callback = () => Check_Correct2();

        var text3 = new DialogData("包括_____________________。", "小蓝");
        text3.SelectList.Add("Wrong", "A.禁锢、流放");
        text3.SelectList.Add("Correct", "B.肢体残害、车裂、腰斩、活埋等多种死刑");
        text3.SelectList.Add("Wrong", "C.剥夺财产");
        text3.SelectList.Add("Wrong", "D.流放海外");
        text3.Callback = () => Check_Correct3();

        var text4 = new DialogData("秦始皇为禁锢思想，下令烧毁各国史书和民间收藏的诸子百家著作，仅留下秦国的史书及医药、种植、占卜之类的书籍，又将非议朝政的460多个儒生和方士全部坑杀。这叫做‘________’。", "小红");
        //text3.SelectList.Add("Wrong", "A.秦王");
        text3.SelectList.Add("Correct", "焚书坑儒");
        //text3.SelectList.Add("Wrong", "C.皇");
        text3.Callback = () => Check_Correct4();

        var text5 = new DialogData("秦二世继续修建庞大的工程，征调民力屯卫_____，还向郡县加征粮饷，使得赋役愈加沉重。", "小蓝");
        text5.SelectList.Add("Correct", "A.咸阳");
        text5.SelectList.Add("Wrong", "B.长安");
        text5.SelectList.Add("Wrong", "C.洛阳");
        text5.Callback = () => Check_Correct5();

        dialogTexts.Add(new DialogData("营帐内，陈胜与吴广对坐，戍卒们环绕四周，气氛凝重。檄文桌上铺开宣纸，摆放着笔墨，雨声滴答作响，帐内肃穆，沉寂中蕴含着破晓前的压抑。", "场景"));
        dialogTexts.Add(new DialogData("(握着毛笔，目光坚定，低声说道) 此檄文非同小可，须将秦朝暴政昭告天下，唤醒被压迫的百姓，方能凝聚众心，推翻暴秦。", "陈胜"));
        dialogTexts.Add(new DialogData("秦朝苛政已久，民怨沸腾。百姓虽受苦难，然需一把火点燃其怒火，檄文正是这火种。”", "吴广"));
        dialogTexts.Add(new DialogData("听罢，陈胜提笔在纸上写下檄文，言辞简洁而有力，字字泣血，如铁如刀。", "场景"));
        dialogTexts.Add(new DialogData("秦朝建立后，向农民征收的赋税和徭役如何？", "吴广"));
        dialogTexts.Add(text1);
        dialogTexts.Add(new DialogData("秦朝的法律如何严苛？", "陈胜"));
        dialogTexts.Add(text2);
        dialogTexts.Add(new DialogData("秦朝时期施行了哪些极其残酷的刑罚？", "吴广"));     
        dialogTexts.Add(text3);
        dialogTexts.Add(new DialogData("秦始皇为了控制思想，采取了哪些措施？", "陈胜"));
        dialogTexts.Add(text4);
        dialogTexts.Add(new DialogData("秦始皇死后，继位的秦二世对民众的压迫更为残酷。", "吴广"));
        dialogTexts.Add(text5);
        dialogTexts.Add(new DialogData("(朗声诵读檄文) 秦朝暴政，苛法遍施。赋税沉重，徭役连年，民不聊生。社稷已亡，天下动荡，百姓苦痛，怨声载道。秦法残酷，律法如绳索缠身，罔顾民命。焚书坑儒，禁锢思想，令天下智者口不能言，百姓苦无所诉。君主好大喜功，筑宫殿、建陵墓，耗尽国力。民众困于劳役，若牛马之命，至死不得解脱。是可忍，孰不可忍！", "吴广"));
        dialogTexts.Add(new DialogData("吴广一字一句，声声震撼人心，帐中众戍卒听得热血沸腾，眼中燃起熊熊烈火。", "场景"));
        dialogTexts.Add(new DialogData("(接着补充，言辞更为激昂) 今，天命有归，民怨沸腾，吾等揭竿而起，反抗暴秦！举大义，诛暴秦！愿天下同仁，共举义旗，推翻残暴之秦！壮士不死即已，死则扬名！民众拥我为王，张楚政权已立。不愿屈膝于苛政下者，皆可来我张楚，共谋大义！", "陈胜"));
        dialogTexts.Add(new DialogData("(齐声应和，声音洪亮，充满决心) 斩木为兵，揭竿为旗，誓与暴秦决一死战！", "戍卒们"));

        DialogManager.Show(dialogTexts);
        isActive = false;
    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }

    private void Check_Correct1()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(赞许地说道) 不错！赋税沉重，徭役连年，百姓不堪重负，这才是引发民怨沸腾的根源！", "陈胜"));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(摇头，语气中带着愤懑) 赋税沉重、徭役繁多，哪里有民众安逸的日子？秦朝的压迫让百姓苦不堪言！", "吴广"));

            DialogManager.Show(dialogTexts);
        }
    }

    private void Check_Correct2()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(点头肯定，语气愤怒) 对，秦朝的苛法让百姓如履薄冰，稍有过失，亲族邻里都要受到牵连，生死一线。", "陈胜"));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(皱眉，神情严肃) 不只是个别人的惩罚，秦法无情，亲属和邻里皆要陪葬。这样的暴政，怎能不让天下百姓反抗？", "吴广"));

            DialogManager.Show(dialogTexts);
        }
    }

    private void Check_Correct3()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(重重地点头) 没错！秦朝施行的刑罚残酷至极，百姓无一能幸免，这样的暴政必会引发天下反抗！", "陈胜"));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(摇头叹息) 流放和剥夺财产？那只是表面。秦朝的刑罚残酷至极，肢体残害，百姓的生命宛如草芥，秦政苛暴，怎不引来民众起义！", "吴广"));

            DialogManager.Show(dialogTexts);
        }
    }

    private void Check_Correct4()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(眼中闪烁愤怒之色) 正是焚书坑儒！秦始皇不仅用刑罚镇压百姓，还用思想禁锢，焚毁书籍，杀害儒生，彻底封锁百姓的心智。", "陈胜"));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(语气冷峻) 如此残酷手段，让百姓不敢言不敢问，思想被禁锢，学者被杀，这便是秦朝暴政的其中一环。", "吴广"));

            DialogManager.Show(dialogTexts);
        }
    }

    private void Check_Correct5()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(声音低沉而冷静) 秦二世凶残暴虐，征调百姓为咸阳筑城，还加征粮饷，使百姓生活更加艰难。", "陈胜"));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(愤怒地摇头) 不是长安，也不是洛阳。秦二世的暴政体现在咸阳的庞大工程上，百姓被强迫为他营建，生死皆掌控在暴政之手。", "吴广"));

            DialogManager.Show(dialogTexts);
        }
    }
}
