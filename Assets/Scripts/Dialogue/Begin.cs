using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Begin : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Press esc to select language options.", "³¡¾°"));
        DialogManager.Show(dialogTexts);

    }
}
