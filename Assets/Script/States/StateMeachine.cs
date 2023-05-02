using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class StateMeachine : MonoBehaviour
{
    protected State state_;

    public void SetState(State state)
    {
        state_ = state;
        StartCoroutine(state_.Start());
    }
}
