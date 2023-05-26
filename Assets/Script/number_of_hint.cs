using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class number_of_hint : MonoBehaviour
{
    // Start is called before the first frame update

    private TextMeshProUGUI textComponent;
    void Start()
    {
        GameObject showhint = GameObject.Find("number of hints");
        textComponent  = showhint.GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Card.number_of_hint==10){
           textComponent.text="10";
        }
        else if (Card.number_of_hint==9){
           textComponent.text="9";
        }
          else if (Card.number_of_hint==8){
           textComponent.text="8";
        }
          else if (Card.number_of_hint==7){
           textComponent.text="7";
        }
          else if (Card.number_of_hint==6){
           textComponent.text="6";
        }
          else if (Card.number_of_hint==5){
           textComponent.text="5";
        }
          else if (Card.number_of_hint==4){
           textComponent.text="4";
        }
          else if (Card.number_of_hint==3){
           textComponent.text="3";
        }
          else if (Card.number_of_hint==2){
           textComponent.text="2";
        }
          else{
           textComponent.text="1";
        }

    }
}
