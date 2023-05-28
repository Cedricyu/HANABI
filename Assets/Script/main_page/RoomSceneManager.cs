using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using Photon.Realtime;


public class RoomSceneManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    TMPro.TMP_Text textRoomName;
    [SerializeField]
    TMPro.TMP_Text textPlayerList;
    [SerializeField]
    Button buttonStartGame;
    void Start()
    {   
            if (PhotonNetwork.CurrentRoom == null)
            {
                SceneManager.LoadScene("LobbyScene");
                print("Room does not exist");
            }
            else
            {
                textRoomName.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
                UpdatePlayerList();
                //print(PhotonNetwork.CurrentRoom.IsOpen);
        }
            buttonStartGame.interactable = PhotonNetwork.IsMasterClient;
    }
    public override void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient)
    {
        buttonStartGame.interactable = PhotonNetwork.IsMasterClient;
    }

    // Update is called once per frame
    public void UpdatePlayerList()
    {
        StringBuilder sb = new StringBuilder();
        int count = 1;
        string playerlist;
        foreach (var kvp in PhotonNetwork.PlayerList) {
            switch(count) {
                default:
                    playerlist = "  " + count.ToString() + "TH\t\t" + kvp.NickName;break;
                case 1:
                    playerlist = "  " + count.ToString() + "ST\t\t" + kvp.NickName; break;
                case 2:
                    playerlist = "  " + count.ToString() + "ND\t\t" + kvp.NickName; break;
                case 3:
                    playerlist = "  " + count.ToString() + "RD\t\t" + kvp.NickName; break;
            }
            sb.AppendLine(playerlist);
            sb.AppendLine("-------------------------");
            count += 1;
        }
        textPlayerList.text = sb.ToString();

    }
    
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        UpdatePlayerList();
    }
    
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        UpdatePlayerList();
    }
    public void OnclickStartGame() {
        SceneManager.LoadScene("Scene01");  
        PhotonNetwork.CurrentRoom.IsOpen = false;
        
    }
    public void OnclickLeaveRoom() {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom() {
        print("leave the room");
        SceneManager.LoadScene("LobbyScene");
    }
}

