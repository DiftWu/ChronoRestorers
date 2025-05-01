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
        dialogTexts0.Add(new DialogData("���������ҽ�Ϊ�������Ϸ�Ļ������ܺ��淨", "������"));
        dialogTexts0.Add(new DialogData("���ȣ���Ϸ�Ļ�����ʽ��ͨ���Ի���ȡ֪ʶ", "������", () => Show_Example(0)));
        dialogTexts0.Add(new DialogData("����Ҫ�ڳ������ҵ���ص������������������Ի���С��Ϸ", "������", () => Hide_Example(0)));
        dialogTexts0.Add(new DialogData("�Ի�������Ϸ�����У�����Ҫ��ϸ�Ķ��Ի��������Ӧ��֪ʶ", "������"));
        dialogTexts0.Add(new DialogData("���˽�֪ʶ��ʱ����������ĳЩ֪ʶ��ʮ����Ҫ������Դ򿪱ʼǱ���¼����Ҫ��֪ʶ", "������", () => Show_Example(1)));
        dialogTexts0.Add(new DialogData("���ʷ�ٰ�ť���㽫������ѡ��ֱ�������ʷ�١�֪ʶ�ع��Լ��ʼǱ�", "������", () => Hide_Example(1)));
        dialogTexts0.Add(new DialogData("����ʼǱ�������Խ��������Ҫ��֪ʶ��¼�ڱʼǱ��У��Ա���ʱ�鿴", "������", () => Show_Example(2)));
        dialogTexts0.Add(new DialogData("����������������֪ʶ�㣬Ҳ���Ե����Ͳ��ͨ������������Ӧ��֪ʶ�㣬��������������õؼ���֪ʶ����", "������", () => Hide_Example(2)));
        dialogTexts0.Add(new DialogData("���⣬���������������������ϵ�N�����򿪱ʼǱ�", "������", () => Show_Example(3)));
        dialogTexts0.Add(new DialogData("���˱ʼǱ����ܣ���������ʷ�ٹ��ܣ����������ѯ���κ��йص���ʷ���⣬��һ�������һ������Ļش�", "������", () => Hide_Example(3)));
        dialogTexts0.Add(new DialogData("��������������Լ�����֪ʶ����������������Ҫ�����Լ���֪ʶ��֪ʶ�ع���һ���ܺõ�ѡ��", "������", () => Show_Example(4)));
        dialogTexts0.Add(new DialogData("����������һ���µ�֪ʶ�㣬����ÿ�ν����������Ŀ����������õ��˽��Լ�����֪ʶ���������", "������", () => Hide_Example(4)));
        dialogTexts0.Add(new DialogData("���������뾡�����������Ϸ�ɣ�����Զ��Ҫ�������ʹ��������ȡ�����֪ʶ������ʷ����������ǰ���ķ���", "������"));

        var dialogTexts0_en = new List<DialogData>();
        dialogTexts0_en.Add(new DialogData("Next, I will introduce you to the basic functions and gameplay of the game", "Mysterious Person"));
        dialogTexts0_en.Add(new DialogData("First, the basic form of the game is to acquire knowledge through dialogue", "Mysterious Person", () => Show_Example(0)));
        dialogTexts0_en.Add(new DialogData("You need to find relevant characters or objects in the scene to trigger dialogues or mini-games", "Mysterious Person", () => Hide_Example(0)));
        dialogTexts0_en.Add(new DialogData("During dialogues or games, you need to read carefully to gain corresponding knowledge", "Mysterious Person"));
        dialogTexts0_en.Add(new DialogData("While learning, if you find certain knowledge points particularly important, you can open the notebook to record them", "Mysterious Person", () => Show_Example(1)));
        dialogTexts0_en.Add(new DialogData("Click the Historian button, and you'll have three options: Smart Historian, Knowledge Review, and Notebook", "Mysterious Person", () => Hide_Example(1)));
        dialogTexts0_en.Add(new DialogData("Click the notebook to record important knowledge points for future reference", "Mysterious Person", () => Show_Example(2)));
        dialogTexts0_en.Add(new DialogData("You can type in the input box or click the microphone to input via voice, which helps you better memorize the content", "Mysterious Person", () => Hide_Example(2)));
        dialogTexts0_en.Add(new DialogData("Additionally, you can press the N key on your keyboard to open the notebook from any interface", "Mysterious Person", () => Show_Example(3)));
        dialogTexts0_en.Add(new DialogData("Besides the notebook, there's the Smart Historian feature where you can ask any historical questions and get satisfactory answers", "Mysterious Person", () => Hide_Example(3)));
        dialogTexts0_en.Add(new DialogData("Finally, if you want to test your knowledge or reinforce what you've learned, the Knowledge Review is a great option", "Mysterious Person", () => Show_Example(4)));
        dialogTexts0_en.Add(new DialogData("It contains all the knowledge points of this chapter and randomly generates questions to help you assess your understanding", "Mysterious Person", () => Hide_Example(4)));
        dialogTexts0_en.Add(new DialogData("Now, enjoy your game, but never forget your mission - to acquire more knowledge and push history in the direction it should go!", "Mysterious Person"));

        var dialogTexts1 = new List<DialogData>();
        dialogTexts1.Add(new DialogData("�ع�������Ρ�룬װ���ݻ�����ʼ�ʵ����������������á������жӶ������������¡�С���С����Ȼ��Խ�ڴˣ����ڴ�֮�䣬��������������ҵ����ۡ�", "����", () => Show_Example(5)));
        dialogTexts1.Add(new DialogData("����С���С�������Ȼ��������˵����������������ʮ��ı��������һͳ���¡��Զ�ʮ�����������𺫣���ս��֮�ף����Ż�ʦ�����������ڳ�ƽ����κ�ڴ�����ǿ�������Ա�������һ�߽⡣/color:yellow/�����������������������һͳ��/color:white//size:init/�˷����۷�ͬС�ɣ��κ�ϸ΢֮ʧ�Կɶ�ҡ���������ĸ����������ϸ������", "������", () => Hide_Example(5)));
        dialogTexts1.Add(new DialogData("��΢΢��ͷ������רע����������һ˿���ţ�", "С��"));
        dialogTexts1.Add(new DialogData("����ǰ����������ׯ�أ�������͸�ž�η�����¹���������ƽ�����ϣ�ͳһ���ģ���ǰ������ǰ��δ��֮ΰҵ����������֮�ƣ��Ѳ��������Ա��·Ṧΰ������������Ϊ������Ӧ��ȡ��ƣ������䳬��֮����", "�󳼼�"));
        dialogTexts1.Add(new DialogData("��üͷ΢�壬��������ȴ�������ǣ�����Ϊ����������֮������Ϊ��������֪������Ȼ���ģ���ͽ�����������Ĳ��ȣ��������̣�����������˼��", "����"));
        dialogTexts1.Add(new DialogData("��Ŀ��ɨ���ڳ������Գơ������������Եñ��¹�ҵ����Щ�������죿���¹��𣬹�ҵ��˫�����ѳ�Խ��֮������ۣ�������ӦЧ�����ƣ��ơ��ʡ������ʡ�֮��������ƥ���������ΰҵ���Ѹ����£��������������顣", "�󳼱�"));
        dialogTexts1.Add(new DialogData("������̧��������Ƭ�̣���ͷ���ͣ�ة���������ǡ������ơ���������ȷ���������Ա���֮�������ʡ�����ǰ���ӡ��ۡ����ں󣬳ơ�ʼ�ʵۡ��������������Ա���֮����������ǰ�޹��ˣ��������ߣ�����������", "�󳼶�"));

        var dialogTexts1_en = new List<DialogData>();
        dialogTexts1_en.Add(new DialogData("The Qin palace hall stands tall and majestic, luxuriously decorated. The majesty of Qin Shi Huang permeates the entire hall. Ministers stand in formation, creating a solemn atmosphere. Little Red and Little Blue quietly travel here, hiding among the ministers, listening to debates about governing the country.", "Scene", () => Show_Example(5)));
        dialogTexts1_en.Add(new DialogData("(Appearing quietly behind Little Red and Little Blue, whispering) King Ying Zheng of Qin, after decades of planning, has finally unified the world. Starting from his 25th year, he first conquered Han, the first of the Warring States, then marched east, defeated Zhao at Changping, attacked Wei at Daliang, and successively subdued the powerful Qi and weak Chu./color:yellow/All six states surrendered at the mere sight of his forces, and China was finally unified./color:white//size:init/This discussion is of great importance; any slight mistake could shake the foundation of the entire dynasty. Listen carefully.", "Mysterious Person", () => Hide_Example(5)));
        dialogTexts1_en.Add(new DialogData("(Nods slightly, with focused expression and a hint of nervousness in the eyes)", "Little Red"));
        dialogTexts1_en.Add(new DialogData("(Steps forward solemnly, with awe in the tone) Your Majesty's achievements are immeasurable, pacifying the world and unifying China, unprecedented and unmatched in history. The title 'King of Qin' is no longer sufficient to reflect Your Majesty's great accomplishments. I boldly suggest that Your Majesty adopt a new title to demonstrate these extraordinary achievements.", "Minister A"));
        dialogTexts1_en.Add(new DialogData("(Frowning slightly, respectful but concerned) I believe the title 'King of Qin' is already well-known throughout the land. Changing it abruptly may cause unnecessary turmoil. With unstable public sentiment and an unsteady state foundation, Your Majesty must consider carefully.", "Minister B"));
        dialogTexts1_en.Add(new DialogData("(Scanning the ministers) If we still call him 'King of Qin', wouldn't that make His Majesty's achievements seem no different from other lords? The world respects him, his accomplishments are unparalleled, having surpassed the ancient Three Sovereigns and Five Emperors. His Majesty should follow ancient tradition and be called 'Huang'. Only the title 'Huang' can match His Majesty's great achievements, declaring to the world that His Majesty is ordained by heaven.", "Minister C"));
        dialogTexts1_en.Add(new DialogData("(Slowly raising eyes, pondering, then nodding in agreement) The Prime Minister speaks wisely. Merely calling him 'King of Qin' indeed fails to reflect His Majesty's achievements. With 'Huang' first and 'Di' added after, calling him 'First Emperor' can truly demonstrate His Majesty's supreme prestige, unmatched by predecessors or successors, admired for generations!", "Minister D"));


        var dialogTexts2 = new List<DialogData>();
        dialogTexts2.Add(new DialogData("��΢΢��������������üͷ������������³����������������񷱶ࡣ�����½����׹������������ѹ����������˳�졣", "�󳼼�"));
        dialogTexts2.Add(new DialogData("����Цһ������ǰһ�����������������飬ͳһ�����������ķ������ܽ��������׽������ˣ������½��г��Ӵ�������֮������������͢�ڲ�Ҳ������Ƶ�𡣴����ⷬ���ۣ�Ī������������Ȩ������ͼıȨ��λ��", "����"));
        dialogTexts2.Add(new DialogData("����ɫ��䣬����ֻʣ���ͷ���£��������ԣ�", "�󳼼�"));
        dialogTexts2.Add(new DialogData("��������������ţ�", "����"));
        dialogTexts2.Add(new DialogData("����ɫ΢�䣬�����龰���������ɣ���󻺻����ڣ����Ŵ������ԣ�����Ƿ��֮���������·�æȷ��ʵ�顣���޺�����ɣ�������Ȼ���ͣ�Ӱ���֮��ơ�΢�����������������¿�������λ���Ŵ󳼣��ֹܵط������Լ������븺������", "�󳼱�"));
        dialogTexts2.Add(new DialogData("�����ж�С���С����������������ᣬ���Ƿַ��Ƶı��Ρ��ַ�������������֮���ƣ������Ը�ݣ��ճɸ���֮�����������зַ⣬�ع�������ͬ����Σ����", "������"));
        dialogTexts2.Add(new DialogData("������ǰ������ɨ�Ӵ󳼱������˴��ԣ�δ��̫�����ʡ������������зַ��ƣ������ӵ�����أ��ճɴ�����ط���������˥���������Ҵ������ܳ��ܣ����˵����Լ�ǰ�����ƣ�Ī���ǶԱ��²�����", "����"));
        dialogTexts2.Add(new DialogData("������һ�����������һ�ݣ�����˵�����ַ��Ʋ����У����򲻸�ð�˴�踡�Ȼ�������أ�����Ϊ�������벻���Ա������������������ѳ��ξð���Ϊ�ˣ�΢���������顪���������Է������񡢾������졣ة��������̫ξ�Ʊ�����ʷ�������ٹ١���ˣ����зֹ���Ȼ���������չ���²þ�����Ȩ�Բ������䡣", "�󳼱�"));
        dialogTexts2.Add(new DialogData("�����Ŵ��ԣ�����һ��������վ�������¼������ۣ�������͸�������ļ��������£���͢�����ӣ�����������Ӧ�ԡ����������ԣ�����������䣬�����̷������ǡ�������ϸ����˷���ʹ�������򣬱�������Դ���Ӧ�Թ��Ҵ��£�רע�ڸ�Ϊ���Ĺ��ߡ����������������䣬�ֹ���ȷ��ȷ��������������ߣ�Ȼ�ط������಻��С�����Ϊ���ط��ƶ��൱��֮���ġ�", "�󳼼�"));
        dialogTexts2.Add(new DialogData("��������ף��ɷϷַ���迤�ء������·�Ϊ��ʮ������ÿ���迤�أ��������أ�������ɳ�ֱ͢����������ˣ���������οصط������Ρ����ɡ����¡����ء����۵��ƶȽԿ�������������ÿһ���ط������������ط�����֮�������´��Σ������˲ߡ�", "�󳼶�"));

        var dialogTexts2_en = new List<DialogData>();
        dialogTexts2_en.Add(new DialogData("(Bowing slightly, cautious tone, frowning) Now that the world is newly unified, the territory is vast, and affairs are numerous. If everything must be handled personally, government affairs may pile up, and state matters may not proceed smoothly.", "Minister A"));
        dialogTexts2_en.Add(new DialogData("(Laughing coldly, stepping forward) His Majesty is ordained by heaven, having unified the six states, his might shaking all directions. How can government affairs be lightly entrusted to others? If all matters are delegated to ministers, His Majesty's authority will diminish, and internal court disputes will frequently arise. These words of yours, sir, could it be that you covet power and intend to usurp the throne?", "Minister B"));
        dialogTexts2_en.Add(new DialogData("(Face changing suddenly, looking flustered, lowering head and retreating, not daring to speak further)", "Minister A"));
        dialogTexts2_en.Add(new DialogData("(Other ministers look nervous)", "Scene"));
        dialogTexts2_en.Add(new DialogData("(Expression changing slightly, seeing this situation, somewhat hesitant, then speaking slowly) Although the previous words were somewhat inappropriate, it's true that state affairs are busy. Without proper delegation, court administration will inevitably be blocked, affecting the grand plans of the state. I boldly suggest... perhaps His Majesty could appoint several trusted ministers to manage local affairs separately, to reduce the central burden...", "Minister C"));
        dialogTexts2_en.Add(new DialogData("(Whispering secretly to Little Red and Little Blue) What this person proposes is actually a variation of the feudal system. The feudal system was the old practice of the Zhou emperor, where lords became independent, ultimately leading to its downfall. If we implement feudalism again today, Qin will face the same crisis.", "Mysterious Person"));
        dialogTexts2_en.Add(new DialogData("(Striding forward, coldly scanning Minister C) These words of yours, sir, are too rash. When the Zhou emperor implemented the feudal system, the lords held military power independently, ultimately causing great disaster. Local powers growing strong while the center weakens��how can our great Qin bear this? How dare you mention the old system of the previous dynasty��is this not disrespect to His Majesty?", "Minister B"));
        dialogTexts2_en.Add(new DialogData("(Taking a deep breath, bowing to Minister B, then continuing) The feudal system is unworkable; I would never dare commit such a transgression. However, court affairs are heavy, and I believe that without central officials to manage various affairs, long-term stability may be difficult. Therefore, I boldly propose��establishing the Three Dukes to separately handle administration, military, and supervision. The Chancellor manages government, the Grand Commandant handles military, and the Imperial Censor supervises all officials. Thus, although there is division of labor, all matters ultimately return to His Majesty for decision, and state power will not be lost.", "Minister C"));
        dialogTexts2_en.Add(new DialogData("(Hearing this, eyes lighting up, slowly stepping forward, rejoining the discussion, voice tinged with excitement) Your Majesty, court affairs are complex, and even the Three Dukes may struggle to handle them. I boldly suggest establishing the Nine Ministers to separately manage law, rituals, finance, and other detailed affairs, thus bringing order to administration and allowing Your Majesty to calmly handle major state matters, focusing on grander policies. However... the Three Dukes and Nine Ministers, with clear division of labor, are indeed good strategies for central governance, but local affairs should not be underestimated. I believe the local system should also be reformed accordingly.", "Minister A"));
        dialogTexts2_en.Add(new DialogData("(Nodding upon hearing this) We can abolish the feudal system and establish commanderies and counties. Divide the world into 36 commanderies, each with a governor, and counties below them, with magistrates all directly appointed by the court. Thus, the center can firmly control localities, and systems of politics, law, military, land, and taxes can all be implemented by the center in every locality, completely eliminating the danger of local independence. The great order of the world depends on this strategy.", "Minister D"));

        var dialogTexts3 = new List<DialogData>();
        dialogTexts3.Add(new DialogData("������ƽ��������ط�֮������������ö����������������ֶ��в�ͬ��������Ա�ø��Ե�������д����д���ѣ���ͨ���㣬ʱ�������岻ͨ������⡣����Ϊ����Ҫ���ͨ����Ӧͳһ���֣�������С׭Ϊ��׼��", "�󳼼�"));
        dialogTexts3.Add(new DialogData("��üͷ΢�壬�����������˲���ã�ȻС׭�����Ѷ����������ն಻��Ϥ����ǿ�����У�����Թ���򲻿ɲ�֮������", "����"));
        dialogTexts3.Add(new DialogData("�������Ϲ����ش�������������þ����֣�����������ι᳹������Ϊ��С׭���������������������Ϥ������͢�����Խ̻������������С�", "�󳼼�"));
        dialogTexts3.Add(new DialogData("��˳�ƽӻ������������֣���������Ӧͳһ�����ر�׼��һ������Ƶ������Ҫ����ǿ����ͳһ����������Ҫ֮�ߡ�", "�󳼱�"));
        dialogTexts3.Add(new DialogData("������ͣ�٣�����˵����������֮�飬��ȷ���ɲ�Ϊ�������²��ף����ȴ��������У�������ط��ƹ㡣��ˣ����ܽ������У�����ִ����·������㡣���ټ�ͳһ���ң�������Բ�η��װ���ǮΪ׼�����÷�չ�����ް���", "�󳼼�"));
        dialogTexts3.Add(new DialogData("��������͸�ż��ּᶨ���µ��������Ӧ��������ֻ��ͳһ�����ܳ��ξð���������·�����խ��һ����·���ѣ��̼�����в��㡣����ͳһ���죬��·��ݣ������������ɳ�ͨ��", "�󳼶�"));

        var dialogTexts3_en = new List<DialogData>();
        dialogTexts3_en.Add(new DialogData("(Calm tone) Although the central and local management strategies have been decided, languages and scripts vary across regions. Officials from the six states use their own scripts, making reading and writing difficult, communication inconvenient, often causing misunderstandings due to different meanings. I believe that for smooth implementation of policies, we should unify the script, all using Qin's small seal script as the standard.", "Minister A"));
        dialogTexts3_en.Add(new DialogData("(Frowning slightly, turning to Ying Zheng) This strategy is good, but the small seal script is complex and difficult to understand. Most people from the six states are unfamiliar with it. If forcibly implemented, it may cause resentment. We must not act too hastily.", "Minister B"));
        dialogTexts3_en.Add(new DialogData("(Bowing slowly, responding) If the various states still use their old scripts, how can central policies be implemented? I believe the small seal script is orderly and clear. Although people may initially be unfamiliar, with court education, it can gradually be implemented.", "Minister A"));
        dialogTexts3_en.Add(new DialogData("(Following up) Not only the script, but weights and measures should also be unified. Standards vary across regions, causing frequent disputes. To enrich the state and strengthen the military, unifying weights and measures is the primary strategy.", "Minister C"));
        dialogTexts3_en.Add(new DialogData("(Pausing slightly, then continuing) The discussion on weights and measures is indeed necessary. But this is not easy; we must first implement it centrally, then gradually promote it locally. Thus, it can be implemented step by step, avoiding inconvenience from hasty actions. If we also unify the currency, using Qin's round coins with square holes as the standard, economic development can proceed unimpeded.", "Minister A"));
        dialogTexts3_en.Add(new DialogData("(Tone tinged with determination) At this point, policies should be decisive. Only unification can bring long-term stability. The six states have roads with varying axle widths, making travel difficult and commerce inconvenient. If we can unify axle widths and repair roads, merchant travel can proceed smoothly.", "Minister D"));

        var dialogTexts4 = new List<DialogData>();
        dialogTexts4.Add(new DialogData("����ɫׯ�أ������ȶ���Ȼ�Ϸ������ϵ����������ն�ɽ��ï�ܡ���������֮������ѱ�������������������к󻼡�ֻ�������ر����������ϣ�����ƽ���Ϸ���", "�󳼼�"));
        dialogTexts4.Add(new DialogData("�������д��Ž������Ϸ������䲻���鸽��ȻԶ�����룬�Ƿ�������и�������ͼ֮��������ս�ˣ������������", "����"));
        dialogTexts4.Add(new DialogData("����¶�����������Ȼ�����˴���δ����ڽ���������ƽ���Ϸ������迤�أ���ɴ�ͨ�ϱ���ͨ������ǿ������ս���ѣ�Ȼ�����ϣ������Զ���", "�󳼼�"));
        dialogTexts4.Add(new DialogData("��΢΢������Ҫ�������ϣ��������������䡣Ȼ������ūƵƵ���ߣ�����󽫾������ر�����Ȼ��ū������թ���Ƿ����ӷ���������������ս����ʧ�أ�", "����"));
        dialogTexts4.Add(new DialogData("����ͷͬ�⣬������͸�ż��ֵ��ǣ�������ˡ�������ū��ȥ���٣������ұ߾����������Է������ִ������֮ʱ��������ʧ��Ӧ�ڱ����������ǣ�ƾɽ��֮�գ��Թ��ұ߷������һ����ƾɽ��֮�գ����������������Ҵ���֮��Ҳ������ҹѲ�ߡ���ˣ���������ū���Ͽ������ϣ�һ�����á�\r\n", "�󳼱�"));

        var dialogTexts4_en = new List<DialogData>();
        dialogTexts4_en.Add(new DialogData("(Solemn expression) The six states are now settled, but the Lingnan region in the south has treacherous terrain and dense forests. The local barbarian people are unruly. If not conquered, there may be future troubles. I suggest sending a large force to conquer Lingnan and completely pacify the south.", "Minister A"));
        dialogTexts4_en.Add(new DialogData("(Cautious tone) Although the southern barbarians have not submitted, they are far from the center. Could we first attempt appeasement and proceed slowly? If we rashly start a war, the results may be hard to achieve.", "Minister B"));
        dialogTexts4_en.Add(new DialogData("(Determined expression) This view is overly cautious. If we can pacify the south and establish commanderies and counties, we can connect north and south, enriching the state and strengthening the military. Although this war is difficult, gaining Lingnan will secure the world!", "Minister A"));
        dialogTexts4_en.Add(new DialogData("(Bowing slightly) If we send troops to Lingnan, more military deployment may be needed. However, the northern Xiongnu frequently invade our borders. Although General Meng Tian guards the northern frontier, the Xiongnu are cunning. Should we strengthen defenses to avoid fighting on two fronts and losing our rear?", "Minister B"));
        dialogTexts4_en.Add(new DialogData("(Nodding in agreement, tone tinged with worry) Exactly. The northern Xiongnu come and go without trace, often harassing our borders. Without proper defense, the northern frontier may be lost while our main force campaigns south. We should build a great wall in the north, using natural barriers to strengthen our defenses. Thus, with natural barriers, the northern frontier will be impregnable, and our Qin troops won't need constant patrols. This way, we can defend against the Xiongnu in the north while conquering Lingnan in the south��killing two birds with one stone.", "Minister C"));

        var dialogTexts5 = new List<DialogData>();
        dialogTexts5.Add(new DialogData("�ع��������£��������룬Ŀ����棬�ڴ���Ȼ�𾴡�С���С��վ�ڴ�֮��", "����"));
        dialogTexts5.Add(new DialogData("��Ŀ�����ϣ���������ƣ�����ڰ�������˭˵˵��������֮�µ����ս����", "����"));
        dialogTexts5.Add(new DialogData("�����ǻ�����ӣ��������״𸴣�", "����"));
        dialogTexts5.Add(new DialogData("С���С��վ�ڴ�֮�䣬׼���������㱨���ǴӴ󳼶Ի��еó��Ľ��ۡ������˴˿�վ����Ӱ�У�ע�������ǡ���ʱ�������ֽ���ס���ˡ�", "����"));

        var dialogTexts5_en = new List<DialogData>();
        dialogTexts5_en.Add(new DialogData("The Qin palace hall is quiet and solemn. Ying Zheng enters, his gaze piercing, all ministers standing in awe. Little Red and Little Blue stand among the ministers.", "Scene"));
        dialogTexts5_en.Add(new DialogData("(Authoritative gaze) I am somewhat fatigued. Which of my ministers can report the final results of today's discussions?", "Ying Zheng"));
        dialogTexts5_en.Add(new DialogData("(Ministers look at each other, not daring to respond easily)", "Scene"));
        dialogTexts5_en.Add(new DialogData("Little Red and Little Blue stand among the ministers, ready to report to Ying Zheng the conclusions they've drawn from the ministers' discussions. The mysterious person watches them from the shadows. At this moment, guards block them with swords.", "Scene"));


        var text1 = new DialogData("����Ϊ����_______���������", "С��");
        text1.SelectList.Add("Wrong", "A.����");
        text1.SelectList.Add("Correct", "B.�ʵ�");
        text1.SelectList.Add("Wrong", "C.��");
        text1.Callback = () => Check_Correct1();

        var text1_en = new DialogData("I believe it is reasonable to call _______", "Little Blue");
        text1_en.SelectList.Add("Wrong", "A.King of Qin");
        text1_en.SelectList.Add("Correct", "B.Emperor");
        text1_en.SelectList.Add("Wrong", "C.Huang");
        text1_en.Callback = () => Check_Correct1();

        var text2 = new DialogData("____________֮�ƣ���Ϊ�ϲߡ�", "С��");
        text2.SelectList.Add("Wrong", "A.������");
        text2.SelectList.Add("Correct", "B.��������");
        text2.SelectList.Add("Wrong", "C.�ַ���");
        text2.Callback = () => Check_Correct2();

        var text2_en = new DialogData("The system of ____________ is the best strategy.", "Little Blue");
        text2_en.SelectList.Add("Wrong", "A.Commandery-County");
        text2_en.SelectList.Add("Correct", "B.Three Dukes and Nine Ministers");
        text2_en.SelectList.Add("Wrong", "C.Feudalism");
        text2_en.Callback = () => Check_Correct2();

        var text3 = new DialogData("Ӧȫ��ϳ�_______����ȫ����Χ��ʵ�п����ƣ���_______ֱ�ӹ�Ͻ��ȫ����Ϊ_____�����ڿ�����____�������صĳ��ٶ���____ֱ�����⡣�������ʵۺͳ�͢�����ο�����ȫ�����ص�Ȩ�����������Ρ����ɡ����¡����ؼ����۵��ƶ�����ȫ����", "С��");
        text3.SelectList.Add("Wrong", "A.�����ƣ����룻36��ʡ����͢");
        text3.SelectList.Add("Correct", "B.�ַ��ƣ����룻36���أ���͢");
        text3.SelectList.Add("Wrong", "C.�ַ��ƣ��ط���30��ʡ����͢");
        text3.Callback = () => Check_Correct3();

        var text3_en = new DialogData("We should completely abolish _______ and implement the commandery-county system nationwide, directly governed by _______. The country is divided into _____ commanderies, with _____ under them. Commandery governors and county magistrates are all directly appointed by _______. Thus, the emperor and court firmly control power nationwide and implement systems of politics, law, military, land, and taxes throughout the country.", "Little Blue");
        text3_en.SelectList.Add("Wrong", "A.Commandery-County; Central; 36; Provinces; Court");
        text3_en.SelectList.Add("Correct", "B.Feudalism; Central; 36; Counties; Court");
        text3_en.SelectList.Add("Wrong", "C.Feudalism; Local; 30; Provinces; Court");
        text3_en.Callback = () => Check_Correct3();

        var text4 = new DialogData("����Ӧ��______Ϊ׼������Ӧ��______Ϊ׼�����⻹Ӧͳһ�������뽻ͨ���졣");
        text4.SelectList.Add("Wrong", "A.��С׭�����η���");
        text4.SelectList.Add("Wrong", "B.�����ģ�����Բ��");
        text4.SelectList.Add("Correct", "C.��С׭��Բ�η���");
        text4.SelectList.Add("Wrong", "D.�������ֻ���壬����Բ��");
        text4.Callback = () => Check_Correct4();

        var text4_en = new DialogData("The script should be standardized to _______, and currency should be standardized to _______. Additionally, we should unify weights and measures as well as axle widths.");
        text4_en.SelectList.Add("Wrong", "A.Qin small seal; Square with square hole");
        text4_en.SelectList.Add("Wrong", "B.Chu poetry script; Square with round hole");
        text4_en.SelectList.Add("Correct", "C.Qin small seal; Round with square hole");
        text4_en.SelectList.Add("Wrong", "D.Mixed scripts of six states; Square with round hole");
        text4_en.Callback = () => Check_Correct4();

        var text5 = new DialogData("΢����Ϊ�������ϼ������غ�����������____��_____��___��������ԭ�б����������ǵĻ����ϣ���������______������_____�ĳ��ǣ�ʹ�س���Ͻ�ķ�Χ��������������¤������������һ�����ϴ��Ϻ���", "С��");
        text5.SelectList.Add("Correct", "A.���֣��Ϻ�������䬣��ɶ�");
        text5.SelectList.Add("Wrong", "B.�Ϻ������֣���䬣����ɶ�");
        text5.SelectList.Add("Wrong", "B.���Ϻ�����䬣��ɶ�������");
        text5.Callback = () => Check_Correct5();

        var text5_en = new DialogData("I humbly suggest establishing the commanderies of _____, _____, and _____ in the Lingnan and southeastern coastal regions; and building a great wall from _____ in the west to _____ in the east based on the existing walls of northern states, making the Qin dynasty's jurisdiction reach the East Sea in the east, Longxi in the west, the Great Wall area in the north, and the South Sea in the south.", "Little Blue");
        text5_en.SelectList.Add("Correct", "A.Guilin; Nanhai; Xiang; Lintao; Liaodong");
        text5_en.SelectList.Add("Wrong", "B.Nanhai; Guilin; Lintao; Xiang; Liaodong");
        text5_en.SelectList.Add("Wrong", "C.Xiang; Nanhai; Lintao; Liaodong; Guilin");
        text5_en.Callback = () => Check_Correct5();

        var dialogQuestions = new List<DialogData>();
        dialogQuestions.Add(new DialogData("���µĳƺ�ӦΪ�Σ�", "����"));
        dialogQuestions.Add(text1);
        dialogQuestions.Add(new DialogData("����Ӧ�к����ƶȣ���ȷ��ʼ�ʵ�֮Ȩ����������¹��¸�����", "����"));
        dialogQuestions.Add(text2);
        dialogQuestions.Add(new DialogData("�ط�����֮������Ӧ�����������", "����"));
        dialogQuestions.Add(text3);
        dialogQuestions.Add(new DialogData("ͳһ���֣��ҳ�Ӧ��������һ��������Ϊ��׼��ͳһ���ң��ָ��Ժ�����ʽΪ׼��", "����"));
        dialogQuestions.Add(text4);
        dialogQuestions.Add(new DialogData("Ϊ��ǿ�Ա߽������Ŀ��غ;�Ӫ�����϶Ա��������к��ֲ��ԣ�", "����"));
        dialogQuestions.Add(text5);
        dialogQuestions.Add(new DialogData("���򶨵���ǰһ�������£������ڴ������Ѷ������³�Ϊ��ʼ�ʵۡ����������������뿤��֮�ơ�ͳһ���ֶ����⡢ʵ�г�ͬ�졢��ͬ�ġ��˾ٿ��ȹ̴��ظ�����ȷ��������ҵ��", "С��"));
        dialogQuestions.Add(new DialogData("�س����������뼯Ȩ�ƶȣ�ʹ���ҵ�һ��Ȩ�����߶ȼ����������������춨�˺��������ƶȵĿ�ܣ����Ժ���ʷ�ķ�չ������ԶӰ�졣", "������"));
        dialogQuestions.Add(new DialogData("����ĬƬ�̣����¶�������΢Ц���ܺã�����֮�ߣ�������ġ���ˣ����¿ɰ���", "����"));

        var dialogQuestions_en = new List<DialogData>();
        dialogQuestions_en.Add(new DialogData("What should Your Majesty's title be?", "Guard"));
        dialogQuestions_en.Add(text1_en);
        dialogQuestions_en.Add(new DialogData("What central system should ensure the First Emperor's authority while easing his burden?", "Guard"));
        dialogQuestions_en.Add(text2_en);
        dialogQuestions_en.Add(new DialogData("How should the local commandery-county system operate?", "Guard"));
        dialogQuestions_en.Add(text3_en);
        dialogQuestions_en.Add(new DialogData("Which writing style should we standardize on? What currency design should be standard?", "Guard"));
        dialogQuestions_en.Add(text4_en);
        dialogQuestions_en.Add(new DialogData("What strategies strengthen border expansion��south and north?", "Guard"));
        dialogQuestions_en.Add(text5_en);
        dialogQuestions_en.Add(new DialogData("(Steps forward calmly) Your Majesty, after discussion: you'll be called 'First Emperor', establishing Three Dukes/Nine Ministers and commandery-county systems, unifying writing/measures/axles. This will stabilize Qin's foundation.", "Xiao Hong"));
        dialogQuestions_en.Add(new DialogData("Qin's centralized system concentrated all state power in the central government, establishing a framework influencing later political systems.", "Mysterious Man"));
        dialogQuestions_en.Add(new DialogData("(Pausing in silence, then smiling with satisfaction) Very well, your strategy deeply pleases me. Thus, the world can be at peace!", "Ying Zheng")); 


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
            var dialogTexts_en=new List<DialogData>();

            dialogTexts.Add(new DialogData("��΢΢һЦ���ޱ�ӽ������Ϊ���ʵۡ�����ʾ�������ң�", "����"));
            dialogTexts_en.Add(new DialogData("(Slight smile) From today, I shall be called 'Emperor', to show that the mandate of heaven is with me!", "Ying Zheng"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneRight++;
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en=new List<DialogData>();

            dialogTexts.Add(new DialogData("���ν��������ô˳ƺ����񲻱�ͱ���֮����", "����"));
            dialogTexts_en.Add(new DialogData("(Drawing sword) Using this title would belittle Your Majesty's achievements!", "Guard"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneFalse++;
        }
    }

    private void Check_Correct2()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en= new List<DialogData>();

            dialogTexts.Add(new DialogData("��΢΢��ͷ���á������˲ߣ����������䣬�����ֹ����������մ�Ȩ�Թ����֡������ؽ���ְ�֣�ĪҪ�������ġ�", "����"));
            dialogTexts.Add(new DialogData("��֣�����񣩱���Ӣ������Ը�����֮�ߣ��߾�ȫ�����д��ơ�", "�ڴ�"));

            dialogTexts_en.Add(new DialogData("(Nodding slightly) Good. We will follow this strategy, establishing Three Dukes and Nine Ministers, with clear division of labor in court affairs, but ultimate power remains with me. You must all keep your positions and not harbor any treachery.", "Ying Zheng"));
            dialogTexts_en.Add(new DialogData("(Bowing solemnly) Your Majesty is wise. I am willing to follow Your Majesty's strategy and do my utmost to implement this system.", "All Ministers"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneRight++;
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("���ν����������˵����Լ�ǰ�����ƣ�Ī���ǶԱ��²�����", "����"));
            dialogTexts_en.Add(new DialogData("(Drawing sword) How dare you mention the old system of the previous dynasty? Is this disrespect to Your Majesty?", "Guard"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneFalse++;
        }
    }

    private void Check_Correct3()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();
            dialogTexts.Add(new DialogData("����¶����֮ɫ���ط����񣬹������롣��������ǣ������Ѷ���Ȼ���޹��ƣ����ཫΣ�������ƣ��˰����֮�������ȫ�����У�", "����"));
            dialogTexts.Add(new DialogData("�������������ʷ�ϣ��غ󽫿�������������40�࿤�������Ƶ��ձ����У������˴˺��ҹ����������ط������Ļ���ģʽ��", "������"));

            dialogTexts_en.Add(new DialogData("(Showing satisfaction) Local affairs are under the central authority. You must remember, the world is settled, but without regulations, the state will be in danger. The commandery-county system is the foundation of national stability; you must implement it with all your strength!", "Ying Zheng"));
            dialogTexts_en.Add(new DialogData("(whispers softly) Historically, the Qin Dynasty increased the number of counties to more than 40. The widespread implementation of the county system has created the basic model of local administration in successive dynasties in China.", "Mystery Man"));
            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneRight++;
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("���ν����������˶Կ����Ƶ�ʩ���в�����Ϥ�����Ϊ��֮���й���������", "����"));
            dialogTexts_en.Add(new DialogData("(Drawing sword) You are not familiar with the implementation of the commandery-county system. How can you contribute to the operation of the country?", "Guard"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneFalse++;
        }
    }

    private void Check_Correct4()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("��Ŀ����棩�š�����ͬ�ģ���ͬ�죬������������ͳһ������ʹ��������ͳһ�����֮�飬���м��ء�������ȥ����ة����˹ȡ��׭��������򻯣��ƶ��ʻ�������С׭����Ϊȫ��ͨ�����֡�", "����"));
            dialogTexts.Add(new DialogData("������������ֵ�ͳһ��ʹ�����ܹ���ȫ������˳�����У�Ҳʹ��ͬ����������ܹ�˳����ͨ���������Ļ��Ľ����뷢չ�����ҵ�ͳһ���ı����������ƻ��ҵ�״���������ڹ��ҶԾ��õĹ����ٽ����ؾ��õĽ��������س���ʼ��Բ�η�����һ��������Ϊ�������������á��������ͳһ���ٽ��˾��õķ�չ�� ����ʼ������ͳһ����͵�·�Ŀ�ȣ���������ͨȫ���ĵ�·���γ���������Ϊ���ĵ�ȫ����ͨ����", "������"));

            dialogTexts_en.Add(new DialogData("(Eyes piercing) Hmm... Unifying writing, axle widths, currency, and weights and measures will truly unify the world. Your suggestion is insightful. Order it down, commanding Prime Minister Li Si to take the large seal script, organize and simplify it, and establish the small seal script as the national standard.", "Ying Zheng"));
            dialogTexts_en.Add(new DialogData("(whispers softly) The unification of the written language enables the decree to be carried out smoothly throughout the country, and also enables people in different regions to communicate smoothly, which is conducive to cultural exchange and development. The unification of the currency has changed the chaotic situation of the currency system in the past, is conducive to the state's management of the economy, and promotes economic exchanges in various localities. Since the Qin Dynasty, the currency form of the round square hole has been used by successive dynasties. The unification of weights and measures has promoted economic development. Qin Shi Huang ordered the unification of the width of the tracks and roads, and the construction of roads that ran through the whole country, forming a national transportation network centered on Xianyang.", "Mystery Man"));
            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneRight++;
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("���ν���������������δ���Ҵ���֮�ƣ�����Υ����������ʵ�����˷ѽ⡣", "����"));
            dialogTexts_en.Add(new DialogData("(Drawing sword) What you said does not follow the system of our Qin Dynasty, which may violate Your Majesty's command. It is really puzzling.", "Guard"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneFalse++;
        }
    }

    private void Check_Correct5()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("��Ŀ��������������ϣ��ã����񽫾�������������ū�������ٽ����ǣ��Ի��������Ҵ��ؽ�ɽ�ȹ̣������������������ǡ�", "����"));
            dialogTexts.Add(new DialogData("������ݵ��������������������ҳϣ�����ʥ�����������ã��ؿɿ��ؽ����������������������ǡ����ȱؽ߾�ȫ���������³ɴ�ΰҵ��", "�ڴ�"));
            dialogTexts_en.Add(new DialogData("(Cold gaze, authoritative tone) Good! General Meng Tian has led the army to the north to attack the Xiongnu. Now we must build the Great Wall to protect the northern frontier. The foundation of our Qin Dynasty is stable, and we can conquer south and defend north without worry.", "Ying Zheng"));
            dialogTexts_en.Add(new DialogData("(Bowing deeply, tone filled with admiration and loyalty) Your Majesty is wise. If we gain Lingnan, we can expand our territory; if the Great Wall is built, the north will be secure. We will do our utmost to help Your Majesty achieve this great cause!", "All Ministers"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneRight++;
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();
            var dialogTexts_en = new List<DialogData>();

            dialogTexts.Add(new DialogData("���ν����������˾��Թ�֮�����в��˽⣬�˷����Կ������", "����"));
            dialogTexts_en.Add(new DialogData("(Drawing sword) You are unaware of the country's territory. This strategy may harm the state!", "Guard"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneFalse++;
        }
    }
}
