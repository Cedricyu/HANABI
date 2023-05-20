using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour //public abstract class Card : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int id_;
    [SerializeField] protected int number_ ;
    [SerializeField] protected string color_ ;
    [SerializeField] public GameObject image;
    
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
    public int getId()
    {
        return id_;
    }
   
    public void cardInit(int n,int id){
        number_ = n;
        id_ = id;
        return;
    }
    public void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        Debug.Log("clicked !");
        GernerateHints();
        //Debug.Log(color_);
        //Destroy(gameObject);
    }

   public virtual void GernerateHints()

   {
    //if(color_==white)
        //生成白色的object
        //image.GetComponent<Renderer>().material.color = new Color32(255,255,225,100);
        Debug.Log(color_);
        Debug.Log(number_);
   }

}
