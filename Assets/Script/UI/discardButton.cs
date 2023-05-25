using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class discardButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button mybutton_;
    void Start()
    {
        mybutton_ = GetComponent<Button>();
    }
}

