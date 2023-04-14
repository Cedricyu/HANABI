using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<Card> Hands;
    int[] position = new int[]{-6, -4, -2, 0, 2, 4};
    static int hand_max = 5;
    GameObject Card;
    int position_count = 0;
    //DeckManager DM;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void drawCard(){
        if(Hands.Count > hand_max )
            return;
        Card newCard = DeckManager.Instance.DrawCard();
        Debug.Log("draw one card");
        Vector3 move = newCard.transform.position;
        move.x = position[position_count];
        move.y = -1;
        newCard.transform.position = move;
        Hands.Add(newCard);
        position_count = position_count + 1;
        if(position_count > 5){
            position_count = 0;
        }

    }
    
    public void playCard(){
        if(FieldManager.Instance.canPlay(Hands[Hands.Count-1])){
            Debug.Log(true);
        }
        else{
            Debug.Log(false);
        }
        Hands.Remove(Hands[Hands.Count-1]);
    }

}
