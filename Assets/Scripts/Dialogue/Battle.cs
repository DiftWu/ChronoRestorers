using Doublsb.Dialog;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    private void Awake()
    {
        Debug.Log("isFirst after scene switch: " + PlayerPrefs.GetInt("isFirst"));

        var dialogTexts = new List<DialogData>();
        var dialogTexts_en = new List<DialogData>();

        dialogTexts.Add(new DialogData("在探索的同时，你也可能被隐藏的怪物发现而被拉入到奇异的空间中", "神秘人"));
        dialogTexts.Add(new DialogData("根据提示通过战斗击败怪物，或者解开谜题，方能离开", "神秘人"));

        dialogTexts_en.Add(new DialogData("While exploring, you may be discovered by hidden monsters and pulled into a strange space.", "Mystery Man"));
        dialogTexts_en.Add(new DialogData("Defeat the monsters in battle or solve the puzzles as instructed to proceed.", "Mystery Man"));

        if (DataManager.Instance.playerData.usingEnglish)
        {
            DialogManager.Show(dialogTexts_en);
        }
        else
        {
            DialogManager.Show(dialogTexts);
        }
    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
