using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EndTurn : State
{
    public EndTurn(PlayerSystem player) : base(player)
    {
        player.InitClickCardId();
        GameManager.instance_.InitAllPlayerShowClickCardId(); // avoid click card and then draw card situation
    }

    public override IEnumerator End()
    {
        player_.SetState(new EnemyTurn(player_));
        GameManager.instance_.TurnEnds();
        return base.End();
    }
}
