using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeckManager : MonoBehaviourPun
{
    // Start is called before the first frame update

    [SerializeField] List<Card> Deck = new List<Card>();
    [SerializeField] List<int> cardIds;
    public static DeckManager Instance;

    public List<Card> discard;

    public List<Sprite[]> CardImages = new List<Sprite[]>();

    [SerializeField] Sprite[] white;
    [SerializeField] Sprite[] red;
    [SerializeField] Sprite[] green;
    [SerializeField] Sprite[] blue;
    [SerializeField] Sprite[] yellow;


    public List<string> colors_;

    Transform parentTransform;

    void Start()
    {
        parentTransform = this.transform;
        Instance = this;

        colors_.Add("red");
        colors_.Add("blue");
        colors_.Add("yellow");
        colors_.Add("white");
        colors_.Add("green");

        CardImages.Add(red);
        CardImages.Add(blue);
        CardImages.Add(yellow);
        CardImages.Add(white);
        CardImages.Add(green);
        generateCards();
    }

    // Update is called once per frame
    private void generateCards()
    {
        int cnt = 0;
        for (int i = 0; i < colors_.Count; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                int number_of_card = 0;

                switch (j)
                {
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
                        number_of_card = 1;
                        break;
                    default:
                        break;
                }
                for (int k = 0; k < number_of_card; k++)
                {
                    string CardName = colors_[i] + " " + (j + 1);
                    GameObject newCardObject = new GameObject(CardName);
                    BoxCollider2D collider = newCardObject.AddComponent<BoxCollider2D>();
                    collider.size = new Vector3(9f, 12f, 2f);

                    newCardObject.AddComponent<PhotonView>();
                    newCardObject.transform.SetParent(parentTransform);
                    newCardObject.transform.position = new Vector3((float)(this.transform.position.x - 0.01 * cnt), (float)(this.transform.position.y + 0.01 * cnt), (float)(this.transform.position.z));
                    newCardObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    SpriteRenderer CardSprite = newCardObject.AddComponent<SpriteRenderer>();
                    CardSprite.sortingOrder = 1;
                    Card CardObject = null;
                    switch (i)
                    {
                        case 0:
                            CardObject = newCardObject.AddComponent<redCard>();
                            CardObject.GetComponent<redCard>().cardInit(j + 1, cnt);
                            break;
                        case 1:
                            CardObject = newCardObject.AddComponent<blueCard>();
                            CardObject.GetComponent<blueCard>().cardInit(j + 1, cnt);
                            break;
                        case 2:
                            CardObject = newCardObject.AddComponent<yellowCard>();
                            CardObject.GetComponent<yellowCard>().cardInit(j + 1, cnt);
                            break;
                        case 3:
                            CardObject = newCardObject.AddComponent<whiteCard>();
                            CardObject.GetComponent<whiteCard>().cardInit(j + 1, cnt);
                            break;
                        case 4:
                            CardObject = newCardObject.AddComponent<greenCard>();
                            CardObject.GetComponent<greenCard>().cardInit(j + 1, cnt);
                            break;
                        default:
                            break;
                    }

                    Sprite mySprite = CardImages[i][j];
                    CardSprite.sprite = mySprite;

                    GameManager.instance_.objectPool_.Add(CardObject);
                    Deck.Add(CardObject);
                    cardIds.Add(cnt);
                    cnt += 1;
                }
            }
        }

    }

    // call this using 
    public Card DrawCard()
    {

        if (Deck.Count <= 0)
            return null;

        Card randomCard = Deck[Random.Range(0, Deck.Count)];

        Deck.Remove(randomCard);
        cardIds.Remove(randomCard.getId());
        CallRPC(randomCard.getId());

        return randomCard;
    }

    public void CallRPC(int id)
    {
        this.photonView.RPC("ReceiveData", RpcTarget.All, id);
    }

    [PunRPC]
    void ReceiveData(int id)
    {
        cardIds.Remove(id);
        Deck.Remove(GameManager.instance_.GetCardbyId(id));
        return;
    }


}
