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
        var dialogTexts_en = new List<DialogData>();

        var text1 = new DialogData("(思索后回答) ________________________。", "小红");
        text1.SelectList.Add("Wrong", "A.赋税减轻，徭役减少");
        text1.SelectList.Add("Correct", "B.赋税沉重，徭役连年不断");
        text1.SelectList.Add("Wrong", "C.没有赋税和徭役，民众生活安逸");
        text1.SelectList.Add("Wrong", "D.赋税与徭役只在部分地区推行");
        text1.Callback = () => Check_Correct1();

        var text1_en = new DialogData("(After thinking) ________________________.", "Xiao Hong");
        text1_en.SelectList.Add("Wrong", "A. Taxes reduced, corvée labor decreased");
        text1_en.SelectList.Add("Correct", "B. Heavy taxes and continuous corvée labor");
        text1_en.SelectList.Add("Wrong", "C. No taxes or labor, people lived comfortably");
        text1_en.SelectList.Add("Wrong", "D. Taxes and labor only implemented in some regions");
        text1_en.Callback = () => Check_Correct1();

        var text2 = new DialogData("民众稍有不慎即________，一人犯法，_______都要受到牵连。", "小蓝");
        text2.SelectList.Add("Wrong", "A.秦王");
        text2.SelectList.Add("Correct", "B.触犯法律；亲属和邻里");
        text2.SelectList.Add("Wrong", "C.皇");
        text2.Callback = () => Check_Correct2();

        var text2_en = new DialogData("If people make the slightest mistake, they ________. When one person breaks the law, ________ are also implicated.", "Xiao Lan");
        text2_en.SelectList.Add("Wrong", "A. Qin Wang");
        text2_en.SelectList.Add("Correct", "B. violate the law; relatives and neighbors");
        text2_en.SelectList.Add("Wrong", "C. Emperor");
        text2_en.Callback = () => Check_Correct2();

        var text3 = new DialogData("包括_____________________。", "小蓝");
        text3.SelectList.Add("Wrong", "A.禁锢、流放");
        text3.SelectList.Add("Correct", "B.肢体残害、车裂、腰斩、活埋等多种死刑");
        text3.SelectList.Add("Wrong", "C.剥夺财产");
        text3.SelectList.Add("Wrong", "D.流放海外");
        text3.Callback = () => Check_Correct3();

        var text3_en = new DialogData("Including _____________________.", "Xiao Lan");
        text3_en.SelectList.Add("Wrong", "A. Imprisonment, exile");
        text3_en.SelectList.Add("Correct", "B. Mutilation, dismemberment, waist-cutting, live burial and other executions");
        text3_en.SelectList.Add("Wrong", "C. Property confiscation");
        text3_en.SelectList.Add("Wrong", "D. Overseas exile");
        text3_en.Callback = () => Check_Correct3();

        var text4 = new DialogData("秦始皇为禁锢思想，下令烧毁各国史书和民间收藏的诸子百家著作，仅留下秦国的史书及医药、种植、占卜之类的书籍，又将非议朝政的460多个儒生和方士全部坑杀。这叫做‘________’。", "小红");
        text4.SelectList.Add("Wrong", "A.秦王");
        text4.SelectList.Add("Correct", "焚书坑儒");
        text4.SelectList.Add("Wrong", "C.皇");
        text4.Callback = () => Check_Correct4();

        var text4_en = new DialogData("To control thought, Qin Shi Huang ordered the burning of historical records from other states and privately held works of various philosophers, preserving only Qin's histories and books on medicine, agriculture, and divination. He then buried alive 460+ scholars who criticized his policies. This was called '________'.", "Xiao Hong");
        text4_en.SelectList.Add("Wrong", "A. Qin Wang");
        text4_en.SelectList.Add("Correct", "Burning of Books and Burying of Scholars");
        text4_en.SelectList.Add("Wrong", "C. Emperor");
        text4_en.Callback = () => Check_Correct4();

        var text5 = new DialogData("秦二世继续修建庞大的工程，征调民力屯卫_____，还向郡县加征粮饷，使得赋役愈加沉重。", "小蓝");
        text5.SelectList.Add("Correct", "A.咸阳");
        text5.SelectList.Add("Wrong", "B.长安");
        text5.SelectList.Add("Wrong", "C.洛阳");
        text5.Callback = () => Check_Correct5();

        var text5_en = new DialogData("After Qin Shi Huang's death, Qin Ershi continued massive construction projects, conscripting laborers to garrison ________ while increasing grain levies, making taxes and labor even more oppressive.", "Xiao Lan");
        text5_en.SelectList.Add("Correct", "A. Xianyang");
        text5_en.SelectList.Add("Wrong", "B. Chang'an");
        text5_en.SelectList.Add("Wrong", "C. Luoyang");
        text5_en.Callback = () => Check_Correct5();

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

        dialogTexts_en.Add(new DialogData("Inside the tent, Chen Sheng and Wu Guang sat facing each other, surrounded by solemn garrison soldiers. On the table lay spread rice paper and writing brushes, the sound of rain tapping rhythmically. The tent was solemn, the silence thick with pre-dawn tension.", "Scene"));
        dialogTexts_en.Add(new DialogData("(Holding brush with determined gaze, speaking softly) This manifesto is crucial - it must expose Qin's tyranny to awaken the oppressed masses and unite hearts to overthrow the brutal Qin.", "Chen Sheng"));
        dialogTexts_en.Add(new DialogData("Qin's oppressive rule has lasted too long, with popular resentment boiling. Though the people suffer, they need a spark to ignite their fury - this manifesto shall be that spark.", "Wu Guang"));
        dialogTexts_en.Add(new DialogData("After hearing this, Chen Sheng took brush to paper, writing a manifesto concise yet powerful - each word bled with passion, hard as iron, sharp as blades.", "Scene"));
        dialogTexts_en.Add(new DialogData("After Qin's establishment, how were taxes and corvée labor imposed on peasants?", "Wu Guang"));
        dialogTexts_en.Add(text1_en);
        dialogTexts_en.Add(new DialogData("How severe were Qin's laws?", "Chen Sheng"));
        dialogTexts_en.Add(text2_en);
        dialogTexts_en.Add(new DialogData("What extremely cruel punishments were implemented during Qin?", "Wu Guang"));
        dialogTexts_en.Add(text3_en);
        dialogTexts_en.Add(new DialogData("What measures did Qin Shi Huang take to control thought?", "Chen Sheng"));
        dialogTexts_en.Add(text4_en);
        dialogTexts_en.Add(new DialogData("After Qin Shi Huang's death, his successor Qin Ershi oppressed the people even more cruelly.", "Wu Guang"));
        dialogTexts_en.Add(text5_en);
        dialogTexts_en.Add(new DialogData("(Reading manifesto aloud) Qin's tyrannical rule imposes harsh laws everywhere. Heavy taxes and endless corvée labor leave no life for the people. The state has fallen, the realm is in turmoil, the people suffer with grievances everywhere. Qin's cruel laws bind people like ropes, disregarding lives. Burning books and burying scholars shackles thought - the wise dare not speak, the people have nowhere to voice pain. The ruler's megalomania builds palaces and tombs, exhausting the nation's strength. People toil like beasts of burden with no hope of release. If this can be tolerated, what cannot?", "Wu Guang"));
        dialogTexts_en.Add(new DialogData("Wu Guang's words, spoken with perfect clarity, shook every listener's heart. The soldiers in the tent burned with passion, flames of rebellion kindling in their eyes.", "Scene"));
        dialogTexts_en.Add(new DialogData("(Adding more fervently) Now heaven's mandate has shifted, popular resentment boils over! We raise our farming tools as weapons, lift poles as banners, and rebel against brutal Qin! We champion justice to destroy tyrannical Qin! Let all who share our cause raise righteous banners to overthrow cruel Qin! A true man dies but once - let our deaths bring glory! The people make me their king - the Zhang Chu regime is born! All who refuse to kneel to oppression, join us in Zhang Chu to fight for justice!", "Chen Sheng"));
        dialogTexts_en.Add(new DialogData("(Chanting in unison, voices strong with determination) We'll cut wood for weapons, raise poles as banners, and fight Qin to the death!", "Soldiers"));

        if (DataManager.Instance.playerData.usingEnglish)
        {
            DialogManager.Show(dialogTexts_en);
        }
        else
        {
            DialogManager.Show(dialogTexts);
        }
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
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("(赞许地说道) 不错！赋税沉重，徭役连年，百姓不堪重负，这才是引发民怨沸腾的根源！", "陈胜"));
            dialogTexts_en.Add(new DialogData("(Praising) Correct! Heavy taxes and endless corvée labor crushed the people - this is why resentment boils over!", "Chen Sheng"));

            if (DataManager.Instance.playerData.usingEnglish)
            {
                DialogManager.Show(dialogTexts_en);
            }
            else
            {
                DialogManager.Show(dialogTexts);
            }
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("(摇头，语气中带着愤懑) 赋税沉重、徭役繁多，哪里有民众安逸的日子？秦朝的压迫让百姓苦不堪言！", "吴广"));
            dialogTexts_en.Add(new DialogData("(Shaking head angrily) Where was this comfort you speak of? Qin's oppression left people destitute!", "Wu Guang"));

            if (DataManager.Instance.playerData.usingEnglish)
            {
                DialogManager.Show(dialogTexts_en);
            }
            else
            {
                DialogManager.Show(dialogTexts);
            }
        }
    }

    private void Check_Correct2()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("(点头肯定，语气愤怒) 对，秦朝的苛法让百姓如履薄冰，稍有过失，亲族邻里都要受到牵连，生死一线。", "陈胜"));
            dialogTexts_en.Add(new DialogData("(Nodding grimly) Yes! Qin's laws made people walk on thin ice - one misstep implicated entire families!", "Chen Sheng"));

            if (DataManager.Instance.playerData.usingEnglish)
            {
                DialogManager.Show(dialogTexts_en);
            }
            else
            {
                DialogManager.Show(dialogTexts);
            }
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("(皱眉，神情严肃) 不只是个别人的惩罚，秦法无情，亲属和邻里皆要陪葬。这样的暴政，怎能不让天下百姓反抗？", "吴广"));
            dialogTexts_en.Add(new DialogData("(Frowning seriously) It's not just individual punishment - Qin's laws are merciless, implicating entire families. How can such tyranny not provoke rebellion?", "Wu Guang"));

            if (DataManager.Instance.playerData.usingEnglish)
            {
                DialogManager.Show(dialogTexts_en);
            }
            else
            {
                DialogManager.Show(dialogTexts);
            }
        }
    }

    private void Check_Correct3()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("(重重地点头) 没错！秦朝施行的刑罚残酷至极，百姓无一能幸免，这样的暴政必会引发天下反抗！", "陈胜"));
            dialogTexts_en.Add(new DialogData("(Nodding heavily) Exactly! The punishments of Qin are extremely cruel, with no one escaping - such tyranny will surely provoke rebellion!", "Chen Sheng"));

            if (DataManager.Instance.playerData.usingEnglish)
            {
                DialogManager.Show(dialogTexts_en);
            }
            else
            {
                DialogManager.Show(dialogTexts);
            }
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("(摇头叹息) 流放和剥夺财产？那只是表面。秦朝的刑罚残酷至极，肢体残害，百姓的生命宛如草芥，秦政苛暴，怎不引来民众起义！", "吴广"));
            dialogTexts_en.Add(new DialogData("(Shaking head) Exile and property confiscation? That's just the surface. Qin's punishments are extremely cruel - the people's lives are like grass, and such tyranny will surely provoke rebellion!", "Wu Guang"));

            if (DataManager.Instance.playerData.usingEnglish)
            {
                DialogManager.Show(dialogTexts_en);
            }
            else
            {
                DialogManager.Show(dialogTexts);
            }
        }
    }

    private void Check_Correct4()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("(眼中闪烁愤怒之色) 正是焚书坑儒！秦始皇不仅用刑罚镇压百姓，还用思想禁锢，焚毁书籍，杀害儒生，彻底封锁百姓的心智。", "陈胜"));
            dialogTexts_en.Add(new DialogData("(Eyes flashing with anger) Exactly! Burning books and burying scholars! Qin Shi Huang not only used punishment to suppress the people but also imprisoned thought, burning books and killing scholars to completely seal the people's minds.", "Chen Sheng"));

            if (DataManager.Instance.playerData.usingEnglish)
            {
                DialogManager.Show(dialogTexts_en);
            }
            else
            {
                DialogManager.Show(dialogTexts);
            }
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("(语气冷峻) 如此残酷手段，让百姓不敢言不敢问，思想被禁锢，学者被杀，这便是秦朝暴政的其中一环。", "吴广"));
            dialogTexts_en.Add(new DialogData("(Coldly) Such cruel methods made the people afraid to speak or ask, their thoughts shackled, and scholars killed - this is one aspect of Qin's tyranny.", "Wu Guang"));

            if (DataManager.Instance.playerData.usingEnglish)
            {
                DialogManager.Show(dialogTexts_en);
            }
            else
            {
                DialogManager.Show(dialogTexts);
            }
        }
    }

    private void Check_Correct5()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("(声音低沉而冷静) 秦二世凶残暴虐，征调百姓为咸阳筑城，还加征粮饷，使百姓生活更加艰难。", "陈胜"));
            dialogTexts_en.Add(new DialogData("(Voice low and calm) Qin Ershi is cruel and tyrannical, conscripting people to build Xianyang and increasing grain levies, making life even harder for the people.", "Chen Sheng"));

            if (DataManager.Instance.playerData.usingEnglish)
            {
                DialogManager.Show(dialogTexts_en);
            }
            else
            {
                DialogManager.Show(dialogTexts);
            }
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("(愤怒地摇头) 不是长安，也不是洛阳。秦二世的暴政体现在咸阳的庞大工程上，百姓被强迫为他营建，生死皆掌控在暴政之手。", "吴广"));
            dialogTexts_en.Add(new DialogData("(Angrily) Not Chang'an! Qin Ershi's projects in Xianyang enslaved thousands!", "Wu Guang"));

            if (DataManager.Instance.playerData.usingEnglish)
            {
                DialogManager.Show(dialogTexts_en);
            }
            else
            {
                DialogManager.Show(dialogTexts);
            }
        }
    }
}
