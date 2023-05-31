using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HintManager : MonoBehaviour
{
    
    public static HintManager instance_;
    [SerializeField] PlayerSystem player_;


    public static HintManager instance_;

    private void Start()
    {
        instance_ = this;
    }

    public void RpcHintManagerColor(int Id)
    {
      PhotonView.Get(this).RPC("hint_manager_color", RpcTarget.All, Id);
    }

    [PunRPC]
    public void hint_manager_color(int Id){
      Card card_id= GameManager.instance_.GetCardbyId(Id);
      card_id.tigger_color_Hints();    
    }

    public void RpcHintManagerNumbers(int Id)
    {
      PhotonView.Get(this).RPC("hint_manager_numbers", RpcTarget.All, Id);
    }

    [PunRPC]
    public void hint_manager_numbers(int Id){
        Card card_id= GameManager.instance_.GetCardbyId(Id);
        card_id.tigger_numbers_Hints(); 
    }

}
