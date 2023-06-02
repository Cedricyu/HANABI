using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showErrorPoint : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    void Start()
    {
        GameObject show_error_point = GameObject.Find("ErrorPoint");
        textComponent = show_error_point.GetComponent<TextMeshProUGUI>();
        textComponent.color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance_.errorPoint == 3)
        {
            textComponent.text = "3";
        }
        else if (GameManager.instance_.errorPoint == 2)
        {
            textComponent.text = "2";
        }
        else if (GameManager.instance_.errorPoint == 1)
        {
            textComponent.text = "1";
        }
        else
        {
            textComponent.text = "0";
        }

    }
}
