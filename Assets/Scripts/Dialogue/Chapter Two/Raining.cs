using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Raining : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    public void Awake()
    {
        var dialogTexts = new List<DialogData>();
        var dialogTexts_en = new List<DialogData>();

        dialogTexts.Add(new DialogData("�����磬��������ܲ���������������ʪ����ѹ�֡���ʤ���������900��������������������޷����ڵ������صء���������ƣ������·���ѣ�������Ţ������ǰ;δ���������᧿�Σ����ˮ������ÿ���˵ļ�ͷ���·�ѹ�����Ǹ��ӳ��ء��س��ı���������ͬ��ѹ������գ��������Դ�Ϣ��", "����"));
        dialogTexts.Add(new DialogData("(̧ͷ���������ܲ�����ʣ�����̾Ϣ����δͣ��·���С��ٲ���������ʱ����ֻ�������ѱ���", "�����"));
        dialogTexts.Add(new DialogData("(�����߿��űߵ�������������͸�����Σ����ڼ�ն�����Ǹ����ˣ�����Ҳ����·һ������ߵ�Զ���ҵȲ����ǳ�͢�Ĳݽ棬�����л�·��", "������"));
        dialogTexts.Add(new DialogData("(�侲ɨ�����ˣ������ͳ����ᶨ�����ʱ�ޣ����ɵ�ն�����ҽ�֪����͢�������̣�˭�����⣿���硭���������Դ��У����粫һ����·��", "���"));
        dialogTexts.Add(new DialogData("(Ŀ����棬���������ᶨ�������´��ң����տ಻���ԡ��������ݣ��������꣬�س���Ű�����ҵ���ţ���������ڼ�������ȥ���أ��಻��Ϊ��֮͢ۻ���������ѱ������乶����練��������׳ʿ���β���һս��棬�����,�����ֺ���", "��ʤ"));
        dialogTexts.Add(new DialogData("(Ŀ����˸�������д���һ˿�������ڴ����´������Լ��ǣ����䱻ն��������췴�أ�ƴ��һ����", "�����"));
        dialogTexts.Add(new DialogData("(��������ظ��ͣ�������ˣ����ر�������Ȱ��գ�", "������"));
        dialogTexts.Add(new DialogData("(�����������ǣ��׷�Ӧ�ͣ��������ס���ʤ�����ĺ��ٵ�ȼ�����������ĵ�ŭ�����в߷��ɹ������ص�ŭ���ڴ�����ȼ�𡣣�", "�԰�"));

        dialogTexts_en.Add(new DialogData("In Daze Village, dark clouds blanketed the sky as a damp, oppressive air hung heavy. Chen Sheng and Wu Guang's 900 garrison soldiers, delayed by torrential rains, couldn't reach their post on time. Exhausted and struggling through the mud, their future uncertain and honor at stake, each raindrop on their shoulders seemed to weigh them down further. The Qin dynasty's tyranny loomed like the stormy sky itself, making it hard to breathe.", "Scene"));
        dialogTexts_en.Add(new DialogData("(Looking up at the clouded sky with a quiet sigh) The rain won't stop, the road's impassable. If we don't move soon and miss the deadline, our lives are forfeit.", "Soldier A"));
        dialogTexts_en.Add(new DialogData("(Kicking mud angrily, voice full of resignation) Late arrival means execution - but even if we make it, garrison duty is another death sentence. We're just worthless grass to the court - where's our path to survival?", "Soldier B"));
        dialogTexts_en.Add(new DialogData("(Scanning the crowd calmly with determined tone) Missing the deadline means death by law. We all know the court's harsh punishments spare none. Rather than waiting for death... shouldn't we fight for survival?", "Wu Guang"));
        dialogTexts_en.Add(new DialogData("(Eyes blazing, voice growing stronger) The realm is in chaos, the people suffer endlessly. Conscription without end, neverending taxes and labor - the Qin tyranny treats us like beasts! Today, being late means death, but garrison duty would make us sacrificial lambs anyway. Rather than living meekly, let's rebel! Are we not men as good as any noble or king? Who says kings and generals are born to their stations?", "Chen Sheng"));
        dialogTexts_en.Add(new DialogData("(Eyes flashing with tremulous hope) Lord Chen speaks truth! Better to raise the rebel banner than be executed!", "Soldier A"));
        dialogTexts_en.Add(new DialogData("(Passionately agreeing) Exactly! Overthrow Qin's tyranny, save our people!", "Soldier B"));
        dialogTexts_en.Add(new DialogData("(The crowd's fervor erupts in thunderous agreement. Chen Sheng and Wu Guang's words ignite the soldiers' fury. Their rebellion succeeds in the rain, and the flames of revolution kindle in Daze Village.)", "Narrator"));

        DialogManager.Show(dialogTexts);

    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
