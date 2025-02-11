using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Dialog : MonoBehaviour
{
  // Start is called before the first frame update
    public void ShowDialog(GameObject Dialog)
    {
        Dialog.SetActive(true);
    }

    public void HideDialog(GameObject Dialog)
    {
        Dialog.SetActive(false);
    }
}
