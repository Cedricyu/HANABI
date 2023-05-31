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
    [SerializeField] private bool clicked = true;
    [SerializeField] private bool OnFieldOrNot = false;
    DeckManager dm;
    [SerializeField] PlayerSystem player_;
    public PlayerSystem Player_ { get { return player_; } }
    [SerializeField] Sprite originalImage_;

    [SerializeField] public GameObject card_hint_color;
    [SerializeField] protected GameObject textObject;
    [SerializeField] protected RectTransform textRectTransform;
    [SerializeField] protected Transform cardHintTransform;
    [SerializeField] protected SpriteRenderer sr;
    [SerializeField] protected Sprite sprite;


    protected virtual void Start()
    {
        dm = DeckManager.Instance;
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
            GameManager.instance_.InitAllPlayerShowClickCardId();
            PlayerSystem tmpPlayerSystem = GameManager.instance_.WhoIsPlayNow();
            if (clicked)
            {
                tmpPlayerSystem.SetClickCardId(id_);
                player_.SetShowClickCardId(id_);
                Debug.Log("clicked ! " + color_ + " " + number_);

                clicked = !clicked;
            }

            else
            {

                tmpPlayerSystem.InitClickCardId();
                clicked = !clicked;
            }


        }
    }

    public void Gernerate_Hints()
    {
        //color_hint_setting
        card_hint_color = new GameObject("my_hint_color");//----
        card_hint_color.SetActive(false);
        card_hint_color.transform.parent = transform;

        sr = card_hint_color.AddComponent<SpriteRenderer>() as SpriteRenderer;
        card_hint_color.GetComponent<SpriteRenderer>().sortingOrder = 1;
        card_hint_color.transform.localScale = new Vector3(transform.localScale.x * 15, transform.localScale.y * 65, transform.localScale.z * 2);
        card_hint_color.transform.position = new Vector3((float)(transform.position.x - 0.4), (float)(transform.position.y + 1), (float)(transform.position.z));
        sprite = Resources.Load<Sprite>("color");

        //數字的提示
        Canvas canvas = FindObjectOfType<Canvas>();
        textObject = new GameObject("number_");
        textObject.transform.SetParent(canvas.transform, false); //放在畫布下

        TextMeshProUGUI textComponent = textObject.AddComponent<TextMeshProUGUI>();
        textComponent.fontSize = 56;
        textComponent.color = Color.white; // 設定文字顏色為白
        // 設定文字的位置
        //textRectTransform = textObject.GetComponent<RectTransform>();
        //textRectTransform.transform.position=new Vector3((float)(transform.position.x - 0.4), (float)(transform.position.y + 2), (float)(transform.position.z));
        //textRectTransform.transform.position=card_hint_color.transform.position;
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
    }

    public void tigger_numbers_Hints()
    {
        textObject.SetActive(true);
    }

    public void destory_hint()
    {
        card_hint_color.SetActive(false);
        textObject.SetActive(false);
    }
}