using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    private int number = 5;
    private int color = 3;

    public int getNumber(){
        return number;
    }

    public void ChangeNumber(int n){
        number = n;
        return;
    }

    public int getColor(){
        return color;
    }
    
    public void Play(){

    }
}
