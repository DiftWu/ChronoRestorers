using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using System.IO;

public class Farmland : MonoBehaviour
{
    public DialogManager DialogManager;
    public GameObject ob;

    public GameObject[] Example;

    void Start()
    {
        ob.SetActive(false);
    }
    private void Awake()
    {
        var dialogTexts = new List<DialogData>();
        var dialogTexts_en = new List<DialogData>();

        dialogTexts.Add(new DialogData("���յ��գ����ѵ�����У�ũ����������������ƣ�������д�����ǵ����ϡ���λ������ũ�������﹡�ߣ��������ݣ�Ŀ����ͣ��ƺ��ѱ��������ѹѹ�塣", "����"));
        dialogTexts.Add(new DialogData("(̧ͷ����̾Ϣһ������������)�����ġ�����˰һ���һ���أ��������겻�ϣ������ׯ�ڻ�û���ã���Ҫ����͢��ȥ��ʲô��Ĺ��������������Ǹ���ͷ����", "ũ���"));
        dialogTexts.Add(new DialogData("(�����Ӳ�ȥ��ˮ������������͸��ƣ̬)�ǰ�������������������������������ˡ���������ٶ��¹����ճ�Ҳ���ٵÿ������س��ô�ϲ�����������С��Ҳ������������ʹ��ţ��", "ũ����"));
        dialogTexts.Add(new DialogData("(С�����Ŵ��ԣ���ͷһ��Ŀ���ʹ����Ȼ�����س������Ͽ�����˰ѹ�˵����Ρ�)", "����"));
        dialogTexts.Add(new DialogData("������ʱ��һ�ӹٱ�ע�⵽�˴˴���", "����"));
        dialogTexts.Add(new DialogData("�Ǳߵģ���������ʲô�����ܼ�飡", "�ٱ�"));
        dialogTexts.Add(new DialogData("�G�����ǿ��߰ɣ��ʹ������������ܰɡ�", "ũ���"));

        dialogTexts_en.Add(new DialogData("Under the scorching sun, farmers toil in the parched fields, exhaustion and despair written on their faces. Two elderly farmers sit by the field ridge, their faces lined with worry, eyes dull - seemingly crushed by life's burdens.", "Scene"));
        dialogTexts_en.Add(new DialogData("(Looking up at the sky with a sigh, face full of resignation) Oh heavens... The taxes grow heavier each year, and the corv��e labor never ends. Before our crops can even mature, the court takes us away to build tombs and palaces. When will this suffering end?", "Farmer A"));
        dialogTexts_en.Add(new DialogData("(Wiping sweat with sleeve, voice weak and tired) Indeed. With endless forced labor, all our field workers get conscripted. No matter how hard we work the land, the harvest remains pitifully small. The Qin dynasty chases grandiose achievements while common folk like us are treated as mere beasts of burden.", "Farmer B"));
        dialogTexts_en.Add(new DialogData("(Xiao Hong hears this and is deeply moved, her pained eyes silently recording the Qin dynasty's harsh corv��e labor and oppressive taxation.)", "Scene"));
        dialogTexts_en.Add(new DialogData("Just then, a squad of government soldiers notices the group.", "Scene"));
        dialogTexts_en.Add(new DialogData("You there! What are you doing? Submit for inspection!", "Soldier"));
        dialogTexts_en.Add(new DialogData("Hey, you'd better leave quickly. Escape through the wheat field.", "Farmer A"));

        DialogManager.Show(dialogTexts);

    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
