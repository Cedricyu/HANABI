using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<Card> Hands;


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
}
