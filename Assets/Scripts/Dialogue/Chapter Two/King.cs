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

        dialogTexts.Add(new DialogData("陈胜、吴广率戍卒起义后，声势浩大，接连攻克数城。众人齐心协力，步步为营，终于在陈县夺城称王。地方豪杰与起义军齐聚，激烈讨论起义的目标与未来。陈胜在众人推举下，准备称王，建立张楚政权。", "场景"));
        dialogTexts.Add(new DialogData("陈县，城池初降，旗帜飘扬，陈胜率众人入城，戍卒们欢呼不断。地方豪杰簇拥着陈胜，纷纷上前献计。", "场景"));
        dialogTexts.Add(new DialogData("(跪拜行礼，目光肃然) 将军，您率领大军起义，‘伐无道，诛暴秦’，今日攻占陈县，当为天下之表率。将军功高盖世，应为王，方能号令四方，震慑暴秦。", "豪杰甲"));
        dialogTexts.Add(new DialogData("(随声附和，语气激动) 将军，秦朝暴虐，民怨沸腾，今日若不称王，何以震慑暴秦？此时正是反秦的良机，将军若称王，必可凝聚民心，振奋士气。", "豪杰乙"));
        dialogTexts.Add(new DialogData("(沉吟片刻，环视众人，目光坚定，朗声说道)今日起义，不止为一城一地之胜，乃是为天下百姓谋太平！既然众人推举，我便称王，建立张楚政权。自今日起，‘张楚’立，天下共反秦暴政！", "陈胜"));
        dialogTexts.Add(new DialogData("众人齐声高呼：张楚万岁！反秦大业必成！，声势震天，反秦的旗帜在风中猎猎作响，众人心中燃起希望。", "场景"));
        dialogTexts.Add(new DialogData("为了号召更多民众响应起义，必须向天下广布檄文，揭露秦朝暴政，激起民众的反抗之心。小红与小蓝受命协助陈胜、吴广起草檄文，务必做到字字泣血，呼声震天。小红小蓝打算出城走访，深入百姓，亲耳听闻百姓对秦朝暴政的怨恨。", "场景"));
        dialogTexts.Add(new DialogData("(语气郑重) 此檄文非同小可，须将秦朝暴政昭告天下，唤醒被压迫的百姓，方能凝聚众心，推翻暴秦。你们速去探访民情，回来后将所闻所见一并告知。", "陈胜"));
        dialogTexts.Add(new DialogData("小红、小蓝领命，随即走出陈县，进入附近的村落与农田。", "场景"));

        DialogManager.Show(dialogTexts);

    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
