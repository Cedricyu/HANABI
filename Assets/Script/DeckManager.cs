using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<CardData> Deck;
    public CardData Cards;

    void Start()
    {
        generateCards();
    }

    // Update is called once per frame
    private void generateCards(){
        for(int i=0;i<5;i++)
            Deck.Add(new CardData("red",i+1));
        return;
    }
}
