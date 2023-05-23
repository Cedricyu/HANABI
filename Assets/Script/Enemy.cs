using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Transform> transforms_;
    [SerializeField] Player player_;

    //public static Enemy instance_; 

    private void Start()
    {
        //nstance_ = this;
    }

    private void FixedUpdate()
    {
        if (player_ != null)
            for (int i = 0; i < player_.Hands.Count; i++)
            {
                Card tmp = player_.Hands[i];
                tmp.transform.position = transforms_[i].position;
                tmp.transform.rotation = transforms_[i].rotation;
            }
    }

    public void AddPlayer(Player p)
    {
        player_ = p;
    }
}
