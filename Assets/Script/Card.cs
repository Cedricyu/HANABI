using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int id_;
    [SerializeField] protected int number_;
    [SerializeField] protected string color_;


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
    void OnMouseDown()
    {
        player_ = GetComponent<PlayerSystem>();
        // Destroy the gameObject after clicking on it
        // transform.position += Vector3.up * 5;
        Debug.Log("clicked !");
        player_.play_id = id_;
        //Destroy(gameObject);
    }

    public virtual void GernerateHints()
    {

    }
}
