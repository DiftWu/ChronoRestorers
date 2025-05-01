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
        var dialogTexts_en = new List<DialogData>();

        dialogTexts.Add(new DialogData("��ʤ�������������������ƺƴ󣬽����������ǡ���������Э��������ΪӪ�������ڳ��ض�ǳ������ط��������������ۣ��������������Ŀ����δ������ʤ�������ƾ��£�׼�������������ų���Ȩ��", "����"));
        dialogTexts.Add(new DialogData("���أ��ǳس���������Ʈ���ʤ��������ǣ������ǻ������ϡ��ط����ܴ�ӵ�ų�ʤ���׷���ǰ�׼ơ�", "����"));
        dialogTexts.Add(new DialogData("(�������Ŀ����Ȼ) �����������������壬�����޵����ﱩ�ء������չ�ռ���أ���Ϊ����֮���ʡ��������߸�����ӦΪ�������ܺ����ķ������屩�ء�", "���ܼ�"));
        dialogTexts.Add(new DialogData("(�������ͣ���������) �������س���Ű����Թ���ڣ����������������������屩�أ���ʱ���Ƿ��ص��������������������ؿ��������ģ����ʿ����", "������"));
        dialogTexts.Add(new DialogData("(����Ƭ�̣��������ˣ�Ŀ��ᶨ������˵��)�������壬��ֹΪһ��һ��֮ʤ������Ϊ���°���ı̫ƽ����Ȼ�����ƾ٣��ұ�����������ų���Ȩ���Խ����𣬡��ų����������¹����ر�����", "��ʤ"));
        dialogTexts.Add(new DialogData("���������ߺ����ų����꣡���ش�ҵ�سɣ����������죬���ص������ڷ����������죬��������ȼ��ϣ����", "����"));
        dialogTexts.Add(new DialogData("Ϊ�˺��ٸ���������Ӧ���壬���������¹㲼ϭ�ģ���¶�س��������������ڵķ���֮�ġ�С����С������Э����ʤ��������ϭ�ģ��������������Ѫ���������졣С��С����������߷ã�������գ��׶����Ű��ն��س�������Թ�ޡ�", "����"));
        dialogTexts.Add(new DialogData("(����֣��) ��ϭ�ķ�ͬС�ɣ��뽫�س������Ѹ����£����ѱ�ѹ�ȵİ��գ������������ģ��Ʒ����ء�������ȥ̽�����飬��������������һ����֪��", "��ʤ"));
        dialogTexts.Add(new DialogData("С�졢С���������漴�߳����أ����븽���Ĵ�����ũ�", "����"));

        dialogTexts_en.Add(new DialogData("After Chen Sheng and Wu Guang led the garrison soldiers in rebellion, their momentum grew rapidly as they conquered several cities. Working together methodically, they finally captured Chen County and proclaimed their kingship. Local heroes and rebel forces gathered to passionately debate the rebellion's goals and future. With popular support, Chen Sheng prepared to declare himself king and establish the Zhang Chu regime.", "Scene"));
        dialogTexts_en.Add(new DialogData("In Chen County, with flags fluttering over the newly captured city, Chen Sheng led his troops amidst continuous cheers from the garrison soldiers. Local heroes surrounded Chen Sheng, eagerly offering their counsel.", "Scene"));
        dialogTexts_en.Add(new DialogData("(Kneeling respectfully with solemn expression) General, you led this great uprising to 'punish the unprincipled and eliminate the tyrannical Qin.' Today's capture of Chen County sets an example for all under heaven. With achievements towering above all, you should become king to command all regions and intimidate the brutal Qin.", "Hero A"));
        dialogTexts_en.Add(new DialogData("(Echoing enthusiastically) General, the Qin dynasty's cruelty has boiled popular resentment. If you don't proclaim yourself king today, how can we intimidate the tyrannical Qin? This is the perfect moment to rebel. As king, you could unite the people and boost morale.", "Hero B"));
        dialogTexts_en.Add(new DialogData("(Pausing thoughtfully, surveying the crowd with determined eyes, speaking clearly) Today's rebellion isn't just about conquering cities - it's about securing peace for all people! Since you all support me, I shall become king and establish the Zhang Chu regime. From this day forth, 'Zhang Chu' rises, and all under heaven shall oppose Qin's tyranny together!", "Chen Sheng"));
        dialogTexts_en.Add(new DialogData("The crowd roared in unison: 'Long live Zhang Chu! The anti-Qin cause will surely succeed!' Their thunderous cheers shook the heavens as rebel banners snapped in the wind, kindling hope in everyone's hearts.", "Scene"));
        dialogTexts_en.Add(new DialogData("To rally more people to their cause, they needed to spread manifestos exposing Qin's tyranny and stirring popular resistance. Xiao Hong and Xiao Lan were tasked with helping Chen Sheng and Wu Guang draft these manifestos - every word must bleed with passion and cry to the heavens. They planned to leave the city and visit villages, listening firsthand to people's grievances against Qin oppression.", "Scene"));
        dialogTexts_en.Add(new DialogData("(Speaking gravely) These manifestos are crucial - they must announce Qin's tyranny to the world and awaken the oppressed masses, uniting all hearts to overthrow the brutal Qin. Go quickly to investigate people's conditions and report everything you witness.", "Chen Sheng"));
        dialogTexts_en.Add(new DialogData("Xiao Hong and Xiao Lan accepted their orders and immediately left Chen County, heading toward nearby villages and farmlands.", "Scene"));

        DialogManager.Show(dialogTexts);

    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
