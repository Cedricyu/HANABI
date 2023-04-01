using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<Card> Deck = new List<Card>();
    public static DeckManager Instance;

    public List<Card> discard;

    public Card Card;


    public List<string> colors_;

    Transform parentTransform ;

    void Start()
    {
        parentTransform = this.transform;
        Instance = this;

        colors_.Add("red");
        colors_.Add("blue");
        colors_.Add("yellow");
        colors_.Add("white");
        colors_.Add("green");
        generateCards();
    }

    // Update is called once per frame
    private void generateCards()
    {
        for (int i = 0; i < colors_.Count ; i++)
        {
           for(int j=0 ; j < 5 ; j++ ){
                Card newCard = new Card(colors_[i], j+1);
                string CardName = colors_[i] + " " + (j+1);
                GameObject newCardObject = new GameObject(CardName);
                newCardObject.transform.SetParent(parentTransform);
                newCardObject.transform.position = this.transform.position;
                SpriteRenderer CardSprite = newCardObject.AddComponent<SpriteRenderer>();

                Card CardObject = newCardObject.AddComponent<Card>();
                CardObject.GetComponent<Card>().CopyFrom(newCard);

                Sprite mySprite = Card.sprites[j];
                CardSprite.sprite = mySprite;

                Deck.Add(CardObject);
           }
        }
        
    }

    // call this using 
    public Card DrawCard(){

        if(Deck.Count <=0 )
            return null;

        Card randomCard = Deck[Random.Range(0, Deck.Count)];

        Deck.Remove(randomCard);

        return randomCard;
    }

}
