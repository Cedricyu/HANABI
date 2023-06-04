using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
[System.Serializable]
public class PlayerTurn : State
{
    public PlayerTurn(PlayerSystem player) : base(player) { }

    public override IEnumerator DrawCard()
    {
        Debug.Log("draw one card");
        if (!player_.DrawCard())
        {
            yield return null;

        }
        else
        {
            player_.SetState(new EndTurn(player_));
            Debug.Log("player turn to end state");
            yield return new WaitForSeconds(1f);
        }

    }
    public override IEnumerator PlayCard()
    {
        // check card is clicked
        if (!player_.PlayCard())
        {
            yield return null;
        }
        else
        {
            //Debug.Log("ERROR points:");
            //Debug.Log(GameManager.instance_.errorPoint);
            //Debug.Log(GameManager.instance_.ErrorLessThanMax);
            if (!GameManager.instance_.ErrorLessThanMax)
            {
                PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
                if (PhotonNetwork.IsMasterClient)
                {
                    SceneManager.LoadScene("GameSuccessScene");
                }

            }
            else if (DeckManager.Instance.DeckCount > 0 && FieldManager.Instance.canWinGame())
            {
                GameManager.instance_.score = 25;
                PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
                if (PhotonNetwork.IsMasterClient)
                {
                    SceneManager.LoadScene("GameSuccessScene");
                }

            }
            else if (DeckManager.Instance.DeckCount <= 0)
            {
                GameManager.instance_.score = FieldManager.Instance.get_score();
                PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
                if (PhotonNetwork.IsMasterClient)
                {
                    SceneManager.LoadScene("GameClearScene");
                    Debug.Log("GameWin2");
                }

            }
            else
            {
                player_.SetState(new EndTurn(player_));
                Debug.Log("player turn to end state");
                yield return new WaitForSeconds(1f);
            }
        }

    }
    public override IEnumerator DiscardCard() // Player can't playing card and fold the card.
    {
        if (!player_.Discard())
        {
            yield return null;
        }
        else
        {
            player_.SetState(new EndTurn(player_));
            Debug.Log("player turn to end state");
            yield return new WaitForSeconds(1f);
        }

    }

    public override IEnumerator GiveHints()
    {

        player_.SetState(new EndTurn(player_));
        yield return new WaitForSeconds(1f);
    }

    public override IEnumerator End()
    {
        SceneManager.LoadScene("GameOver");
        yield return new WaitForSeconds(1f);
    }

    public override IEnumerator click_hint_color()
    {
        if (player_.create_hint_color())
        {
            player_.SetState(new EndTurn(player_));
            yield return new WaitForSeconds(1f);
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }
    }


    public override IEnumerator click_hint_number()
    {

        if (player_.create_hint_number())
        {
            player_.SetState(new EndTurn(player_));
            yield return new WaitForSeconds(1f);
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }

    }

}
