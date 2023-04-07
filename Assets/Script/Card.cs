using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected int number_ ;
    [SerializeField] protected string color_ ;
    
    DeckManager dm;
    static int totalNumCard = 30;

    protected virtual void Start(){
        dm = FindObjectOfType<DeckManager>();
    }

    public int getNumber(){
        return number_;
    }

    public void ChangeNumber(int n){
        number_ = n;
        return;
    }

    public string getColor(){
        return color_;
    }
   
    public void cardInit(int n){
        number_ = n;
        return;
    }
}
