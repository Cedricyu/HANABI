using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class LobbySceneManager : MonoBehaviourPunCallbacks
{
    
    void Start()
    {
        if (PhotonNetwork.IsConnected == false) {
            SceneManager.LoadScene("StartScene");
            print("connection refuesed");
        }
        else {
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnJoinedLobby()
    {
        print("Lobby joined");
    }
}
