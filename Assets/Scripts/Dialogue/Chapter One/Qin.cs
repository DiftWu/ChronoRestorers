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
    
        var dialogTexts1 = new List<DialogData>();
        dialogTexts1.Add(new DialogData("�ع�������Ρ�룬װ���ݻ�����ʼ�ʵ����������������á������жӶ������������¡�С���С����Ȼ��Խ�ڴˣ����ڴ�֮�䣬��������������ҵ����ۡ�", "����", () => Show_Example(5)));
        dialogTexts1.Add(new DialogData("����С���С�������Ȼ��������˵����������������ʮ��ı��������һͳ���¡��Զ�ʮ�����������𺫣���ս��֮�ף����Ż�ʦ�����������ڳ�ƽ����κ�ڴ�����ǿ�������Ա�������һ�߽⡣/color:yellow/�����������������������һͳ��/color:white//size:init/�˷����۷�ͬС�ɣ��κ�ϸ΢֮ʧ�Կɶ�ҡ���������ĸ����������ϸ������", "������", () => Hide_Example(5)));
        dialogTexts1.Add(new DialogData("��΢΢��ͷ������רע����������һ˿���ţ�", "С��"));
        dialogTexts1.Add(new DialogData("����ǰ����������ׯ�أ�������͸�ž�η�����¹���������ƽ�����ϣ�ͳһ���ģ���ǰ������ǰ��δ��֮ΰҵ����������֮�ƣ��Ѳ��������Ա��·Ṧΰ������������Ϊ������Ӧ��ȡ��ƣ������䳬��֮����", "�󳼼�"));
        dialogTexts1.Add(new DialogData("��üͷ΢�壬��������ȴ�������ǣ�����Ϊ����������֮������Ϊ��������֪������Ȼ���ģ���ͽ�����������Ĳ��ȣ��������̣�����������˼��", "����"));
        dialogTexts1.Add(new DialogData("��Ŀ��ɨ���ڳ������Գơ������������Եñ��¹�ҵ����Щ�������죿���¹��𣬹�ҵ��˫�����ѳ�Խ��֮������ۣ�������ӦЧ�����ƣ��ơ��ʡ������ʡ�֮��������ƥ���������ΰҵ���Ѹ����£��������������顣", "�󳼱�"));
        dialogTexts1.Add(new DialogData("������̧��������Ƭ�̣���ͷ���ͣ�ة���������ǡ������ơ���������ȷ���������Ա���֮�������ʡ�����ǰ���ӡ��ۡ����ں󣬳ơ�ʼ�ʵۡ��������������Ա���֮����������ǰ�޹��ˣ��������ߣ�����������", "�󳼶�"));

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

        var dialogTexts3 = new List<DialogData>();
        dialogTexts3.Add(new DialogData("������ƽ��������ط�֮������������ö����������������ֶ��в�ͬ��������Ա�ø��Ե�������д����д���ѣ���ͨ���㣬ʱ�������岻ͨ������⡣����Ϊ����Ҫ���ͨ����Ӧͳһ���֣�������С׭Ϊ��׼��", "�󳼼�"));
        dialogTexts3.Add(new DialogData("��üͷ΢�壬�����������˲���ã�ȻС׭�����Ѷ����������ն಻��Ϥ����ǿ�����У�����Թ���򲻿ɲ�֮������", "����"));
        dialogTexts3.Add(new DialogData("�������Ϲ����ش�������������þ����֣�����������ι᳹������Ϊ��С׭���������������������Ϥ������͢�����Խ̻������������С�", "�󳼼�"));
        dialogTexts3.Add(new DialogData("��˳�ƽӻ������������֣���������Ӧͳһ�����ر�׼��һ������Ƶ������Ҫ����ǿ����ͳһ����������Ҫ֮�ߡ�", "�󳼱�"));
        dialogTexts3.Add(new DialogData("������ͣ�٣�����˵����������֮�飬��ȷ���ɲ�Ϊ�������²��ף����ȴ��������У�������ط��ƹ㡣��ˣ����ܽ������У�����ִ����·������㡣���ټ�ͳһ���ң�������Բ�η��װ���ǮΪ׼�����÷�չ�����ް���", "�󳼼�"));
        dialogTexts3.Add(new DialogData("��������͸�ż��ּᶨ���µ��������Ӧ��������ֻ��ͳһ�����ܳ��ξð���������·�����խ��һ����·���ѣ��̼�����в��㡣����ͳһ���죬��·��ݣ������������ɳ�ͨ��", "�󳼶�"));

        var dialogTexts4 = new List<DialogData>();
        dialogTexts4.Add(new DialogData("����ɫׯ�أ������ȶ���Ȼ�Ϸ������ϵ����������ն�ɽ��ï�ܡ���������֮������ѱ�������������������к󻼡�ֻ�������ر����������ϣ�����ƽ���Ϸ���", "�󳼼�"));
        dialogTexts4.Add(new DialogData("�������д��Ž������Ϸ������䲻���鸽��ȻԶ�����룬�Ƿ�������и�������ͼ֮��������ս�ˣ������������", "����"));
        dialogTexts4.Add(new DialogData("����¶�����������Ȼ�����˴���δ����ڽ���������ƽ���Ϸ������迤�أ���ɴ�ͨ�ϱ���ͨ������ǿ������ս���ѣ�Ȼ�����ϣ������Զ���", "�󳼼�"));
        dialogTexts4.Add(new DialogData("��΢΢������Ҫ�������ϣ��������������䡣Ȼ������ūƵƵ���ߣ�����󽫾������ر�����Ȼ��ū������թ���Ƿ����ӷ���������������ս����ʧ�أ�", "����"));
        dialogTexts4.Add(new DialogData("����ͷͬ�⣬������͸�ż��ֵ��ǣ�������ˡ�������ū��ȥ���٣������ұ߾����������Է������ִ������֮ʱ��������ʧ��Ӧ�ڱ����������ǣ�ƾɽ��֮�գ��Թ��ұ߷������һ����ƾɽ��֮�գ����������������Ҵ���֮��Ҳ������ҹѲ�ߡ���ˣ���������ū���Ͽ������ϣ�һ�����á�\r\n", "�󳼱�"));

        var dialogTexts5 = new List<DialogData>();
        dialogTexts5.Add(new DialogData("�ع��������£��������룬Ŀ����棬�ڴ���Ȼ�𾴡�С���С��վ�ڴ�֮��", "����"));
        dialogTexts5.Add(new DialogData("��Ŀ�����ϣ���������ƣ�����ڰ�������˭˵˵��������֮�µ����ս����", "����"));
        dialogTexts5.Add(new DialogData("�����ǻ�����ӣ��������״𸴣�", "����"));
        dialogTexts5.Add(new DialogData("С���С��վ�ڴ�֮�䣬׼���������㱨���ǴӴ󳼶Ի��еó��Ľ��ۡ������˴˿�վ����Ӱ�У�ע�������ǡ���ʱ�������ֽ���ס���ˡ�", "����"));


        var text1 = new DialogData("����Ϊ����_______���������", "С��");
        text1.SelectList.Add("Wrong", "A.����");
        text1.SelectList.Add("Correct", "B.�ʵ�");
        text1.SelectList.Add("Wrong", "C.��");
        text1.Callback = () => Check_Correct1();

        var text2 = new DialogData("____________֮�ƣ���Ϊ�ϲߡ�", "С��");
        text2.SelectList.Add("Wrong", "A.������");
        text2.SelectList.Add("Correct", "B.��������");
        text2.SelectList.Add("Wrong", "C.�ַ���");
        text2.Callback = () => Check_Correct2();

        var text3 = new DialogData("Ӧȫ��ϳ�_______����ȫ����Χ��ʵ�п����ƣ���_______ֱ�ӹ�Ͻ��ȫ����Ϊ_____�����ڿ�����____�������صĳ��ٶ���____ֱ�����⡣�������ʵۺͳ�͢�����ο�����ȫ�����ص�Ȩ�����������Ρ����ɡ����¡����ؼ����۵��ƶ�����ȫ����", "С��");
        text3.SelectList.Add("Wrong", "A.�����ƣ����룻36��ʡ����͢");
        text3.SelectList.Add("Correct", "B.�ַ��ƣ����룻36���أ���͢");
        text3.SelectList.Add("Wrong", "C.�ַ��ƣ��ط���30��ʡ����͢");
        text3.Callback = () => Check_Correct3();

        var text4 = new DialogData("����Ӧ��______Ϊ׼������Ӧ��______Ϊ׼�����⻹Ӧͳһ�������뽻ͨ���졣");
        text4.SelectList.Add("Wrong", "A.��С׭�����η���");
        text4.SelectList.Add("Wrong", "B.�����ģ�����Բ��");
        text4.SelectList.Add("Correct", "C.��С׭��Բ�η���");
        text4.SelectList.Add("Wrong", "D.�������ֻ���壬����Բ��");
        text4.Callback = () => Check_Correct4();

        var text5 = new DialogData("΢����Ϊ�������ϼ������غ�����������____��_____��___��������ԭ�б����������ǵĻ����ϣ���������______������_____�ĳ��ǣ�ʹ�س���Ͻ�ķ�Χ��������������¤������������һ�����ϴ��Ϻ���", "С��");
        text5.SelectList.Add("Correct", "A.���֣��Ϻ�������䬣��ɶ�");
        text5.SelectList.Add("Wrong", "B.�Ϻ������֣���䬣����ɶ�");
        text5.SelectList.Add("Wrong", "B.���Ϻ�����䬣��ɶ�������");
        text5.Callback = () => Check_Correct5();

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

            dialogTexts.Add(new DialogData("��΢΢һЦ���ޱ�ӽ������Ϊ���ʵۡ�����ʾ�������ң�", "����"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneRight++;
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("���ν��������ô˳ƺ����񲻱�ͱ���֮����", "����"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneFalse++;
        }
    }

    private void Check_Correct2()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("��΢΢��ͷ���á������˲ߣ����������䣬�����ֹ����������մ�Ȩ�Թ����֡������ؽ���ְ�֣�ĪҪ�������ġ�", "����"));
            dialogTexts.Add(new DialogData("��֣�����񣩱���Ӣ������Ը�����֮�ߣ��߾�ȫ�����д��ơ�", "�ڴ�"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneRight++;
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("���ν����������˵����Լ�ǰ�����ƣ�Ī���ǶԱ��²�����", "����"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneFalse++;
        }
    }

    private void Check_Correct3()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("����¶����֮ɫ���ط����񣬹������롣��������ǣ������Ѷ���Ȼ���޹��ƣ����ཫΣ�������ƣ��˰����֮�������ȫ�����У�", "����"));
            dialogTexts.Add(new DialogData("�������������ʷ�ϣ��غ󽫿�������������40�࿤�������Ƶ��ձ����У������˴˺��ҹ����������ط������Ļ���ģʽ��", "������"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneRight++;
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("���ν����������˶Կ����Ƶ�ʩ���в�����Ϥ�����Ϊ��֮���й���������", "����"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneFalse++;
        }
    }

    private void Check_Correct4()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("��Ŀ����棩�š�����ͬ�ģ���ͬ�죬������������ͳһ������ʹ��������ͳһ�����֮�飬���м��ء�������ȥ����ة����˹ȡ��׭��������򻯣��ƶ��ʻ�������С׭����Ϊȫ��ͨ�����֡�", "����"));
            dialogTexts.Add(new DialogData("������������ֵ�ͳһ��ʹ�����ܹ���ȫ������˳�����У�Ҳʹ��ͬ����������ܹ�˳����ͨ���������Ļ��Ľ����뷢չ�����ҵ�ͳһ���ı����������ƻ��ҵ�״���������ڹ��ҶԾ��õĹ����ٽ����ؾ��õĽ��������س���ʼ��Բ�η�����һ��������Ϊ�������������á��������ͳһ���ٽ��˾��õķ�չ�� ����ʼ������ͳһ����͵�·�Ŀ�ȣ���������ͨȫ���ĵ�·���γ���������Ϊ���ĵ�ȫ����ͨ����", "������"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneRight++;
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("���ν���������������δ���Ҵ���֮�ƣ�����Υ����������ʵ�����˷ѽ⡣", "����"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneFalse++;
        }
    }

    private void Check_Correct5()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("��Ŀ��������������ϣ��ã����񽫾�������������ū�������ٽ����ǣ��Ի��������Ҵ��ؽ�ɽ�ȹ̣������������������ǡ�", "����"));
            dialogTexts.Add(new DialogData("������ݵ��������������������ҳϣ�����ʥ�����������ã��ؿɿ��ؽ����������������������ǡ����ȱؽ߾�ȫ���������³ɴ�ΰҵ��", "�ڴ�"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneRight++;
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("���ν����������˾��Թ�֮�����в��˽⣬�˷����Կ������", "����"));

            DialogManager.Show(dialogTexts);

            DataManager.Instance.playerData.ChapterOneFalse++;
        }
    }
}
