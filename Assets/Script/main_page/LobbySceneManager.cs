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
    [SerializeField]
    TMPro.TMP_Text LobbyInfo;
    public List<string> new_room_list;
    public List<int> new_room_count;
    public List<bool> new_room_state;
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
        new_room_state.Clear();
        foreach (RoomInfo roomInfo in roomList)
        {
            new_room_count.Add(roomInfo.PlayerCount);
            new_room_list.Add(roomInfo.Name);
            new_room_state.Add(roomInfo.IsOpen);
        }
    }
    public void EntryGameRoom()
    {
        string RoomName = GetRoomName();
        string PlayerName = GetPlayerName();
        //string message;
        bool roomexist = new_room_list.Contains(RoomName);

        if (PlayerName.Length > 0)
        {
            if (roomexist)
            {
                int index = new_room_list.IndexOf(RoomName);
                if (new_room_count[index] < 4 && new_room_state[index] != false)
                {
                    PhotonNetwork.JoinRoom(RoomName);
                    PhotonNetwork.LocalPlayer.NickName = PlayerName;
                    print("join room:" + RoomName);
                }
                else
                {
                    string message = "full or locked, try another one!";
                    print("full or locked, try another one!");
                    messageshow(message);

                }
            }
            else
            {
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
    public void messageshow(string message)
    {
        LobbyInfo.text = "�� " + message.ToString();
    }
}