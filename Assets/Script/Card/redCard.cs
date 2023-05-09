using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redCard : Card
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); // Call the base class Start() method first
        color_ = "Red"; // Initialize the color_ variable in the derived class
    }
    
}
