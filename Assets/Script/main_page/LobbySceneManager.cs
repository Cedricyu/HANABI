using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Realtime;
using System.Text;
public class LobbySceneManager : MonoBehaviourPunCallbacks
{
    //[SerializeField]
    //TMPro.TMP_InputField inputRoomName;
    [SerializeField]
    TMPro.TMP_InputField inputPlayerName;
    //[SerializeField]
    //TMPro.TMP_Text textroomList;
    public List<string> new_room_list;
    public List<int> new_room_count;
    void Start()
    {
        if (PhotonNetwork.IsConnected == false)
        {
            SceneManager.LoadScene("StartScene");
            print("connection refuesed");
        }
        else
        {
            if (PhotonNetwork.CurrentLobby == null)
            {
                PhotonNetwork.JoinLobby();
            }

        }
    }
    public string GetRoomName()
    {
        string roomName = EventSystem.current.currentSelectedGameObject.name;
        return roomName.Trim();
    }
    public string GetPlayerName()
    {
        string playerName = inputPlayerName.text;
        return playerName.Trim();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        new_room_list.Clear();
        new_room_count.Clear();
        foreach (RoomInfo roomInfo in roomList)
        {
            new_room_count.Add(roomInfo.PlayerCount);
            new_room_list.Add(roomInfo.Name);
        }
    }
    public void EntryGameRoom()
    {
        string RoomName = GetRoomName();
        string PlayerName = GetPlayerName();
        //print("roomlist:");
        //foreach (string room in new_room_list) {
        //    print(room);
        //}
        //print("---------------");
        bool roomexist = new_room_list.Contains(RoomName);
        //print("roomexist=" + roomexist.ToString());
        //print(RoomName);
       // print(PlayerName);
        
        if (PlayerName.Length > 0) {
            if (roomexist)
            {
                int index = new_room_list.IndexOf(RoomName);
                if (new_room_count[index] < 4)
                {
                    PhotonNetwork.JoinRoom(RoomName);
                    PhotonNetwork.LocalPlayer.NickName = PlayerName;
                    print("join room:" + RoomName);
                }
                else 
                {
                    print("full room");    
                }
            }
            else {
                PhotonNetwork.CreateRoom(RoomName);
                PhotonNetwork.LocalPlayer.NickName = PlayerName;
                print("create room:" + RoomName);
            }
        }
    }
    public override void OnJoinedRoom()
    {
        print("Room joined!");
        SceneManager.LoadScene("RoomScene");
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to Master!");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        print("Lobby joined");
    }

    /* 
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
     */

    /*
    public override void OnRoomListUpdate(List<RoomInfo> roomList){
        print("update room list");
        int count = 1;
        StringBuilder sb = new StringBuilder();
        foreach (RoomInfo roomInfo in roomList) {
            if (roomInfo.PlayerCount < 4){
                sb.AppendLine(count.ToString() + ". " + roomInfo.Name + " : " + roomInfo.PlayerCount);
                count += 1;
            }
        }
        textroomList.text = sb.ToString();
    }
    */
}