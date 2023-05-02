using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public drawButton db;
    public List<Card> objectPool_;
    public static GameManager instance_;

    private void Start()
    {
        instance_ = this;
    }

    public Card GetCardbyId(int id)
    {
        return objectPool_[id];
    }
}
