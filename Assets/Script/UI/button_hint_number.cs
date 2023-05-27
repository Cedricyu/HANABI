using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_hint_number : MonoBehaviour
{
    public static int hint_number_control;
    
    // Start is called before the first frame update
    void Start()
    {
        hint_number_control=0;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click_hint_number(){
        hint_number_control=1;
    }
}
