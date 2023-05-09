using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowCard : Card
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); // Call the base class Start() method first
        color_ = "Yellow"; // Initialize the color_ variable in the derived class
    }
}
