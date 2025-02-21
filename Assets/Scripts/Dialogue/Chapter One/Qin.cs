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
        else
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("Right. You don't have to get the answer."));

            DialogManager.Show(dialogTexts);
        }
    }
}
