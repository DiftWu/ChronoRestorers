using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using System.IO;

public class Raining : MonoBehaviour
{
    public DialogManager DialogManager;
    public GameObject Dialog;
    public bool isActive = false;

    public GameObject[] Example;

    void Start()
    {
        //Dialog.SetActive(false);
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
        if (isActive)
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("�����磬��������ܲ���������������ʪ����ѹ�֡���ʤ���������900��������������������޷����ڵ������صء���������ƣ������·���ѣ�������Ţ������ǰ;δ���������᧿�Σ����ˮ������ÿ���˵ļ�ͷ���·�ѹ�����Ǹ��ӳ��ء��س��ı���������ͬ��ѹ������գ��������Դ�Ϣ��", "����"));
            dialogTexts.Add(new DialogData("(̧ͷ���������ܲ�����ʣ�����̾Ϣ����δͣ��·���С��ٲ���������ʱ����ֻ�������ѱ���", "�����"));
            dialogTexts.Add(new DialogData("(�����߿��űߵ�������������͸�����Σ����ڼ�ն�����Ǹ����ˣ�����Ҳ����·һ������ߵ�Զ���ҵȲ����ǳ�͢�Ĳݽ棬�����л�·��", "������"));
            dialogTexts.Add(new DialogData("(�侲ɨ�����ˣ������ͳ����ᶨ�����ʱ�ޣ����ɵ�ն�����ҽ�֪����͢�������̣�˭�����⣿���硭���������Դ��У����粫һ����·��", "���"));
            dialogTexts.Add(new DialogData("(Ŀ����棬���������ᶨ�������´��ң����տ಻���ԡ��������ݣ��������꣬�س���Ű�����ҵ���ţ���������ڼ�������ȥ���أ��಻��Ϊ��֮͢ۻ���������ѱ������乶����練��������׳ʿ���β���һս��棬�����,�����ֺ���", "��ʤ"));
            dialogTexts.Add(new DialogData("(Ŀ����˸�������д���һ˿�������ڴ����´������Լ��ǣ����䱻ն��������췴�أ�ƴ��һ����", "�����"));
            dialogTexts.Add(new DialogData("(��������ظ��ͣ�������ˣ����ر�������Ȱ��գ�", "������"));
            dialogTexts.Add(new DialogData("(�����������ǣ��׷�Ӧ�ͣ��������ס���ʤ�����ĺ��ٵ�ȼ�����������ĵ�ŭ�����в߷��ɹ������ص�ŭ���ڴ�����ȼ�𡣣�", "�԰�"));

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

}
