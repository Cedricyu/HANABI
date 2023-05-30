using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HintManager : MonoBehaviour
{


    public static HintManager instance_;

    private void Start()
    {
        instance_ = this;
    }

    public void RpcHintManagerColor(int cardId)
    {
        PhotonView.Get(this).RPC("hint_manager_color", RpcTarget.All, cardId);
    }

    [PunRPC]
    public void hint_manager_color(int id)
    {
        Card c = GameManager.instance_.GetCardbyId(id);
        c.tigger_color_Hints();
    }

    public void RpcHintManagerNumbers(int id)
    {
        PhotonView.Get(this).RPC("hint_manager_numbers", RpcTarget.All, id);
    }

    [PunRPC]
    public void hint_manager_numbers(int id)
    {
        Card c = GameManager.instance_.GetCardbyId(id);
        c.tigger_numbers_Hints();
    }

}
