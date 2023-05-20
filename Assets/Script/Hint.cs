using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    [SerializeField] private int id_;
    [SerializeField] protected int number_ ;
    [SerializeField] protected string color_ ;
    [SerializeField] public Image image;
    DeckManager dm;
    
    protected virtual void Start(){
        dm = DeckManager.Instance;
    }

    public int getNumber(){
        return number_;
    }

    public string getColor(){
        return color_;
    }

    public void OnMouseDown()
    {
        Debug.Log("clicked !");
        H();

    }

   public void H(){
    //if(color_==white)
    image.GetComponent<Image>().color = new Color32(255,255,225,100);
    Debug.Log(color_);
    Debug.Log(number_);
   }

}
