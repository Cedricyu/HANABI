using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class blueCard : Card
{
    GameObject card_hint_color;
    private Sprite blueSquareSprite; // 蓝色正方形的纹理
    private RectTransform canvasRectTransform;
    private Image imageComponent;
    private Transform cardHintTransform;
    private Canvas canvasComponent;
    private Vector3 previousPosition; // 上一帧的位置
    private SpriteRenderer sr;
    private Sprite sprite;
     
    // Start is called before the first frame update
    protected override void Start()
    
    {

        base.Start(); // Call the base class Start() method first
        color_ = "Blue"; // Initialize the color_ variable in the derived class
        card_hint_color=new GameObject("test_Blue");//////它要給誰
        //card_hint_color.transform.position = new Vector3((float)(transform.position.x),(float) (transform.position.y + 0.08) , (float)(transform.position.z));
        //card_hint_color.SetActive(false);
        card_hint_color.transform.parent = transform;
        sr = card_hint_color.AddComponent<SpriteRenderer>() as SpriteRenderer;
        //sr.color = new Color(0.9f, 0.9f, 0.9f, 1.0f);
        //sprite = Resources.Load<Sprite> ("Assets/Sprites/blue.png");
        sprite = Resources.Load<Sprite>("blue.png");
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
        //card_hint_color.SetActive(false);
        
    }



    public override void GernerateHints(){
        base.GernerateHints();//先創數字hint

    }
}
