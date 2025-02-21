using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class King : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("��ʤ�������������������ƺƴ󣬽����������ǡ���������Э��������ΪӪ�������ڳ��ض�ǳ������ط��������������ۣ��������������Ŀ����δ������ʤ�������ƾ��£�׼�������������ų���Ȩ��", "����"));
        dialogTexts.Add(new DialogData("���أ��ǳس���������Ʈ���ʤ��������ǣ������ǻ������ϡ��ط����ܴ�ӵ�ų�ʤ���׷���ǰ�׼ơ�", "����"));
        dialogTexts.Add(new DialogData("(�������Ŀ����Ȼ) �����������������壬�����޵����ﱩ�ء������չ�ռ���أ���Ϊ����֮���ʡ��������߸�����ӦΪ�������ܺ����ķ������屩�ء�", "���ܼ�"));
        dialogTexts.Add(new DialogData("(�������ͣ���������) �������س���Ű����Թ���ڣ����������������������屩�أ���ʱ���Ƿ��ص��������������������ؿ��������ģ����ʿ����", "������"));
        dialogTexts.Add(new DialogData("(����Ƭ�̣��������ˣ�Ŀ��ᶨ������˵��)�������壬��ֹΪһ��һ��֮ʤ������Ϊ���°���ı̫ƽ����Ȼ�����ƾ٣��ұ�����������ų���Ȩ���Խ����𣬡��ų����������¹����ر�����", "��ʤ"));
        dialogTexts.Add(new DialogData("���������ߺ����ų����꣡���ش�ҵ�سɣ����������죬���ص������ڷ����������죬��������ȼ��ϣ����", "����"));
        dialogTexts.Add(new DialogData("Ϊ�˺��ٸ���������Ӧ���壬���������¹㲼ϭ�ģ���¶�س��������������ڵķ���֮�ġ�С����С������Э����ʤ��������ϭ�ģ��������������Ѫ���������졣С��С����������߷ã�������գ��׶����Ű��ն��س�������Թ�ޡ�", "����"));
        dialogTexts.Add(new DialogData("(����֣��) ��ϭ�ķ�ͬС�ɣ��뽫�س������Ѹ����£����ѱ�ѹ�ȵİ��գ������������ģ��Ʒ����ء�������ȥ̽�����飬��������������һ����֪��", "��ʤ"));
        dialogTexts.Add(new DialogData("С�졢С���������漴�߳����أ����븽���Ĵ�����ũ�", "����"));

        DialogManager.Show(dialogTexts);

    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
