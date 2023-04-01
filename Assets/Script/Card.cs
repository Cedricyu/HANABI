using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int number_ ;
    [SerializeField] private string color_ ;
    public Sprite[] sprites;
    //DeckManager dm;
    static int totalNumCard = 30;

    void Start(){
        dm = FindObjectOfType<DeckManager>();
    }

    public void CopyFrom(Card otherCard)
    {
        number_ = otherCard.number_;
        color_ = otherCard.color_;
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
    
    public void Play(){

    }
    public Card(string color, int number){
        color_  = color;
        number_ = number;
    }
}
