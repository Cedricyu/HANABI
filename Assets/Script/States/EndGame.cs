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
        if (GameManager.instance_.errorPoint == GameManager.instance_.errorPoint_max) {
            Debug.Log("GameOver");
            SceneManager.LoadScene("GameoverScene");
        }
        return base.End();
    }
}
