using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class StartSceneManager : MonoBehaviourPunCallbacks
{
    public void OnclickStart() {
        PhotonNetwork.ConnectUsingSettings();
        print("click start");
    }
    public override void OnConnectedToMaster() {
        print("Connected");
        SceneManager.LoadScene("LobbyScene");
    }
}
