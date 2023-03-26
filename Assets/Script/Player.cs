using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<Card> Hands;
    void Start()
    {
        Debug.Log("Color :" + Hands[0].getColor() + " Number:"+ Hands[0].getNumber()) ;
        // changing private variables 
        Hands[0].ChangeNumber(3);
        Debug.Log("Color :" + Hands[0].getColor() + " Number:"+ Hands[0].getNumber()) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void drawCard(){

    }
}
