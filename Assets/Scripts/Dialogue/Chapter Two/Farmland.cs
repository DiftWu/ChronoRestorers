using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Farmland : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("���յ��գ����ѵ�����У�ũ����������������ƣ�������д�����ǵ����ϡ���λ������ũ�������﹡�ߣ��������ݣ�Ŀ����ͣ��ƺ��ѱ��������ѹѹ�塣", "����"));
        dialogTexts.Add(new DialogData("(̧ͷ����̾Ϣһ������������)�����ġ�����˰һ���һ���أ��������겻�ϣ������ׯ�ڻ�û���ã���Ҫ����͢��ȥ��ʲô��Ĺ��������������Ǹ���ͷ����", "ũ���"));
        dialogTexts.Add(new DialogData("(�����Ӳ�ȥ��ˮ������������͸��ƣ̬)�ǰ�������������������������������ˡ���������ٶ��¹����ճ�Ҳ���ٵÿ������س��ô�ϲ�����������С��Ҳ������������ʹ��ţ��", "ũ����"));
        dialogTexts.Add(new DialogData("(С�����Ŵ��ԣ���ͷһ��Ŀ���ʹ����Ȼ�����س������Ͽ�����˰ѹ�˵����Ρ�)", "����"));

        DialogManager.Show(dialogTexts);

    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
