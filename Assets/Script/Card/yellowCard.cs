using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class yellowCard : Card
{

    // Start is called before the first frame update
    //public static int hint_control;
    protected override void Start()

    {

        base.Start();    // Call the base class Start() method first
        color_ = "Yellow"; // Initialize the color_ variable in the derived class
        sr.color = new Color(1.0f, 0.92f, 0.016f, 1.0f); //給顏色
        sr.sprite = sprite;
    }

    private void Update()

    {
        //base.Update();
        card_hint_color.transform.position = new Vector3((float)(transform.position.x - 0.4), (float)(transform.position.y + 0.5), (float)(transform.position.z));

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(card_hint_color.transform.position);

        // 調整文字物件的位置
        Vector3 textPosition = screenPosition;
        textPosition.x += 85f; // 調整文字在x軸上的位置偏移量
        textPosition.y += 120f;
        textObject.transform.position = textPosition;

    }

    /*public override void tigger_color_Hints()
    {
        base.tigger_color_Hints();
        card_hint_color.SetActive(true);
        Debug.Log("提示黃色成功");
        //PlayerSystem.hint_color_control = 0;
        Card.hint_mousedown = 0;
    }

    public override void tigger_numbers_Hints()
    {
        base.tigger_numbers_Hints();
        textObject.SetActive(true);
        Debug.Log("提示數字成功");
        //PlayerSystem.hint_number_control = 0;
        Card.hint_mousedown = 0;
    }

    public void destory_hint()
    {
        card_hint_color.SetActive(false);
        textObject.SetActive(false);
    }*/
}