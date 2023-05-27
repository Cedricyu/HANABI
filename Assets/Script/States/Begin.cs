using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class Begin : State
{
    public Begin(PlayerSystem player) : base(player) { }
    public override IEnumerator Start()
    {
        for(int i = 0; i < 5; i ++)
            player_.DrawCard();
        player_.SetState(new EnemyTurn(player_));
        yield return new WaitForSeconds(3f);
    }

    public override IEnumerator End()
    {
        yield return new WaitForSeconds(3f);
    }
}
