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

    [SerializeField] private bool clicked = true;
    [SerializeField] private bool OnFieldOrNot = false;
    DeckManager dm;
    [SerializeField] PlayerSystem player_;
    [SerializeField] Sprite originalImage_;


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
    public void SetOnFieldOrNot(bool tmp)
    {
        OnFieldOrNot = tmp;
    }

    public void SetCardOriginalImage(Sprite cardSprite)
    {
        this.originalImage_ = cardSprite;
    }

    public void ShowCardOriginalImage()
    {
        SpriteRenderer cardSprite = this.GetComponent<SpriteRenderer>();
        cardSprite.sprite = originalImage_;
    }

    void OnMouseDown()
    {

        //Debug.Log(player_); //抓到是誰的
        if (!OnFieldOrNot && GameManager.instance_.OnYourTurnOrNot())
        {

            if (clicked)
            {

                // Destroy the gameObject after clicking on it
                player_.SetClickCardId(id_);
                Debug.Log("clicked ! " + color_ + " " + number_);
                //Destroy(gameObject);

                if (PlayerSystem.hint_color_control == 1)
                {
                    hint_mousedown = 1;

                    Debug.Log("hint_mousedown111111111111");
                    Gernerate_color_Hints();

                }
                else if (PlayerSystem.hint_number_control == 1)
                {
                    hint_mousedown = 2;
                    Gernerate_numbers_Hints();
                }
                clicked = !clicked;
            }

            else
            {
                player_.InitClickCardId();
                clicked = !clicked;
            }

        }



    }




    public virtual void Gernerate_color_Hints()
    {
        GameManager.instance_.updatePoints(GameManager.Point.HintPointMinus);
    }

    public virtual void Gernerate_numbers_Hints()
    {
        GameManager.instance_.updatePoints(GameManager.Point.HintPointMinus);
    }
}