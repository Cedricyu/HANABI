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
            if (FieldManager.Instance.canWinGame())
            {
                Debug.Log("GameWin");
                player_.SetState(new EndGame(player_, 1));
                yield return new WaitForSeconds(1f);

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
            // TODO player_.SetState()
        }
        player_.SetState(new EndTurn(player_));
        Debug.Log("player turn to end state");
        yield return new WaitForSeconds(1f);
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
        PlayerSystem.hint_color_control = 1;
        Debug.Log("click_hint_color_success");
        yield return new WaitForSeconds(1f);
    }


    public override IEnumerator click_hint_number()
    {
        PlayerSystem.hint_number_control = 1;
        yield return new WaitForSeconds(1f);
    }

}
