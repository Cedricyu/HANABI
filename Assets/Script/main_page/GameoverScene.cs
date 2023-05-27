using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public class GameoverScene : MonoBehaviourPunCallbacks
{
   public void OnclickLeaveRoom()
   {
     PhotonNetwork.LeaveRoom();
   }
    public override void OnLeftRoom()
    {
     print("leave the room");
     SceneManager.LoadScene("LobbyScene");
    }
}
