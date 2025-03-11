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
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("在探索的同时，你也可能被隐藏的怪物发现而被拉入到奇异的空间中", "神秘人"));
        dialogTexts.Add(new DialogData("根据提示通过战斗击败怪物，或者解开谜题，方能离开", "神秘人"));

        DialogManager.Show(dialogTexts);

    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }
}
