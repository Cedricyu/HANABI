using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Card> Hands;
    private PhotonView pv_;
    public PhotonView Pv_ { get { return pv_; } }
    private PlayerSystem player_;
    public PlayerSystem Player_ { get { return player_; } }

    private void FixedUpdate()
    {
        Hands = player_.GetHands;
    }

    public void Start()
    {
        pv_ = GetComponent<PhotonView>();
        player_ = GetComponent<PlayerSystem>();

        // test code
        if (!pv_.IsMine)
            GameManager.instance_.SetEnemy(this);
        else
            GameManager.instance_.SetPlayer(this);
        ///
    }


    public void Initialize()
    {
        PhotonView.Get(this).RPC("InitializePlayer", RpcTarget.All);
    }


    public void StartTurn()
    {
        PhotonView.Get(this).RPC("StartTurn", RpcTarget.All);
        StartCoroutine(Turn());
    }

    public IEnumerator Turn()
    {
        yield return new WaitUntil(() => player_.GetState() is EndTurn);
        EndTurn();
    }

    public void EndTurn()
    {
        player_.EndTurn();
    }

    public PlayerSystem GetPlayerSystem()
    {
        return player_;
    }
}
