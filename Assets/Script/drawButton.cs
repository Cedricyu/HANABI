using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drawButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button mybutton_;
    void Start()
    {
        mybutton_ = GetComponent<Button>();
        mybutton_.onClick.AddListener(onClick);
    }

    void onClick()
    {
        print("click");
        Player.instance_.drawCard();
    }
}
