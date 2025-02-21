using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Prison : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("С�졢С������������η����η��ڻ谵��ʪ��ǽ�ڰ߲��������Ǹ������޺ۣ��ݹ���ᾣ����о��Ǿ��������������������Թۣ����ޱ��飬����ֻ���������ǵĵ���������", "����"));
        dialogTexts.Add(new DialogData("(������Į��üͷ����) ��������Щ��������������ˣ�һ�������������ɣ��������ž������̡��������ţ�����ն�ף�ȫ����СҲ�������⡣", "����"));
        dialogTexts.Add(new DialogData("(������̧��ͷ�����в���Ѫ˿��������������) ���ˣ�С��ʵ���������帳˰���ű�����˵ء������������壬�䲻�����£�ȴ����һ��֮����ٸ���ȥ���ۣ��������������ҡ��������������ȴ��Ը�������ᰡ��", "����"));
        dialogTexts.Add(new DialogData("С����ͷ̾Ϣ���������޹�����֮�࣬������Ȼ��������֮��������ͷ��", "����"));
  
        DialogManager.Show(dialogTexts);

    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
