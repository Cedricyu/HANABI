using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HintManager : MonoBehaviour
{
    public Card test_id;
    
    public static HintManager instance_;
    public static int hint_id;

    public void Start()
    {
        instance_ = this;
    }

    public void HintSetClickCardId(int id)
    {
        hint_id = id;
        Debug.Log(hint_id);
        test_id = GameManager.instance_.GetCardbyId(hint_id); 
    }
   
  public void hint_manager_color(){
    test_id.tigger_color_Hints(); 
  }

public void hint_manager_numbers(){
    test_id.tigger_numbers_Hints(); 
  }

}
