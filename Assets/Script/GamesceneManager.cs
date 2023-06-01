using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class GamesceneManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.CurrentRoom == null)
        {
            SceneManager.LoadScene("LobbyScene");
        }
        else
        {
            PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // test the failed and finish work correctly 
    public void GiveUpTheGame() {
        PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
        if (PhotonNetwork.IsMasterClient)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    public void FinishTheGame() {
        SceneManager.LoadScene("GameSuccessScene");
    }
}
