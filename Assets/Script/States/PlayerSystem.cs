using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerSystem : StateMeachine
{
    // Start is called before the first frame update
    [SerializeField] List<Card> Hands;
    private Player player_;
    public Player Player_ { get { return player_; } }
    int[] position = new int[] { -6, -4, -2, 0, 2, 4 };
    public int hand_max = 5;
    GameObject Card;
    int position_count = 0;
    private PhotonView _pv;
    private Button button;
    //DeckManager DM;

    void Start()
    {
        player_ = GetComponent<Player>();
        _pv = GetComponent<PhotonView>();
        if (!_pv.IsMine)
            Destroy(this);
        button = GameManager.instance_.db.GetComponent<Button>();
        button.onClick.AddListener(OnDrawButton);

        SetState(new PlayerTurn(this));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawButton()
    {
        StartCoroutine(state_.DrawCard());
        //drawCard();
    }
    
    void OnPlayButton()
    {
        StartCoroutine(state_.PlayCard());
    }

    void OnDiscardButton()
    {
        StartCoroutine(state_.DiscardCard());
    }
    void OnGiveHint()
    {
        StartCoroutine(state_.GiveHints());
    }

    public bool DrawCard()
    {
        if (Hands.Count > hand_max)
            return false;
        Card newCard = DeckManager.Instance.DrawCard();
        Debug.Log("draw one card");
        Vector3 move = newCard.transform.position;
        move.x = position[position_count];
        move.y = -1;
        newCard.transform.position = move;

        print(_pv.ViewID);
        Hands.Add(newCard);

        position_count = position_count + 1;
        if (position_count > 5)
        {
            position_count = 0;
        }
        return true;
    }

    public bool PlayCard()
    {
        Hands.Remove(Hands[Hands.Count - 1]);
        if (FieldManager.Instance.canPlay(Hands[Hands.Count - 1]))
        {
            Debug.Log(true);
            return true;
        }
        else
        {
            Debug.Log(false);
            return false;
        }
    }

    public bool Discard()
    {
        return true;
    }

}
