using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yellowCard : Card
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); // Call the base class Start() method first
        color_ = "Yellow"; // Initialize the color_ variable in the derived class
    }

    public override void GernerateHints(){
        base.GernerateHints();//先創數字hint
        Debug.Log("kioed");
        
    }
}
