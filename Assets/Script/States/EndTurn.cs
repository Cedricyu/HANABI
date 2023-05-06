using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EndTurn : State
{
    public EndTurn(PlayerSystem player) : base(player) { }

    public override IEnumerator End()
    {
        player_.SetState(new EnemyTurn(player_));
        GameManager.instance_.TurnEnds();
        return base.End();
    }
}
