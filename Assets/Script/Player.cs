using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<Card> Hands;
    static int hand_max = 5;
    //DeckManager DM;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void drawCard(){
        if(Hands.Count > 5 )
            return;
        Card newCard = DeckManager.Instance.DrawCard();
        Debug.Log("draw one card");
        Hands.Add(newCard);

    }
}
