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

        var text1 = new DialogData("(˼����ش�) ________________________��", "С��");
        text1.SelectList.Add("Wrong", "A.��˰���ᣬ���ۼ���");
        text1.SelectList.Add("Correct", "B.��˰���أ��������겻��");
        text1.SelectList.Add("Wrong", "C.û�и�˰�����ۣ����������");
        text1.SelectList.Add("Wrong", "D.��˰������ֻ�ڲ��ֵ�������");
        text1.Callback = () => Check_Correct1();

        var text1_en = new DialogData("(After thinking) ________________________.", "Xiao Hong");
        text1_en.SelectList.Add("Wrong", "A. Taxes reduced, corv��e labor decreased");
        text1_en.SelectList.Add("Correct", "B. Heavy taxes and continuous corv��e labor");
        text1_en.SelectList.Add("Wrong", "C. No taxes or labor, people lived comfortably");
        text1_en.SelectList.Add("Wrong", "D. Taxes and labor only implemented in some regions");
        text1_en.Callback = () => Check_Correct1();

        var text2 = new DialogData("�������в�����________��һ�˷�����_______��Ҫ�ܵ�ǣ����", "С��");
        text2.SelectList.Add("Wrong", "A.����");
        text2.SelectList.Add("Correct", "B.�������ɣ�����������");
        text2.SelectList.Add("Wrong", "C.��");
        text2.Callback = () => Check_Correct2();

        var text2_en = new DialogData("If people make the slightest mistake, they ________. When one person breaks the law, ________ are also implicated.", "Xiao Lan");
        text2_en.SelectList.Add("Wrong", "A. Qin Wang");
        text2_en.SelectList.Add("Correct", "B. violate the law; relatives and neighbors");
        text2_en.SelectList.Add("Wrong", "C. Emperor");
        text2_en.Callback = () => Check_Correct2();

        var text3 = new DialogData("����_____________________��", "С��");
        text3.SelectList.Add("Wrong", "A.����������");
        text3.SelectList.Add("Correct", "B.֫��к������ѡ���ն������ȶ�������");
        text3.SelectList.Add("Wrong", "C.����Ʋ�");
        text3.SelectList.Add("Wrong", "D.���ź���");
        text3.Callback = () => Check_Correct3();

        var text3_en = new DialogData("Including _____________________.", "Xiao Lan");
        text3_en.SelectList.Add("Wrong", "A. Imprisonment, exile");
        text3_en.SelectList.Add("Correct", "B. Mutilation, dismemberment, waist-cutting, live burial and other executions");
        text3_en.SelectList.Add("Wrong", "C. Property confiscation");
        text3_en.SelectList.Add("Wrong", "D. Overseas exile");
        text3_en.Callback = () => Check_Correct3();

        var text4 = new DialogData("��ʼ��Ϊ����˼�룬�����ջٸ���ʷ�������ղص����Ӱټ��������������ع���ʷ�鼰ҽҩ����ֲ��ռ��֮����鼮���ֽ����鳯����460��������ͷ�ʿȫ����ɱ���������________����", "С��");
        text4.SelectList.Add("Wrong", "A.����");
        text4.SelectList.Add("Correct", "�������");
        text4.SelectList.Add("Wrong", "C.��");
        text4.Callback = () => Check_Correct4();

        var text4_en = new DialogData("To control thought, Qin Shi Huang ordered the burning of historical records from other states and privately held works of various philosophers, preserving only Qin's histories and books on medicine, agriculture, and divination. He then buried alive 460+ scholars who criticized his policies. This was called '________'.", "Xiao Hong");
        text4_en.SelectList.Add("Wrong", "A. Qin Wang");
        text4_en.SelectList.Add("Correct", "Burning of Books and Burying of Scholars");
        text4_en.SelectList.Add("Wrong", "C. Emperor");
        text4_en.Callback = () => Check_Correct4();

        var text5 = new DialogData("�ض��������޽��Ӵ�Ĺ��̣�������������_____�������ؼ������ã�ʹ�ø������ӳ��ء�", "С��");
        text5.SelectList.Add("Correct", "A.����");
        text5.SelectList.Add("Wrong", "B.����");
        text5.SelectList.Add("Wrong", "C.����");
        text5.Callback = () => Check_Correct5();

        var text5_en = new DialogData("After Qin Shi Huang's death, Qin Ershi continued massive construction projects, conscripting laborers to garrison ________ while increasing grain levies, making taxes and labor even more oppressive.", "Xiao Lan");
        text5_en.SelectList.Add("Correct", "A. Xianyang");
        text5_en.SelectList.Add("Wrong", "B. Chang'an");
        text5_en.SelectList.Add("Wrong", "C. Luoyang");
        text5_en.Callback = () => Check_Correct5();

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

        dialogTexts_en.Add(new DialogData("Inside the tent, Chen Sheng and Wu Guang sat facing each other, surrounded by solemn garrison soldiers. On the table lay spread rice paper and writing brushes, the sound of rain tapping rhythmically. The tent was solemn, the silence thick with pre-dawn tension.", "Scene"));
        dialogTexts_en.Add(new DialogData("(Holding brush with determined gaze, speaking softly) This manifesto is crucial - it must expose Qin's tyranny to awaken the oppressed masses and unite hearts to overthrow the brutal Qin.", "Chen Sheng"));
        dialogTexts_en.Add(new DialogData("Qin's oppressive rule has lasted too long, with popular resentment boiling. Though the people suffer, they need a spark to ignite their fury - this manifesto shall be that spark.", "Wu Guang"));
        dialogTexts_en.Add(new DialogData("After hearing this, Chen Sheng took brush to paper, writing a manifesto concise yet powerful - each word bled with passion, hard as iron, sharp as blades.", "Scene"));
        dialogTexts_en.Add(new DialogData("After Qin's establishment, how were taxes and corv��e labor imposed on peasants?", "Wu Guang"));
        dialogTexts_en.Add(text1_en);
        dialogTexts_en.Add(new DialogData("How severe were Qin's laws?", "Chen Sheng"));
        dialogTexts_en.Add(text2_en);
        dialogTexts_en.Add(new DialogData("What extremely cruel punishments were implemented during Qin?", "Wu Guang"));
        dialogTexts_en.Add(text3_en);
        dialogTexts_en.Add(new DialogData("What measures did Qin Shi Huang take to control thought?", "Chen Sheng"));
        dialogTexts_en.Add(text4_en);
        dialogTexts_en.Add(new DialogData("After Qin Shi Huang's death, his successor Qin Ershi oppressed the people even more cruelly.", "Wu Guang"));
        dialogTexts_en.Add(text5_en);
        dialogTexts_en.Add(new DialogData("(Reading manifesto aloud) Qin's tyrannical rule imposes harsh laws everywhere. Heavy taxes and endless corv��e labor leave no life for the people. The state has fallen, the realm is in turmoil, the people suffer with grievances everywhere. Qin's cruel laws bind people like ropes, disregarding lives. Burning books and burying scholars shackles thought - the wise dare not speak, the people have nowhere to voice pain. The ruler's megalomania builds palaces and tombs, exhausting the nation's strength. People toil like beasts of burden with no hope of release. If this can be tolerated, what cannot?", "Wu Guang"));
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

            dialogTexts.Add(new DialogData("(�����˵��) ������˰���أ��������꣬���ղ����ظ��������������Թ���ڵĸ�Դ��", "��ʤ"));
            dialogTexts_en.Add(new DialogData("(Praising) Correct! Heavy taxes and endless corv��e labor crushed the people - this is why resentment boils over!", "Chen Sheng"));

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

            dialogTexts.Add(new DialogData("(ҡͷ�������д��ŷ��) ��˰���ء����۷��࣬���������ڰ��ݵ����ӣ��س���ѹ���ð��տ಻���ԣ�", "���"));
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

            dialogTexts.Add(new DialogData("(��ͷ�϶���������ŭ) �ԣ��س��Ŀ����ð������ı��������й�ʧ���������ﶼҪ�ܵ�ǣ��������һ�ߡ�", "��ʤ"));
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

            dialogTexts.Add(new DialogData("(��ü����������) ��ֻ�Ǹ����˵ĳͷ����ط����飬�����������Ҫ���ᡣ�����ı��������ܲ������°��շ�����", "���"));
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

            dialogTexts.Add(new DialogData("(���صص�ͷ) û���س�ʩ�е��̷��п�������������һ�����⣬�����ı����ػ��������·�����", "��ʤ"));
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

            dialogTexts.Add(new DialogData("(ҡͷ̾Ϣ) ���źͰ���Ʋ�����ֻ�Ǳ��档�س����̷��п�������֫��к������յ���������ݽ棬�������������������������壡", "���"));
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

            dialogTexts.Add(new DialogData("(������˸��ŭ֮ɫ) ���Ƿ�����壡��ʼ�ʲ������̷���ѹ���գ�����˼��������ٻ��鼮��ɱ�����������׷������յ����ǡ�", "��ʤ"));
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

            dialogTexts.Add(new DialogData("(�������) ��˲п��ֶΣ��ð��ղ����Բ����ʣ�˼�뱻������ѧ�߱�ɱ��������س�����������һ����", "���"));
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

            dialogTexts.Add(new DialogData("(�����ͳ����侲) �ض����ײб�Ű����������Ϊ�������ǣ����������ã�ʹ����������Ӽ��ѡ�", "��ʤ"));
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

            dialogTexts.Add(new DialogData("(��ŭ��ҡͷ) ���ǳ�����Ҳ�����������ض����ı����������������Ӵ󹤳��ϣ����ձ�ǿ��Ϊ��Ӫ�����������ƿ��ڱ���֮�֡�", "���"));
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
