using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blueCard : Card
{
    private GameObject card_hint_color;
    private Transform cardHintTransform;
    private SpriteRenderer sr;
    private Sprite sprite;
    // Start is called before the first frame update
    protected override void Start()
    
    {

        base.Start();    // Call the base class Start() method first
        color_ = "Blue"; // Initialize the color_ variable in the derived class
        card_hint_color=new GameObject("Blue");
        card_hint_color.SetActive(false);
        card_hint_color.transform.parent = transform;

        sr = card_hint_color.AddComponent<SpriteRenderer>() as SpriteRenderer;
        card_hint_color.transform.localScale = new Vector3(transform.localScale.x*40,  transform.localScale.y*70, transform.localScale.z*2);;
        sprite = Resources.Load<Sprite>("color");//放入color.png
        sr.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);//給顏色
       
        sr.sprite = sprite;
         
    }

    private void Update()
    
    {
        card_hint_color.transform.position=new Vector3((float)(transform.position.x),(float) (transform.position.y + 0.08) , (float)(transform.position.z));
        Debug.Log(card_hint_color.transform.position);
        if(card_hint_color.transform.position.x<4){
            Debug.Log("the blue card is switch");
            OnCardPositionChanged();
            
        }

    }

    private void OnCardPositionChanged()
    {
        card_hint_color.SetActive(true);
        
    }



    public override void GernerateHints(){
        base.GernerateHints();//先創數字hint

    }
}
