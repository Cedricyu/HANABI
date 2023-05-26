using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_hint_color : MonoBehaviour
{
    public static int hint_color_control;
    
    // Start is called before the first frame update
    void Start()
    {
        hint_color_control=0;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click_hint_color(){
        hint_color_control=1;
        //Debug.Log("click_hint_color_success");
    }
}
