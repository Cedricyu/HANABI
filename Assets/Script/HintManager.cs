using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HintManager : MonoBehaviour
{
    public static HintManager instance_;

    public void Start()
    {
        instance_ = this;
    }


    public void Click()
    {
        Debug.Log("Yes");
    }

    GameObject Card;
    public Card test_id;
    public int hint_id;
    public void update(){
        hint_id=test_id.getId(); ///回傳id值
        test_id=GameManager.instance_.GetCardbyId(hint_id);
    }
   
  public void hint_manager_color(){
    test_id.tigger_color_Hints(); 
  }

public void hint_manager_numbers(){
    test_id.tigger_numbers_Hints(); 
  }

}
