using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyTurn : State 
{
    public EnemyTurn(PlayerSystem player) : base(player) { }

}
