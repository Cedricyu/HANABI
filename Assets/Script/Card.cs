using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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

    [SerializeField] protected GameObject card_hint_color;
    [SerializeField] protected GameObject textObject;
    [SerializeField] protected RectTransform textRectTransform;
    [SerializeField] protected Transform cardHintTransform;
    [SerializeField] protected SpriteRenderer sr;
    [SerializeField] protected Sprite sprite;


    protected virtual void Start()
    {
        dm = DeckManager.Instance;
        hint_mousedown = 0;
        Gernerate_Hints();

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

        if (!OnFieldOrNot && GameManager.instance_.OnYourTurnOrNot())
        {

            if (clicked)
            {

                // Destroy the gameObject after clicking on it
                player_.SetClickCardId(id_);
                Debug.Log("clicked ! " + color_ + " " + number_);
                //Destroy(gameObject);
                //tigger_color_Hints();
                /*if (PlayerSystem.hint_color_control == 1)
                {
                    hint_mousedown = 1;

                    Debug.Log("hint_mousedown111111111111");
                    tigger_color_Hints();

                }
                else if (PlayerSystem.hint_number_control == 1)
                {
                    hint_mousedown = 2;
                    tigger_numbers_Hints();
                }*/
                clicked = !clicked;
            }

            else
            {
                player_.InitClickCardId();
                clicked = !clicked;
            }

        }
    }

    public void Gernerate_Hints(){
        //color_hint_setting
        card_hint_color = new GameObject("my_hint_color");//----
        card_hint_color.SetActive(false);
        card_hint_color.transform.parent = transform;

        sr = card_hint_color.AddComponent<SpriteRenderer>() as SpriteRenderer;
        card_hint_color.GetComponent<SpriteRenderer>().sortingOrder = 1;
        card_hint_color.transform.localScale = new Vector3(transform.localScale.x * 15, transform.localScale.y * 67, transform.localScale.z * 2);
        sprite = Resources.Load<Sprite>("color");

        //數字的提示
        Canvas canvas = FindObjectOfType<Canvas>();
        textObject = new GameObject("number_");
        textObject.transform.SetParent(canvas.transform, false); //放在畫布下

        TextMeshProUGUI textComponent = textObject.AddComponent<TextMeshProUGUI>();
        textComponent.fontSize = 56;
        textComponent.color = Color.black; // 設定文字顏色為黑色
        // 設定文字的位置
        textRectTransform = textObject.GetComponent<RectTransform>();
        textObject.SetActive(false);
        
        if (number_ == 1)
        {
            textComponent.text = "1";
        }
        else if (number_ == 2)
        {
            textComponent.text = "2";
        }
        else if (number_ == 3)
        {
            textComponent.text = "3";
        }
        else if (number_ == 4)
        {
            textComponent.text = "4";
        }
        else
        {
            textComponent.text = "5";
        }
        //數字的提示
    }


    public void tigger_color_Hints() //public virtual void tigger_color_Hints()
    {
        card_hint_color.SetActive(true);
        GameManager.instance_.updatePoints(GameManager.Point.HintPointMinus);
    }

    public void tigger_numbers_Hints()
    {
        textObject.SetActive(true);
        GameManager.instance_.updatePoints(GameManager.Point.HintPointMinus);
    }

    public void destory_hint()
    {
        card_hint_color.SetActive(false);
        textObject.SetActive(false);
    }
}