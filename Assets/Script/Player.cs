using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<Card> Hands;
    public float[] position = new float[]{-6f, -4f, -2f, 2f, 4f, 6f};
    static int hand_max = 5;
    GameObject Card;
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
        Hands.Add(newCard);
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
