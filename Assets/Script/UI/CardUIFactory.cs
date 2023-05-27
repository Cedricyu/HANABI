using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUIFactory : MonoBehaviour
{
    public GameObject Content;
    void CreateCardImage(Card target)
    {
        GameObject imgObject = new GameObject();
        CanvasRenderer cr = imgObject.AddComponent<CanvasRenderer>();
        Image img = imgObject.AddComponent<Image>();
        RectTransform rt = imgObject.AddComponent<RectTransform>();
        SpriteRenderer sr = target.GetComponent<SpriteRenderer>();
        img.sprite = sr.sprite;
        img.transform.SetParent(Content.transform);
    }
}
