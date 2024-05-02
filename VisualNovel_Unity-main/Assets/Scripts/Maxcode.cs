using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maxcode : MonoBehaviour
{
    public GameObject x;
    public void Nya()
    {
        if (x!=null)
        { 
            bool r = x.activeSelf;
            x.SetActive(!r); 
        }
    }
}
