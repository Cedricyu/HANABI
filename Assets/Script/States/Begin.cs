using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : State
{
    public Begin(PlayerSystem player) : base(player) { }
    public override IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
    }
}
