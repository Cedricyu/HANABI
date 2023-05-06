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
    [SerializeField] List<Card> Hands;
    private PhotonView pv_;

    public void Start()
    {
        pv_ = GetComponent<PhotonView>();
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
        if (pv_.IsMine)
        {
            PhotonView.Get(this).RPC("StartTurn", RpcTarget.All);
            await Turn();
            EndTurn();
        }
    }

    public async Task Turn()
    {

        while( !(GetComponent<PlayerSystem>().GetState() is EndTurn) ) {
            Debug.Log(GetComponent<PlayerSystem>().GetState());
            await Task.Delay(1000);
        }
    }

    public void EndTurn()
    {
        GameManager.instance_.TurnEnds();
    }
}
