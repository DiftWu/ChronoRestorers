using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject ob;
    // Start is called before the first frame update
    public void Set()
    {
        ob.SetActive(!ob.activeSelf);
    }
}
