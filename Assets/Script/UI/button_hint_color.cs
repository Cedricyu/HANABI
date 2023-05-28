using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_hint_color : MonoBehaviour
{
    public Button mybutton_;
    
    // Start is called before the first frame update
    void Start()
    {
        mybutton_ = GetComponent<Button>();
        //hint_color_control=0;
    }


}
