using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Realtime;
using System.Text;
public class LobbySceneManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    TMPro.TMP_InputField inputRoomName;
    [SerializeField]
    TMPro.TMP_InputField inputPlayerName;
    [SerializeField]
    TMPro.TMP_Text textroomList;

    void Start(){
        if (PhotonNetwork.IsConnected == false) 
        {
            SceneManager.LoadScene("StartScene");
            print("connection refuesed");
        }
        else {
            if (PhotonNetwork.CurrentLobby == null) {
                PhotonNetwork.JoinLobby();
            }
            
        }
    }

    public override void OnConnectedToMaster() {
        print("Connected to Master!");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby(){
        print("Lobby joined");
    }
    public string GetRoomName() {
        string roomName = inputRoomName.text;
        return roomName.Trim();
    }
    public string GetPlayerName() {
        string playerName = inputPlayerName.text;
        return playerName.Trim();
    }
    public void OnClickCreateRoom(){
        string roomName = GetRoomName();
        string playerName = GetPlayerName();
        if (roomName.Length > 0 && playerName.Length>0)
        {
            PhotonNetwork.CreateRoom(roomName);
            PhotonNetwork.LocalPlayer.NickName = playerName;
            print("create and join room success");
        }
        else 
        {
            print("Invalid room name or playername");
        }
    }

    public void OnClickJoinRoom() {
        string roomName = GetRoomName();
        string playerName = GetPlayerName();
        if (roomName.Length > 0 && playerName.Length > 0)
        {
            PhotonNetwork.JoinRoom(roomName);
            PhotonNetwork.LocalPlayer.NickName = playerName;
            print("join room success");
        }
        else {
            print("Invalid Room Name");
        }
    }

    public override void OnJoinedRoom(){
        print("Room joined!");
        SceneManager.LoadScene("RoomScene");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList){
        print("update room list");
        int count = 1;
        StringBuilder sb = new StringBuilder();
        foreach (RoomInfo roomInfo in roomList) {
            if (roomInfo.PlayerCount > 0 && roomInfo.PlayerCount < 4){
                sb.AppendLine(count.ToString() + ". " + roomInfo.Name + " : " + roomInfo.PlayerCount);
                count += 1;
            }
        }
        textroomList.text = sb.ToString();
    }
}
