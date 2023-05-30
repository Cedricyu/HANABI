using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public class GameoverScene : MonoBehaviourPunCallbacks
{
    [SerializeField]
    TMPro.TMP_Text Score;
    public void OnclickLeaveRoom()
   {
     PhotonNetwork.LeaveRoom();
   }
    public override void OnLeftRoom()
    {
     print("leave the room");
     SceneManager.LoadScene("LobbyScene");
    }
    public void show_score() {
        if (GameManager.instance_.score <= 5)
        {
            Debug.Log("unbearably tragic");
            Score.text = GameManager.instance_.score.ToString()+ "points, unbearably tragic";
        }
        
        else if (GameManager.instance_.score <= 10)
        {
            Debug.Log("not too bad");
            Score.text = GameManager.instance_.score.ToString() + "points, not too bad";
        }
        else if (GameManager.instance_.score <= 15)
        {
            Debug.Log("It's good");
            Score.text = GameManager.instance_.score.ToString() + "points, It's good";
        }
        else if (GameManager.instance_.score <= 20)
        {
            Debug.Log("Competent");
            Score.text = GameManager.instance_.score.ToString() + "points, Competent";
        }
        else if (GameManager.instance_.score <= 24)
        {
            Debug.Log("Exceptional");
            Score.text = GameManager.instance_.score.ToString() + "points, Exceptional";
        }
        else if (GameManager.instance_.score == 25)
        {
            Debug.Log("Outstanding");
            Score.text = GameManager.instance_.score.ToString() + "points, Outstanding";
        }
        else
        {
            Debug.Log("score error");
        }
        
    }
}
