using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class Begin : State
{
    public Begin(PlayerSystem player) : base(player) { }
    public override IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
    }
}
