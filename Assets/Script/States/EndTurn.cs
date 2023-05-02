using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : State
{
    public EndTurn(PlayerSystem player) : base(player) { }

    public override IEnumerator End()
    {
        return base.End();
    }
}
