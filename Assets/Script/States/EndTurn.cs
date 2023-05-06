using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EndTurn : State
{
    public EndTurn(PlayerSystem player) : base(player) { }

    public override IEnumerator End()
    {
        player_.Player_.EndTurn();
        return base.End();
    }
}
