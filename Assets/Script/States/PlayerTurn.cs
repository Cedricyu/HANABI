using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class PlayerTurn : State
{
    public PlayerTurn(PlayerSystem player) : base(player) { }

    public override IEnumerator DrawCard()
    {
        Debug.Log("draw one card");
        if (!player_.DrawCard())
        {

        }
        player_.SetState(new EndTurn(player_));
        Debug.Log("player turn to end state");
        yield return new WaitForSeconds(1f);
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
                SceneManager.LoadScene("GameOverScene");

            }
            else if (DeckManager.Instance.DeckCount > 0 && FieldManager.Instance.canWinGame())
            {
                SceneManager.LoadScene("GameSuccessScene");
                Debug.Log("GameWin1");
                player_.SetState(new EndGame(player_, 1));
                yield return new WaitForSeconds(1f);

            }
            else if (DeckManager.Instance.DeckCount <= 0)
            {
                SceneManager.LoadScene("GameSuccessScene");
                Debug.Log("GameWin2");
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
        //PlayerSystem.hint_color_control = 1;
        player_.create_hint_color();
        //Debug.Log("click_hint_color_success");
        yield return new WaitForSeconds(1f);
    }


    public override IEnumerator click_hint_number()
    {
        player_.create_hint_number();
        //PlayerSystem.hint_number_control = 1;
        yield return new WaitForSeconds(1f);
    }

}
