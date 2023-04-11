using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueCard : Card
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); // Call the base class Start() method first
        color_ = "Blue"; // Initialize the color_ variable in the derived class
    }
    
}
