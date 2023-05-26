using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class blueCard : Card
{
    private GameObject card_hint_color;
    private GameObject textObject;
    private RectTransform textRectTransform;
    private Transform cardHintTransform;
    private SpriteRenderer sr;
    private Sprite sprite;
    // Start is called before the first frame update
    protected override void Start()
    
    {

        base.Start();    // Call the base class Start() method first
        color_ = "Blue"; // Initialize the color_ variable in the derived class
        
        //color_hint_setting
        card_hint_color=new GameObject("Blue");
        card_hint_color.SetActive(false);
        card_hint_color.transform.parent = transform;

        sr = card_hint_color.AddComponent<SpriteRenderer>() as SpriteRenderer;
        card_hint_color.GetComponent<SpriteRenderer>().sortingOrder = 1;
        card_hint_color.transform.localScale = new Vector3(transform.localScale.x*15,  transform.localScale.y*67, transform.localScale.z*2);
        sprite = Resources.Load<Sprite>("color");//放入color.png
        sr.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);//給顏色
        sr.sprite = sprite;
        //color_hint_setting

        //數字的提示
        Canvas canvas = FindObjectOfType<Canvas>();
        textObject = new GameObject("number_");
        textObject.transform.SetParent(canvas.transform, false);//放在畫布下
        
        TextMeshProUGUI textComponent  = textObject.AddComponent<TextMeshProUGUI>();
        textComponent.fontSize=56;
        textComponent.color = Color.black; // 設定文字顏色為黑色
        // 設定文字的位置
        textRectTransform = textObject.GetComponent<RectTransform>();
        textObject.SetActive(false);
        //textObject.transform.parent = transform;
        //textObject.transform.localScale = new Vector3(transform.localScale.x*15,  transform.localScale.y*67, transform.localScale.z*2);;
        //textObject.sortingOrder = 3;
        if (number_==1){      
             textComponent.text = "1";
        }  
        else if (number_==2){
             textComponent.text = "2";
        }
        else if (number_==3){
            textComponent.text = "3";
        }
        else if (number_==4){
            textComponent.text = "4";
        }
        else {
            textComponent.text = "5";
        }
        //數字的提示


         
    }

    private void Update()
    
    {
        //Debug.Log(number_);
        card_hint_color.transform.position=new Vector3((float)(transform.position.x-0.4),(float) (transform.position.y + 0.5) , (float)(transform.position.z));
        
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(card_hint_color.transform.position);

        // 調整文字物件的位置
        Vector3 textPosition = screenPosition;
        textPosition.x += 85f; // 調整文字在x軸上的位置偏移量
        textPosition.y += 120f;
        textObject.transform.position = textPosition;
    }
    
    public override void Gernerate_color_Hints(){
        base.Gernerate_color_Hints();
        card_hint_color.SetActive(true);
        Debug.Log("提示藍色成功");
        button_hint_color.hint_color_control=0;
        Card.hint_mousedown=0;
    }

    public override void Gernerate_numbers_Hints()
    {
        base.Gernerate_numbers_Hints();
        textObject.SetActive(true);
        Debug.Log("提示數字成功");
        button_hint_number.hint_number_control=0;
        Card.hint_mousedown=0;
    }

   public void destory_hint(){
        card_hint_color.SetActive(false);
        textObject.SetActive(false);
    }
}
