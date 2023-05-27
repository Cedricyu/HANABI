using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

[System.Serializable]
public class EndGame : State
{
    public EndGame(PlayerSystem player):base(player) { }

    public override IEnumerator End()
    {
        SceneManager.LoadScene("GameoverScene");
        return base.End();
    }
}
