using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour //public abstract class Card : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int id_;
    [SerializeField] protected int number_;
    [SerializeField] protected string color_;
    //[SerializeField] public int hint_control;
    //public static int hint_control;    
    public static int hint_mousedown;//查看是按下hint_color還是hint_number

    private bool clickable = false;
    DeckManager dm;
    PlayerSystem player_;

    protected virtual void Start()
    {
        dm = DeckManager.Instance;
        hint_mousedown = 0;

    }
    public void SetPlayer(PlayerSystem playerSystem_)
    {
        player_ = playerSystem_;
    }

    public int getNumber()
    {
        return number_;
    }

    public string getColor()
    {
        return color_;
    }
    public int getId()
    {
        return id_;
    }

    public void cardInit(int n, int id)
    {
        number_ = n;
        id_ = id;
        return;
    }
    public void SetClickable(bool tmp)
    {
        clickable = tmp;
    }

    void OnMouseDown()
    {

        //else if (button_hint_number.hint_number_control==1){
        //    GernerateHints();
        //}

        if (clickable)
        {

            this.transform.Translate(new Vector3(0, 0.5f));
            // Destroy the gameObject after clicking on it
            player_.SetClickCardId(id_);
            Debug.Log("clicked ! " + color_ + " " + number_);
            //Destroy(gameObject);

            if (button_hint_color.hint_color_control == 1)
            {
                hint_mousedown = 1;
                Debug.Log("hint_mousedown");
                Gernerate_color_Hints();  /////////////////////////

            }
            else if (button_hint_number.hint_number_control == 1)
            {
                hint_mousedown = 2;
                Gernerate_numbers_Hints();
            }
        }
        else
        {
            return;
        }


    }

    public virtual void Gernerate_color_Hints()
    {
        GameManager.instance_.number_of_hint = GameManager.instance_.number_of_hint - 1;
        Debug.Log(GameManager.instance_.number_of_hint);
    }

    public virtual void Gernerate_numbers_Hints()
    {
        GameManager.instance_.number_of_hint = GameManager.instance_.number_of_hint - 1;
        Debug.Log(GameManager.instance_.number_of_hint);
    }
}