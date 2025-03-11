using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using System.IO;

public class Qin : MonoBehaviour
{
    public DialogManager DialogManager;
    public bool isActive = false;
    public bool isFirst = true;
 
    public GameObject[] Example;

    private void Update()
    {
        Awake();
    }

    public void Show()
    {
        isActive = true;
    }

    private void Awake()
    {
        var dialogTexts1 = new List<DialogData>();

        dialogTexts1.Add(new DialogData("���������ҽ�Ϊ�������Ϸ�Ļ������ܺ��淨", "������"));
        dialogTexts1.Add(new DialogData("���ȣ���Ϸ�Ļ�����ʽ��ͨ���Ի���ȡ֪ʶ", "������", () => Show_Example(0)));
        dialogTexts1.Add(new DialogData("����Ҫ�ڳ������ҵ���ص������������������Ի���С��Ϸ", "������", () => Hide_Example(0)));
        dialogTexts1.Add(new DialogData("�Ի�������Ϸ�����У�����Ҫ��ϸ�Ķ��Ի��������Ӧ��֪ʶ", "������", () => Show_Example(1)));
        dialogTexts1.Add(new DialogData("���˽�֪ʶ��ʱ����������ĳЩ֪ʶ��ʮ����Ҫ������Դ򿪱ʼǱ���¼����Ҫ��֪ʶ", "������", () => Show_Example(2)));
        dialogTexts1.Add(new DialogData("�����ʷ�ٰ�ť�����㽫������ѡ��ֱ��ǡ�����ʷ�١�����֪ʶ�عˡ��Լ��ʼǱ�", "������", () => Show_Example(3)));
        dialogTexts1.Add(new DialogData("����ʼǱ�������Խ��������Ҫ��֪ʶ��¼�ڱʼǱ��У��Ա���ʱ�鿴", "������"));
        dialogTexts1.Add(new DialogData("����������������֪ʶ�㣬Ҳ���Ե����Ͳ��ͨ������������Ӧ��֪ʶ�㣬��������������õؼ���֪ʶ����", "������"));
        dialogTexts1.Add(new DialogData("���⣬���������������������ϵġ�N�������򿪱ʼǱ�", "������"));
        dialogTexts1.Add(new DialogData("���ˡ��ʼǱ������ܣ����С�����ʷ�١����ܣ����������ѯ���κ��йص���ʷ���⣬��һ�������һ������Ļش�", "������"));
        dialogTexts1.Add(new DialogData("��������������Լ�����֪ʶ����������������Ҫ�����Լ���֪ʶ����֪ʶ�عˡ���һ���ܺõ�ѡ��", "������"));
        dialogTexts1.Add(new DialogData("����������һ���µ�֪ʶ�㣬����ÿ�ν����������Ŀ����������õ��˽��Լ�����֪ʶ���������", "������"));
        dialogTexts1.Add(new DialogData("���������뾡�����������Ϸ�ɣ�����Զ��Ҫ�������ʹ��������ȡ�����֪ʶ������ʷ����������ǰ���ķ���", "������"));

        var dialogTexts = new List<DialogData>();
        var text = new DialogData("����Ϊ����_______���������", "С��");
        text.SelectList.Add("Wrong", "A.����");
        text.SelectList.Add("Correct", "B.�ʵ�");
        text.SelectList.Add("Wrong", "C.��");
        text.Callback = () => Check_Correct();

        dialogTexts.Add(new DialogData("�ع�������Ρ�룬װ���ݻ�����ʼ�ʵ����������������á������жӶ������������¡�С���С����Ȼ��Խ�ڴˣ����ڴ�֮�䣬��������������ҵ����ۡ�", "����", () => Show_Example(0)));
        dialogTexts.Add(new DialogData("����С���С�������Ȼ��������˵����������������ʮ��ı��������һͳ���¡��Զ�ʮ�����������𺫣���ս��֮�ף����Ż�ʦ�����������ڳ�ƽ����κ�ڴ�����ǿ�������Ա�������һ�߽⡣/color:yellow/�����������������������һͳ��/color:white//size:init/�˷����۷�ͬС�ɣ��κ�ϸ΢֮ʧ�Կɶ�ҡ���������ĸ����������ϸ������", "������", () => Hide_Example(0)));
        dialogTexts.Add(new DialogData("��΢΢��ͷ������רע����������һ˿���ţ�", "С��"));
        dialogTexts.Add(new DialogData("����ǰ����������ׯ�أ�������͸�ž�η�����¹���������ƽ�����ϣ�ͳһ���ģ���ǰ������ǰ��δ��֮ΰҵ����������֮�ƣ��Ѳ��������Ա��·Ṧΰ������������Ϊ������Ӧ��ȡ��ƣ������䳬��֮����", "�󳼼�"));
        dialogTexts.Add(new DialogData("��üͷ΢�壬��������ȴ�������ǣ�����Ϊ����������֮������Ϊ��������֪������Ȼ���ģ���ͽ�����������Ĳ��ȣ��������̣�����������˼��", "����"));
        dialogTexts.Add(new DialogData("��Ŀ��ɨ���ڳ������Գơ������������Եñ��¹�ҵ����Щ�������죿���¹��𣬹�ҵ��˫�����ѳ�Խ��֮������ۣ�������ӦЧ�����ƣ��ơ��ʡ������ʡ�֮��������ƥ���������ΰҵ���Ѹ����£��������������顣", "�󳼱�"));
        dialogTexts.Add(new DialogData("������̧��������Ƭ�̣���ͷ���ͣ�ة���������ǡ������ơ���������ȷ���������Ա���֮�������ʡ�����ǰ���ӡ��ۡ����ں󣬳ơ�ʼ�ʵۡ��������������Ա���֮����������ǰ�޹��ˣ��������ߣ�����������", "�󳼶�"));

        dialogTexts.Add(new DialogData("���µĳƺ�ӦΪ�Σ�", "����"));
        dialogTexts.Add(text);

        if (isFirst)
        {
            DialogManager.Show(dialogTexts1);
            isFirst = false;
        }
        
        if (isActive)
        {
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

            dialogTexts.Add(new DialogData("��΢΢һЦ���ޱ�ӽ������Ϊ���ʵۡ�����ʾ�������ң�", "����"));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        { 
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("���ν��������ô˳ƺ����񲻱�ͱ���֮����", "����"));

            DialogManager.Show(dialogTexts);
        }
    }
}
