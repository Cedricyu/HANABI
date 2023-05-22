using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int id_;
    [SerializeField] protected int number_;
    [SerializeField] protected string color_;
    private bool clickable = false;

    DeckManager dm;
    PlayerSystem player_;

    protected virtual void Start()
    {
        dm = DeckManager.Instance;

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
    public void SetClickable(bool tmp)
    {
        clickable = tmp;
    }

    void OnMouseDown()
    {
        if (clickable)
        {
            this.transform.Translate(new Vector3(0, 0.5f));
            // Destroy the gameObject after clicking on it
            player_.SetClickCardId(id_);
            Debug.Log("clicked ! " + color_ + " " + number_);
            //Destroy(gameObject);
        }
        else
        {
            return;
        }

    }

    public virtual void GernerateHints()
    {

    }
}
