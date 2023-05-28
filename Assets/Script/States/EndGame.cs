using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

[System.Serializable]
public class EndGame : State
{
    public int WinorLose;
    public EndGame(PlayerSystem player,int end_state):base(player) {
       WinorLose = end_state;
       
    }

    public override IEnumerator End()
    {
        if (WinorLose == 1) {
            SceneManager.LoadScene("GameSuccessScene");
            return base.End();
        }

        else
        {
            SceneManager.LoadScene("GameoverScene");
            return base.End();
        }
    }
}
