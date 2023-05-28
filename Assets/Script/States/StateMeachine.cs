using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class StateMeachine : MonoBehaviour
{
    [SerializeField] protected State state_;

    public void SetState(State state)
    {
        state_ = state;
        //StartCoroutine(state_.Start());
    }

    public State GetState()
    {
        return state_;
    }
}
