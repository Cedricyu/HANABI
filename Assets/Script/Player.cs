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
    private PlayerSystem player_;

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


    public async void StartTurn()
    {
        PhotonView.Get(this).RPC("StartTurn", RpcTarget.All);
        await Turn();
        EndTurn();
    }

    public async Task Turn()
    {


        while( !(player_.GetState() is EndTurn) ) {
            //Debug.Log(player_.GetState());
            await Task.Delay(3000);

        }
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
