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


    [PunRPC]
    public void UpdateHands(int option,int id, PhotonMessageInfo info)
    {
        Debug.Log("Info : ", info.photonView);
        if(option == 0)
        {
            Hands.Add(GameManager.instance_.GetCardbyId(id));
        }
        else if(option == 1){
            Hands.Remove(GameManager.instance_.GetCardbyId(id));
        }
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
            Debug.Log(player_.GetState());
            await Task.Delay(5000);
        }
    }

    public void EndTurn()
    {
        player_.EndTurn();
    }
}
