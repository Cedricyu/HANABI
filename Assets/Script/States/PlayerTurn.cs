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
        if (!player_.DrawCard())
        {

        }
        player_.SetState(new EndTurn(player_));
        Debug.Log("player turn to end state");
        yield return new WaitForSeconds(1f);
    }

    public override IEnumerator PlayCard()
    {
        if (!player_.PlayCard())
        {
            if (!player_.Discard())
            {
                player_.SetState(new EndGame(player_));
            }
        }
        player_.SetState(new EndTurn(player_));
        Debug.Log("player turn to end state");
        yield return new WaitForSeconds(1f);
    }
    public override IEnumerator DiscardCard()
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

}
