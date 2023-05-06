using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EndGame : State
{
    public EndGame(PlayerSystem player):base(player) { }

    public override IEnumerator End()
    {
        return base.End();
    }
}
