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
        var text1 = new DialogData("(˼����ش�) ________________________��", "С��");
        text1.SelectList.Add("Wrong", "A.��˰���ᣬ���ۼ���");
        text1.SelectList.Add("Correct", "B.��˰���أ��������겻��");
        text1.SelectList.Add("Wrong", "C.û�и�˰�����ۣ����������");
        text1.SelectList.Add("Wrong", "D.��˰������ֻ�ڲ��ֵ�������");
        text1.Callback = () => Check_Correct1();

        var text2 = new DialogData("�������в�����________��һ�˷�����_______��Ҫ�ܵ�ǣ����", "С��");
        //text2.SelectList.Add("Wrong", "A.����");
        text2.SelectList.Add("Correct", "B.�������ɣ�����������");
        //text2.SelectList.Add("Wrong", "C.��");
        text2.Callback = () => Check_Correct2();

        var text3 = new DialogData("����_____________________��", "С��");
        text3.SelectList.Add("Wrong", "A.����������");
        text3.SelectList.Add("Correct", "B.֫��к������ѡ���ն������ȶ�������");
        text3.SelectList.Add("Wrong", "C.����Ʋ�");
        text3.SelectList.Add("Wrong", "D.���ź���");
        text3.Callback = () => Check_Correct3();

        var text4 = new DialogData("��ʼ��Ϊ����˼�룬�����ջٸ���ʷ�������ղص����Ӱټ��������������ع���ʷ�鼰ҽҩ����ֲ��ռ��֮����鼮���ֽ����鳯����460��������ͷ�ʿȫ����ɱ���������________����", "С��");
        //text3.SelectList.Add("Wrong", "A.����");
        text3.SelectList.Add("Correct", "�������");
        //text3.SelectList.Add("Wrong", "C.��");
        text3.Callback = () => Check_Correct4();

        var text5 = new DialogData("�ض��������޽��Ӵ�Ĺ��̣�������������_____�������ؼ������ã�ʹ�ø������ӳ��ء�", "С��");
        text5.SelectList.Add("Correct", "A.����");
        text5.SelectList.Add("Wrong", "B.����");
        text5.SelectList.Add("Wrong", "C.����");
        text5.Callback = () => Check_Correct5();

        dialogTexts.Add(new DialogData("Ӫ���ڣ���ʤ���������������ǻ������ܣ��������ء�ϭ�������̿���ֽ���ڷ��ű�ī�������δ����죬�������£��������̺�������ǰ��ѹ�֡�", "����"));
        dialogTexts.Add(new DialogData("(����ë�ʣ�Ŀ��ᶨ������˵��) ��ϭ�ķ�ͬС�ɣ��뽫�س������Ѹ����£����ѱ�ѹ�ȵİ��գ������������ģ��Ʒ����ء�", "��ʤ"));
        dialogTexts.Add(new DialogData("�س������Ѿã���Թ���ڡ��������ܿ��ѣ�Ȼ��һ�ѻ��ȼ��ŭ��ϭ����������֡���", "���"));
        dialogTexts.Add(new DialogData("���գ���ʤ�����ֽ��д��ϭ�ģ��ԴǼ���������������Ѫ�������絶��", "����"));
        dialogTexts.Add(new DialogData("�س���������ũ�����յĸ�˰��������Σ�", "���"));
        dialogTexts.Add(text1);
        dialogTexts.Add(new DialogData("�س��ķ�������Ͽ���", "��ʤ"));
        dialogTexts.Add(text2);
        dialogTexts.Add(new DialogData("�س�ʱ��ʩ������Щ����п���̷���", "���"));     
        dialogTexts.Add(text3);
        dialogTexts.Add(new DialogData("��ʼ��Ϊ�˿���˼�룬��ȡ����Щ��ʩ��", "��ʤ"));
        dialogTexts.Add(text4);
        dialogTexts.Add(new DialogData("��ʼ�����󣬼�λ���ض��������ڵ�ѹ�ȸ�Ϊ�пᡣ", "���"));
        dialogTexts.Add(text5);
        dialogTexts.Add(new DialogData("(�����ж�ϭ��) �س�������������ʩ����˰���أ��������꣬��������������������¶��������տ�ʹ��Թ���ص����ط��пᣬ�ɷ��������������������������壬����˼�룬���������߿ڲ����ԣ����տ������ߡ������ô�ϲ�������������Ĺ���ľ������������������ۣ���ţ��֮�����������ý��ѡ��ǿ��̣��벻���̣�", "���"));
        dialogTexts.Add(new DialogData("���һ��һ�䣬���������ģ�����������������Ѫ���ڣ�����ȼ�������һ�", "����"));
        dialogTexts.Add(new DialogData("(���Ų��䣬�ԴǸ�Ϊ����) �������й飬��Թ���ڣ���ȽҸͶ��𣬷������أ��ٴ��壬�ﱩ�أ�Ը����ͬ�ʣ��������죬�Ʒ��б�֮�أ�׳ʿ�������ѣ���������������ӵ��Ϊ�����ų���Ȩ��������Ը��ϥ�ڿ������ߣ��Կ������ų�����ı���壡", "��ʤ"));
        dialogTexts.Add(new DialogData("(����Ӧ�ͣ�������������������) նľΪ�����Ҹ�Ϊ�죬���뱩�ؾ�һ��ս��", "������"));

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

            dialogTexts.Add(new DialogData("(�����˵��) ������˰���أ��������꣬���ղ����ظ��������������Թ���ڵĸ�Դ��", "��ʤ"));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(ҡͷ�������д��ŷ��) ��˰���ء����۷��࣬���������ڰ��ݵ����ӣ��س���ѹ���ð��տ಻���ԣ�", "���"));

            DialogManager.Show(dialogTexts);
        }
    }

    private void Check_Correct2()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(��ͷ�϶���������ŭ) �ԣ��س��Ŀ����ð������ı��������й�ʧ���������ﶼҪ�ܵ�ǣ��������һ�ߡ�", "��ʤ"));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(��ü����������) ��ֻ�Ǹ����˵ĳͷ����ط����飬�����������Ҫ���ᡣ�����ı��������ܲ������°��շ�����", "���"));

            DialogManager.Show(dialogTexts);
        }
    }

    private void Check_Correct3()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(���صص�ͷ) û���س�ʩ�е��̷��п�������������һ�����⣬�����ı����ػ��������·�����", "��ʤ"));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(ҡͷ̾Ϣ) ���źͰ���Ʋ�����ֻ�Ǳ��档�س����̷��п�������֫��к������յ���������ݽ棬�������������������������壡", "���"));

            DialogManager.Show(dialogTexts);
        }
    }

    private void Check_Correct4()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(������˸��ŭ֮ɫ) ���Ƿ�����壡��ʼ�ʲ������̷���ѹ���գ�����˼��������ٻ��鼮��ɱ�����������׷������յ����ǡ�", "��ʤ"));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(�������) ��˲п��ֶΣ��ð��ղ����Բ����ʣ�˼�뱻������ѧ�߱�ɱ��������س�����������һ����", "���"));

            DialogManager.Show(dialogTexts);
        }
    }

    private void Check_Correct5()
    {
        if (DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(�����ͳ����侲) �ض����ײб�Ű����������Ϊ�������ǣ����������ã�ʹ����������Ӽ��ѡ�", "��ʤ"));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("(��ŭ��ҡͷ) ���ǳ�����Ҳ�����������ض����ı����������������Ӵ󹤳��ϣ����ձ�ǿ��Ϊ��Ӫ�����������ƿ��ڱ���֮�֡�", "���"));

            DialogManager.Show(dialogTexts);
        }
    }
}
