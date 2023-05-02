using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : State 
{
    public PlayerTurn(PlayerSystem player) : base(player) { }

    public override IEnumerator DrawCard()
    {
        if (!player_.DrawCard())
        {

        }
        player_.SetState(new EndTurn(player_));
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
        yield return new WaitForSeconds(1f);
    }

}
