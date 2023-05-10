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
        }
        else {
            textRoomName.text = "Room: "+PhotonNetwork.CurrentRoom.Name;
            UpdatePlayerList();
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
        foreach (var kvp in PhotonNetwork.CurrentRoom.Players) {
            sb.AppendLine(count.ToString() + ". " + kvp.Value.NickName);
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
    }
    public void OnclickLeaveRoom() {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom() {
        print("leave the room");
        SceneManager.LoadScene("LobbyScene");
    }
}

