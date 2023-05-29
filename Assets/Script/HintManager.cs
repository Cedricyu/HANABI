using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HintManager : MonoBehaviour
{
    public static HintManager instance_;

    public void Start()
    {
        instance_ = this;
    }


    public void Click()
    {
        Debug.Log("Yes");
    }

}


