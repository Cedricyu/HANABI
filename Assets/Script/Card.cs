using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int id_;
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
    public int getId()
    {
        return id_;
    }
   
    public void cardInit(int n,int id){
        number_ = n;
        id_ = id;
        return;
    }
    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        Debug.Log("clicked !");
        Destroy(gameObject);
    }
}
