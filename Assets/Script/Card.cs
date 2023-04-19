using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected int number_ ;
    [SerializeField] protected string color_ ;
    
    DeckManager dm;
    
    protected virtual void Start(){
        dm = FindObjectOfType<DeckManager>();
    }

    public int getNumber(){
        return number_;
    }

    public string getColor(){
        return color_;
    }
   
    public void cardInit(int n){
        number_ = n;
        return;
    }
    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        Debug.Log("clicked !");
        Destroy(gameObject);
    }
}
