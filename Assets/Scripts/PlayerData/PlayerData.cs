using System;
[Serializable]
public class PlayerData
{
    public string playerName;
    public int playerScore;
    public bool isFirstPlay; //是否第一次玩
    public bool usingEnglish; //是否使用英文
    public int distracted;    //分心次数
    public int voiceuse;      //语音输入次数
    public int ChapterOneRight;  //第一章答对次数
    public int ChapterOneFalse;  //第一章答错次数
    public int ChapterTwoRight;  //第二章答对次数
    public int ChapterTwoFalse;  //第二章答错次数
}
