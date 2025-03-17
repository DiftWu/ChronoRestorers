using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using System.IO;

public class Qin : MonoBehaviour
{
    public DialogManager DialogManager;
    public GameObject Final;
    public GameObject NextChapter;
    public bool isActive1 = false;
    public bool isActive2 = false;
    public bool isActive3 = false;
    public bool isActive4 = false;
    public bool isActive5 = false;
    public bool beenActive1 = false;
    public bool beenActive2 = false;
    public bool beenActive3 = false;
    public bool beenActive4 = false;
    public bool beenActive5 = false;
    public GameObject[] Example;
    private int isfirst;

    private void Start()
    {
        Final.SetActive(false);
        NextChapter.SetActive(false);
        if (PlayerPrefs.HasKey("isFirst"))
        {
            isfirst = PlayerPrefs.GetInt("isFirst");
        }
        else
        {
            isfirst = 0;
            PlayerPrefs.SetInt("isFirst", 0);
        }

    }

    private void Update()
    {
        Awake();
    }

    public void Show1()
    {
        isActive1 = true;
    }
    
    public void Show2()
    {
        isActive2 = true;
    }
    
    public void Show3()
    {
        isActive3 = true;
    }
    
    public void Show4()
    {
        isActive4 = true;
    }
    
    public void Show5()
    {
        isActive5 = true;
    }

    private void Awake()
    {
        var dialogTexts0 = new List<DialogData>();
        dialogTexts0.Add(new DialogData("接下来，我将为你介绍游戏的基本功能和玩法", "神秘人"));
        dialogTexts0.Add(new DialogData("首先，游戏的基本形式是通过对话获取知识", "神秘人", () => Show_Example(0)));
        dialogTexts0.Add(new DialogData("你需要在场景里找到相关的人物或者物件，触发对话或小游戏", "神秘人", () => Hide_Example(0)));
        dialogTexts0.Add(new DialogData("对话或者游戏过程中，你需要仔细阅读对话，获得相应的知识", "神秘人"));
        dialogTexts0.Add(new DialogData("在了解知识的时候，如果你觉得某些知识点十分重要，你可以打开笔记本记录下重要的知识", "神秘人", () => Show_Example(1)));
        dialogTexts0.Add(new DialogData("点击史官按钮，你将有三个选项，分别是智能史官、知识回顾以及笔记本", "神秘人", () => Hide_Example(1)));
        dialogTexts0.Add(new DialogData("点击笔记本，你可以将你觉得重要的知识记录在笔记本中，以便随时查看", "神秘人", () => Show_Example(2)));
        dialogTexts0.Add(new DialogData("你可以在输入框输入知识点，也可以点击话筒，通过语音输入相应的知识点，这样有助于你更好地记忆知识内容", "神秘人", () => Hide_Example(2)));
        dialogTexts0.Add(new DialogData("此外，你可以在任意界面点击键盘上的N键来打开笔记本", "神秘人", () => Show_Example(3)));
        dialogTexts0.Add(new DialogData("除了笔记本功能，还有智能史官功能，你可以向它询问任何有关的历史问题，它一定会给你一个满意的回答", "神秘人", () => Hide_Example(3)));
        dialogTexts0.Add(new DialogData("最后，如果你想检验自己对于知识点的掌握情况或者想要巩固自己的知识，知识回顾是一个很好的选择", "神秘人", () => Show_Example(4)));
        dialogTexts0.Add(new DialogData("它包含着这一整章的知识点，并且每次将随机给出题目，帮助你更好地了解自己对于知识的掌握情况", "神秘人", () => Hide_Example(4)));
        dialogTexts0.Add(new DialogData("接下来，请尽情享受你的游戏吧，但永远不要忘记你的使命——获取更多的知识，将历史推向它本该前进的方向！", "神秘人"));
    
        var dialogTexts1 = new List<DialogData>();
        dialogTexts1.Add(new DialogData("秦宫大殿高耸巍峨，装饰奢华。秦始皇的威严笼罩整个殿堂。大臣们列队而立，气氛肃穆。小红和小蓝悄然穿越于此，隐于大臣之间，聆听关于治理国家的争论。", "场景", () => Show_Example(5)));
        dialogTexts1.Add(new DialogData("（在小红和小蓝身后悄然现身，轻声说道）秦王嬴政，数十载谋划，终于一统天下。自二十五年起，他先灭韩，开战国之首，接着挥师东进，破赵于长平，击魏于大梁，强齐弱楚皆被陛下逐一瓦解。/color:yellow/六国皆望风而降，华夏终于一统。/color:white//size:init/此番议论非同小可，任何细微之失皆可动摇整个王朝的根基，务必仔细聆听。", "神秘人", () => Hide_Example(5)));
        dialogTexts1.Add(new DialogData("（微微点头，神情专注，眼中闪过一丝紧张）", "小红"));
        dialogTexts1.Add(new DialogData("（步前几步，神情庄重，语气中透着敬畏）陛下功德无量，平定六合，统一华夏，空前绝后，乃前古未有之伟业。‘秦王’之称，已不足以彰显陛下丰功伟绩。臣斗胆认为，陛下应另取尊称，以显其超凡之功。", "大臣甲"));
        dialogTexts1.Add(new DialogData("（眉头微皱，语气恭敬却不无忧虑）臣以为，‘秦王’之称早已为天下所熟知，若骤然更改，恐徒生动荡。民心不稳，国基不固，陛下万望三思。", "大臣乙"));
        dialogTexts1.Add(new DialogData("（目光扫过众臣）若仍称‘秦王’，岂不显得陛下功业与那些王侯无异？天下共尊，功业无双，既已超越古之三皇五帝，陛下理应效法古制，称‘皇’。‘皇’之名，方能匹配陛下所成伟业，昭告天下，陛下乃天命所归。", "大臣丙"));
        dialogTexts1.Add(new DialogData("（缓缓抬眸，沉吟片刻，点头附和）丞相所言甚是。若仅称‘秦王’，确不足以彰显陛下之功。‘皇’字在前，加‘帝’字于后，称‘始皇帝’，方能真正彰显陛下之无上威名，前无古人，后无来者，万世共仰！", "大臣丁"));

        var dialogTexts2 = new List<DialogData>();
        dialogTexts2.Add(new DialogData("（微微躬身，语气谨慎，眉头紧锁）如今天下初定，国土广袤，事务繁多。若事事皆由亲躬，恐怕政务积压，国事难以顺遂。", "大臣甲"));
        dialogTexts2.Add(new DialogData("（冷笑一声，步前一步）陛下乃天命所归，统一六国，威震四方。岂能将政务轻易交由他人？若诸事皆托臣子处理，陛下之威将受削，朝廷内部也将纷争频起。大人这番言论，莫非是有心觊觎权柄、意图谋权篡位？", "大臣乙"));
        dialogTexts2.Add(new DialogData("（脸色骤变，神情仓皇，低头退下，不敢再言）", "大臣甲"));
        dialogTexts2.Add(new DialogData("（其他大臣神情紧张）", "场景"));
        dialogTexts2.Add(new DialogData("（神色微变，见此情景，略显犹疑，随后缓缓开口）方才大人所言，虽有欠妥之处，但国事繁忙确是实情。若无合理分派，朝政必然阻滞，影响国之大计。微臣斗胆……或许，陛下可任命几位亲信大臣，分管地方事务，以减轻中央负担……", "大臣丙"));
        dialogTexts2.Add(new DialogData("（暗中对小红和小蓝悄声低语）此人所提，正是分封制的变形。分封制乃周天子行之旧制，诸侯各自割据，终成覆灭之因。若今日再行分封，秦国将步入同样的危机。", "神秘人"));
        dialogTexts2.Add(new DialogData("（大步上前，冷眼扫视大臣丙）大人此言，未免太过草率。当年周天子行分封制，各诸侯拥兵自重，终成大祸。地方坐大，中央衰弱，岂是我大秦所能承受？大人胆敢言及前朝旧制，莫不是对陛下不敬？", "大臣乙"));
        dialogTexts2.Add(new DialogData("（深吸一口气，向大臣乙一拜，接着说道）分封制不可行，臣万不敢冒此大不韪。然朝政繁重，臣以为，若中央不设官员分理各项事务，怕是亦难长治久安。为此，微臣斗胆提议——设三公以分掌政务、军事与监察。丞相掌政，太尉掌兵，御史大夫则监察百官。如此，虽有分工，然所有事务终归陛下裁决，国权自不会旁落。", "大臣丙"));
        dialogTexts2.Add(new DialogData("（听闻此言，眼中一亮，缓缓站出，重新加入讨论，声音中透着隐隐的激动）陛下，朝廷事务繁杂，三公恐亦难应对。臣斗胆进言，建议再设九卿，分掌刑法、礼仪、财政等细务，如此方能使政务有序，陛下亦得以从容应对国家大事，专注于更为宏大的国策。不过……三公九卿，分工明确，确是治理中央的良策，然地方事务亦不容小觑。臣以为，地方制度亦当随之更改。", "大臣甲"));
        dialogTexts2.Add(new DialogData("（闻言颔首）可废分封而设郡县。将天下分为三十六郡，每郡设郡守，郡下设县，县令皆由朝廷直接任命。如此，中央得以牢控地方，政治、法律、军事、土地、赋役等制度皆可由中央推行至每一处地方，彻底消除地方自立之患。天下大治，必赖此策。", "大臣丁")); 

        var dialogTexts3 = new List<DialogData>();
        dialogTexts3.Add(new DialogData("（语气平缓）中央地方之管理策略虽已敲定，但各地语言文字多有不同。六国官员用各自的文字书写，读写繁难，沟通不便，时常因字义不通引发误解。臣以为，若要政令畅通，或应统一文字，皆以秦小篆为标准。", "大臣甲"));
        dialogTexts3.Add(new DialogData("（眉头微皱，朝向嬴政）此策虽好，然小篆繁复难懂，六国百姓多不熟悉，若强行推行，恐生怨怼。万不可操之过急。", "大臣乙"));
        dialogTexts3.Add(new DialogData("（缓缓鞠躬，回答道）若各国仍用旧文字，中央政令如何贯彻？臣以为，小篆规整清晰，百姓虽初不熟悉，但朝廷若加以教化，定能逐渐推行。", "大臣甲"));
        dialogTexts3.Add(new DialogData("（顺势接话）不仅是文字，度量衡亦应统一。各地标准不一，纠纷频发，若要富国强兵，统一度量衡乃首要之策。", "大臣丙"));
        dialogTexts3.Add(new DialogData("（稍作停顿，继续说道）度量衡之议，的确不可不为。但此事不易，需先从中央推行，再逐渐向地方推广。如此，或能渐次推行，避免仓促行事反生不便。若再加统一货币，以秦制圆形方孔半两钱为准，经济发展方可无碍。", "大臣甲"));
        dialogTexts3.Add(new DialogData("（语气中透着几分坚定）事到如今，政令应当果决，只有统一，方能长治久安。六国道路车轨宽窄不一，行路艰难，商贾亦多有不便。若能统一车轨，修路便捷，商旅往来方可畅通。", "大臣丁"));

        var dialogTexts4 = new List<DialogData>();
        dialogTexts4.Add(new DialogData("（神色庄重）六国既定，然南方的岭南地区，地形险恶，山林茂密。当地蛮夷之民桀骜不驯，若不加以征服，恐有后患。只想宜派重兵，南征岭南，彻底平定南方。", "大臣甲"));
        dialogTexts4.Add(new DialogData("（语气中带着谨慎）南方蛮夷虽不曾归附，然远离中央，是否可先行招抚，缓而图之？若轻启战端，恐难收其果。", "大臣乙"));
        dialogTexts4.Add(new DialogData("（面露坚决，神情笃然）大人此言未免过于谨慎。若能平定南方，再设郡县，便可打通南北交通，富国强兵。此战虽难，然得岭南，天下自定！", "大臣甲"));
        dialogTexts4.Add(new DialogData("（微微躬身）若要出兵岭南，恐需更多兵力调配。然北方匈奴频频犯边，蒙恬大将军虽镇守北疆，然匈奴素来狡诈，是否需多加防备，以免两线作战，后方失守？", "大臣乙"));
        dialogTexts4.Add(new DialogData("（点头同意，语气中透着几分担忧）正是如此。北方匈奴来去无踪，常扰我边境。若不加以防备，恐大军南征之时，北疆有失。应于北方修筑长城，凭山河之险，以固我边防。如此一来，凭山河之险，北疆固若金汤，我大秦之兵也无须日夜巡边。如此，北可御匈奴，南可征岭南，一举两得。\r\n", "大臣丙"));

        var dialogTexts5 = new List<DialogData>();
        dialogTexts5.Add(new DialogData("秦宫大殿安静肃穆，嬴政步入，目光如炬，众大臣肃然起敬。小红和小蓝站在大臣之间", "场景"));
        dialogTexts5.Add(new DialogData("（目光威严）朕已有所疲乏，众爱卿们有谁说说今日所议之事的最终结果？", "嬴政"));
        dialogTexts5.Add(new DialogData("（大臣们互相对视，不敢轻易答复）", "场景"));
        dialogTexts5.Add(new DialogData("小红和小蓝站在大臣之间，准备向嬴政汇报他们从大臣对话中得出的结论。神秘人此刻站在阴影中，注视着他们。这时，卫兵持剑挡住两人。", "场景"));


        var text1 = new DialogData("臣认为，称_______，合情合理。", "小蓝");
        text1.SelectList.Add("Wrong", "A.秦王");
        text1.SelectList.Add("Correct", "B.皇帝");
        text1.SelectList.Add("Wrong", "C.皇");
        text1.Callback = () => Check_Correct1();

        var text2 = new DialogData("____________之制，是为上策。", "小蓝");
        text2.SelectList.Add("Wrong", "A.郡县制");
        text2.SelectList.Add("Correct", "B.三公九卿");
        text2.SelectList.Add("Wrong", "C.分封制");
        text2.Callback = () => Check_Correct2();

        var text3 = new DialogData("应全面废除_______，在全国范围内实行郡县制，由_______直接管辖。全国分为_____郡，在郡下设____。郡和县的长官都由____直接任免。这样，皇帝和朝廷就牢牢控制了全国各地的权力，并把政治、法律、军事、土地及赋役等制度推向全国。", "小蓝");
        text3.SelectList.Add("Wrong", "A.郡县制；中央；36；省；朝廷");
        text3.SelectList.Add("Correct", "B.分封制；中央；36；县；朝廷");
        text3.SelectList.Add("Wrong", "C.分封制；地方；30；省；朝廷");
        text3.Callback = () => Check_Correct3();

        var text4 = new DialogData("文字应以______为准，货币应以______为准。此外还应统一度量衡与交通车轨。");
        text4.SelectList.Add("Wrong", "A.秦小篆，方形方孔");
        text4.SelectList.Add("Wrong", "B.楚辞文，方形圆孔");
        text4.SelectList.Add("Correct", "C.秦小篆，圆形方孔");
        text4.SelectList.Add("Wrong", "D.六国文字混合体，方形圆孔");
        text4.Callback = () => Check_Correct4();

        var text5 = new DialogData("微臣以为，在岭南及东南沿海地区，设置____、_____、___各郡；在原有北方诸侯国长城的基础上，修筑西起______、东到_____的长城，使秦朝管辖的范围东至东海，西到陇西，北至长城一带，南达南海。", "小蓝");
        text5.SelectList.Add("Correct", "A.桂林；南海；象；临洮；辽东");
        text5.SelectList.Add("Wrong", "B.南海；桂林；临洮；象；辽东");
        text5.SelectList.Add("Wrong", "B.象；南海；临洮；辽东；桂林");
        text5.Callback = () => Check_Correct5();

        var dialogQuestions = new List<DialogData>();
        dialogQuestions.Add(new DialogData("陛下的称号应为何？", "卫兵"));
        dialogQuestions.Add(text1);
        dialogQuestions.Add(new DialogData("中央应行何种制度，以确保始皇帝之权威，减轻陛下国事负担？", "卫兵"));
        dialogQuestions.Add(text2);
        dialogQuestions.Add(new DialogData("地方所行之郡县制应当如何运作？", "卫兵"));
        dialogQuestions.Add(text3);
        dialogQuestions.Add(new DialogData("统一文字，我朝应当采用哪一种文字作为标准？统一货币，又该以何种样式为准？", "卫兵"));
        dialogQuestions.Add(text4);
        dialogQuestions.Add(new DialogData("为加强对边疆地区的开拓和经营，对南对北，可曾有何种策略？", "卫兵"));
        dialogQuestions.Add(text5);
        dialogQuestions.Add(new DialogData("（镇定地上前一步）陛下，臣与众大臣商议已定：陛下称为‘始皇帝’，设立三公九卿与郡县之制、统一文字度量衡、实行车同轨、书同文。此举可稳固大秦根基，确保万世基业。", "小红"));
        dialogQuestions.Add(new DialogData("秦朝建立的中央集权制度，使国家的一切权力都高度集中在中央政府，奠定了后世政治制度的框架，对以后历史的发展有着深远影响。", "神秘人"));
        dialogQuestions.Add(new DialogData("（沉默片刻，随后露出满意的微笑）很好，爱卿之策，深得朕心。如此，天下可安！", "嬴政"));

        if (isfirst == 0)
        {
            DialogManager.Show(dialogTexts0);
            PlayerPrefs.SetInt("isFirst", 1);
        }

        if (isActive1)
        {
            DialogManager.Show(dialogTexts1);
            isActive1 = false;
            beenActive1 = true;
        }

        if (isActive2)
        {
            DialogManager.Show(dialogTexts2);
            isActive2 = false;
            beenActive2 = true;
        }

        if (isActive3)
        {
            DialogManager.Show(dialogTexts3);
            isActive3 = false;
            beenActive3 = true;
        }

        if (isActive4)
        {
            DialogManager.Show(dialogTexts4);
            isActive4 = false;
            beenActive4 = true;
        }

        if (beenActive1 && beenActive2 && beenActive3 && beenActive4 && !beenActive5)
        {
            DialogManager.Show(dialogTexts5);
            Final.SetActive(true);
            beenActive5 = true;
        }

        if (isActive5)
        {
            DialogManager.Show(dialogQuestions);
            isActive5 = false;
            NextChapter.SetActive(true);
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

    private void Check_Correct1()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("（微微一笑）朕便从今日起称为‘皇帝’，以示天命在我！", "嬴政"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneRight++;
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("（拔剑攻击）用此称呼，岂不贬低陛下之功？", "卫兵"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneFalse++;
        }
    }

    private void Check_Correct2()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("（微微点头）好。便依此策，设三公九卿，朝政分工明晰，最终大权仍归朕手。你等务必谨守职分，莫要生出异心。", "嬴政"));
            dialogTexts.Add(new DialogData("（郑重行礼）陛下英明。臣愿随陛下之策，竭尽全力推行此制。", "众大臣"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneRight++;
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("（拔剑攻击）大人胆敢言及前朝旧制，莫不是对陛下不敬？", "卫兵"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneFalse++;
        }
    }

    private void Check_Correct3()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("（面露满意之色）地方事务，归于中央。尔等须谨记，天下已定，然若无规制，国亦将危。郡县制，乃安邦定国之本，务必全力推行！", "嬴政"));
            dialogTexts.Add(new DialogData("（轻声低语）在历史上，秦后将郡的数量增加至40余郡。郡县制的普遍推行，开创了此后我国历代王朝地方行政的基本模式。", "神秘人"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneRight++;
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("（拔剑攻击）大人对郡县制的施行尚不甚熟悉，如何为国之运行贡献助力？", "卫兵"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneFalse++;
        }
    }

    private void Check_Correct4()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("（目光如炬）嗯……书同文，车同轨，货币与度量衡皆统一，方能使天下真正统一。卿家之议，颇有见地。传令下去，命丞相李斯取大篆加以整理简化，制定笔画规整的小篆，作为全国通用文字。", "嬴政"));
            dialogTexts.Add(new DialogData("（轻声低语）文字的统一，使政令能够在全国各地顺利推行，也使不同地域的人们能够顺畅沟通，有利于文化的交流与发展。货币的统一，改变了以往币制混乱的状况，有利于国家对经济的管理，促进各地经济的交流。从秦朝开始，圆形方孔这一货币形制为历代王朝所沿用。度量衡的统一，促进了经济的发展。 而秦始皇下令统一车轨和道路的宽度，并修筑贯通全国的道路，形成了以咸阳为中心的全国交通网。", "神秘人"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneRight++;
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("（拔剑攻击）大人所言未遵我大秦之制，恐有违陛下威命，实在令人费解。", "卫兵"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneFalse++;
        }
    }

    private void Check_Correct5()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("（目光冷峻，语气威严）好！蒙恬将军已领大军北击匈奴，现须再建长城，以护北疆。我大秦江山稳固，南征北御，方能无忧。", "嬴政"));
            dialogTexts.Add(new DialogData("（躬身拜道，语气中满是钦佩与忠诚）陛下圣明。岭南若得，必可开拓疆土；长城若建，北方无忧。臣等必竭尽全力，助陛下成此伟业！", "众大臣"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneRight++;
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("（拔剑攻击）大人竟对国之疆域尚不了解，此番策略恐误国！", "卫兵"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneFalse++;
        }
    }
}
