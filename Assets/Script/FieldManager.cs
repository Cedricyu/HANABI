using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FieldManager : MonoBehaviourPun
{
    public static FieldManager Instance;
    private List<List<Card>> field = new List<List<Card>>();
    [SerializeField] List<Card> redCards;
    [SerializeField] List<Card> whiteCards;
    [SerializeField] List<Card> blueCards;
    [SerializeField] List<Card> greenCards;
    [SerializeField] List<Card> yellowCards;
    [SerializeField] List<Card> discardPile;

    [SerializeField] List<Transform> fields;
    [SerializeField] Transform discard;

    public void Start()
    {
        Instance = this;
        field.Add(redCards);
        field.Add(blueCards);
        field.Add(whiteCards);
        field.Add(greenCards);
        field.Add(yellowCards);
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < field.Count; i++)
        {
            foreach (Card c in field[i])
            {
                c.transform.position = fields[i].position;
            }
        }
    }

    public bool canPlay(Card playCard)
    {
        Debug.Log(playCard);
        Debug.Log("color " + playCard.getColor() + " number " + playCard.getNumber());
        if (playCard is redCard && (redCards.Count + 1 == playCard.getNumber()))
        {
            Debug.Log("red");
            PhotonView.Get(this).RPC("ReveiveData", RpcTarget.All, playCard.getId(), 0);
            AdjustLayerOrder(playCard, redCards);
        }
        else if (playCard is blueCard && (blueCards.Count + 1 == playCard.getNumber()))
        {
            Debug.Log("blue");
            PhotonView.Get(this).RPC("ReveiveData", RpcTarget.All, playCard.getId(), 1);
            AdjustLayerOrder(playCard, blueCards);
        }
        else if (playCard is whiteCard && (whiteCards.Count + 1 == playCard.getNumber()))
        {
            Debug.Log("white");
            PhotonView.Get(this).RPC("ReveiveData", RpcTarget.All, playCard.getId(), 2);
            AdjustLayerOrder(playCard, whiteCards);
        }
        else if (playCard is greenCard && (greenCards.Count + 1 == playCard.getNumber()))
        {
            Debug.Log("green");
            PhotonView.Get(this).RPC("ReveiveData", RpcTarget.All, playCard.getId(), 3);
            AdjustLayerOrder(playCard, greenCards);
        }
        else if (playCard.GetType() == typeof(yellowCard) && (yellowCards.Count + 1 == playCard.getNumber()))
        {
            Debug.Log("yellow");
            PhotonView.Get(this).RPC("ReveiveData", RpcTarget.All, playCard.getId(), 4);
            AdjustLayerOrder(playCard, yellowCards);
        }
        else
        {
            PhotonView.Get(this).RPC("ReveiveData", RpcTarget.All, playCard.getId(), 5);
            AdjustLayerOrder(playCard, discardPile);
            return false;
        }
        return true;
    }


    [PunRPC]
    public void ReveiveData(int id, int pos)
    {
        Card tmp = GameManager.instance_.GetCardbyId(id);
        if (pos > 4)
        {
            tmp.transform.position = discard.position;
            discardPile.Add(tmp);
            tmp.SetClickable(false);
        }
        else
        {
            tmp.transform.position = fields[pos].position;
            field[pos].Add(tmp);
            tmp.SetClickable(false);
        }
    }

    public void AdjustLayerOrder(Card playCard, List<Card> colorPile)
    {
        foreach (Card playedCard in colorPile)
        {
            playedCard.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }

        playCard.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
}
