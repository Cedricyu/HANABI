using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System;

public class PlayerSystem : StateMeachine
{
    // Start is called before the first frame update
    [SerializeField] List<Card> Hands;
    public List<Card> GetHands { get { return Hands; } }
    [SerializeField] string stateView;

    private Player player_;
    public Player Player_ { get { return player_; } }

    private int hand_max = 5;
    GameObject Card;
    private int clickcard_id = -1;
    private PhotonView _pv;
    private Button drawbutton;
    private Button playbutton;
    private Button discardbutton;
    private Button quitbutton;

    [HideInInspector] public bool active = false;
    //DeckManager DM;

    void Start()
    {
        player_ = GetComponent<Player>();
        _pv = GetComponent<PhotonView>();
        if (!_pv.IsMine)
            SetState(new EnemyTurn(this));
        drawbutton = GameManager.instance_.db.GetComponent<Button>();
        drawbutton.onClick.AddListener(OnDrawButton);
        playbutton = GameManager.instance_.pb.GetComponent<Button>();
        playbutton.onClick.AddListener(OnPlayButton);
        discardbutton = GameManager.instance_.dcb.GetComponent<Button>();
        discardbutton.onClick.AddListener(OnDiscardButton);
        quitbutton = GameManager.instance_.qgb.GetComponent<Button>();
        quitbutton.onClick.AddListener(EndTurn);
        GameManager.instance_.AddPlayer(this.GetComponent<Player>());
        SetState(new Begin(this));
        Debug.Log(state_);
    }
   
    [PunRPC]
    public void InitializePlayer()
    {
        if (!_pv.IsMine)
            return;
        StartCoroutine(state_.Start());
    }


    // Update is called once per frame
    void Update()
    {
        stateView = GetState().GetType().ToString();
    }

    [PunRPC]
    public void StartTurn()
    {
        if (!_pv.IsMine)
            return;
        GameManager.instance_.db.gameObject.SetActive(true);
        SetState(new PlayerTurn(this));
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
    public void EndTurn()
    {
        StartCoroutine(state_.End());
    }

    public bool DrawCard()
    {
        if (Hands.Count >= hand_max)
            return false;
        Card newCard = DeckManager.Instance.DrawCard();
        newCard.SetPlayer(this);
        newCard.SetClickable(true);
        UpdatePlayerHands(0, newCard.getId());

        return true;
    }

    public void UpdatePlayerHands(int option, int id)
    {
        PhotonView.Get(this).RPC("UpdateHands", RpcTarget.All, option, id);
    }

    [PunRPC]
    public void UpdateHands(int option, int id, PhotonMessageInfo info)
    {
        Debug.Log("Info : ", info.photonView);
        if (option == 0)
        {
            Hands.Add(GameManager.instance_.GetCardbyId(id));
        }
        else if (option == 1)
        {
            Hands.Remove(GameManager.instance_.GetCardbyId(id));
        }
    }

    public void SetClickCardId(int id)
    {
        clickcard_id = id;
    }

    public int GetClickCardId()
    {
        return clickcard_id;
    }

    public bool PlayCard()
    {
        if (clickcard_id == -1)
        {
            Debug.Log("No click card operation");
            return false;
        }

        if (FieldManager.Instance.canPlay(GameManager.instance_.GetCardbyId(clickcard_id)))
        {
            UpdatePlayerHands(1,clickcard_id);
            Debug.Log("PlayCard success");
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Discard()
    {
        if (clickcard_id == -1)
        {
            Debug.Log("No click card operation");
            return false;
        }

        if (FieldManager.Instance.canDiscard(GameManager.instance_.GetCardbyId(clickcard_id)))
        {
            UpdatePlayerHands(1, clickcard_id);
            Debug.Log("Discard success");
            return true;
        }
        else
        {
            return false;
        }
    }



}
