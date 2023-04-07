using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<Card> Deck = new List<Card>();
    public static DeckManager Instance;

    public List<Card> discard;

    public Sprite[] sprites;


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
        int cnt =0;
        for (int i = 0; i < colors_.Count ; i++)
        {
           for(int j=0 ; j < 5 ; j++ ){
                int number_of_card =0;

                switch (j){
                    case 0:
                        number_of_card = 3;
                        break;
                    case 1:
                        number_of_card = 2;
                        break;
                    case 2:
                        number_of_card = 2;
                        break;
                    case 3:
                        number_of_card = 2;
                        break;
                    case 4:
                        number_of_card  =1;
                        break;
                    default:
                        break;
                }
                for(int k=0 ; k < number_of_card ; k++ ){
                    string CardName = colors_[i] + " " + (j+1);
                    GameObject newCardObject = new GameObject(CardName);
                    newCardObject.transform.SetParent(parentTransform);
                    newCardObject.transform.position = new Vector3((float)(this.transform.position.x - 0.01 *cnt),(float) (this.transform.position.y + 0.01*cnt) , (float)(this.transform.position.z));
                    SpriteRenderer CardSprite = newCardObject.AddComponent<SpriteRenderer>();
                    Card CardObject = null;
                    switch (i)
                    {
                        case 0:
                            CardObject = newCardObject.AddComponent<redCard>();
                            CardObject.GetComponent<redCard>().cardInit(j);
                            break;
                        case 1:
                            CardObject = newCardObject.AddComponent<blueCard>();
                            CardObject.GetComponent<blueCard>().cardInit(j);
                            break;
                        case 2:
                            CardObject = newCardObject.AddComponent<yellowCard>();
                            CardObject.GetComponent<yellowCard>().cardInit(j);
                            break;
                        case 3:
                            CardObject = newCardObject.AddComponent<whiteCard>();
                            CardObject.GetComponent<whiteCard>().cardInit(j);
                            break;
                        case 4:
                            CardObject = newCardObject.AddComponent<greenCard>();
                            CardObject.GetComponent<greenCard>().cardInit(j);
                            break;
                        default:
                            break;
                    }
                
                    Sprite mySprite = sprites[j];
                    CardSprite.sprite = mySprite;

                    Deck.Add(CardObject);
                    cnt+=1;
                }
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
