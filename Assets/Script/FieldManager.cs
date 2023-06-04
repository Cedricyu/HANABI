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
                c.transform.rotation = fields[i].rotation;

            }
            AdjustLayerOrder(field[i]);
        }

    }

    public void PlayCard(Card playCard)
    {
        Debug.Log(playCard);
        Debug.Log("color " + playCard.getColor() + " number " + playCard.getNumber());
        if (playCard is redCard && (redCards.Count + 1 == playCard.getNumber()))
        {
            Debug.Log("red");
            PhotonView.Get(this).RPC("UpdateField", RpcTarget.All, playCard.getId(), 0);
            playCard.ShowCardOriginalImage();

        }
        else if (playCard is blueCard && (blueCards.Count + 1 == playCard.getNumber()))
        {
            Debug.Log("blue");
            PhotonView.Get(this).RPC("UpdateField", RpcTarget.All, playCard.getId(), 1);
            playCard.ShowCardOriginalImage();

        }
        else if (playCard is whiteCard && (whiteCards.Count + 1 == playCard.getNumber()))
        {
            Debug.Log("white");
            PhotonView.Get(this).RPC("UpdateField", RpcTarget.All, playCard.getId(), 2);
            playCard.ShowCardOriginalImage();

        }
        else if (playCard is greenCard && (greenCards.Count + 1 == playCard.getNumber()))
        {
            Debug.Log("green");
            PhotonView.Get(this).RPC("UpdateField", RpcTarget.All, playCard.getId(), 3);
            playCard.ShowCardOriginalImage();

        }
        else if (playCard.GetType() == typeof(yellowCard) && (yellowCards.Count + 1 == playCard.getNumber()))
        {
            Debug.Log("yellow");
            PhotonView.Get(this).RPC("UpdateField", RpcTarget.All, playCard.getId(), 4);
            playCard.ShowCardOriginalImage();

        }
        // add to disacrd pile
        else
        {
            GameManager.instance_.RPCPlaySoundEffect(GameManager.SoundEffect.PlayCardfail);
            GameManager.instance_.updatePoints(GameManager.Point.ErrorPoint);
            if (!GameManager.instance_.ErrorLessThanMax)
            {
                /// end game 
            }
            PhotonView.Get(this).RPC("UpdateField", RpcTarget.All, playCard.getId(), 5);
        }
        ///
    }
    public void Discard(Card playCard)
    {
        PhotonView.Get(this).RPC("UpdateField", RpcTarget.All, playCard.getId(), 5);
        GameManager.instance_.updatePoints(GameManager.Point.HintPointPlus);


    }

    [PunRPC]
    public void UpdateField(int id, int pos)
    {
        Card tmp = GameManager.instance_.GetCardbyId(id);
        if (pos > 4)
        {
            tmp.transform.position = discard.position;
            discardPile.Add(tmp);
            tmp.SetOnFieldOrNot(true);
            tmp.destory_hint();
        }
        else
        {
            GameManager.instance_.RPCPlaySoundEffect(GameManager.SoundEffect.PlayCardSuccess);
            tmp.transform.position = fields[pos].position;
            field[pos].Add(tmp);
            tmp.SetOnFieldOrNot(true);
            tmp.destory_hint();
        }
    }

    public void AdjustLayerOrder(List<Card> colorPile)
    {
        for (int num = 0; num < colorPile.Count; num++)
        {
            if (num == colorPile.Count - 1)
            {
                colorPile[num].GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            else
            {
                colorPile[num].GetComponent<SpriteRenderer>().sortingOrder = 1;
            }

        }
    }
    public bool canWinGame()
    {
        if (redCards.Count == 5 && blueCards.Count == 5 && yellowCards.Count == 5 && whiteCards.Count == 5 && greenCards.Count == 5)
        {
                return true;
        }
        else
        {
            return false;
        }
    }
    public int get_score()
    {
        int score = redCards.Count + blueCards.Count + yellowCards.Count + whiteCards.Count + greenCards.Count;
        return score;
    }
}
