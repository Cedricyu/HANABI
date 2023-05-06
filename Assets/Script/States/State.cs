using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class State 
{
    //public void setState(State newstate);
    protected PlayerSystem player_;
    
    public State(PlayerSystem player)
    {
        player_ = player;
    }
    public virtual IEnumerator Start()
    {
        yield break;
    }
    public virtual IEnumerator DrawCard()
    {
        yield break;
    }
    public virtual IEnumerator DiscardCard()
    {
        yield break;
    }
    public virtual IEnumerator PlayCard()
    {
        yield break;
    }
    public virtual IEnumerator GiveHints()
    {
        yield break;
    }
    public virtual IEnumerator End()
    {
        yield break;
    }

}