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
    public string stateView;

    private Player player_;
    public Player Player_ { get { return player_; } }

    private int hand_max = 5;
    GameObject Card;
    [SerializeField] private int clickcard_id = -1;
    public int Clickcard_id { get { return clickcard_id; } }
    private PhotonView _pv;
    private Button drawbutton;
    private Button playbutton;
    private Button discardbutton;
    private Button quitbutton;
    private Button hint_color_button;
    private Button hint_number_button;

    public static int hint_color_control;
    public static int hint_number_control;

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



        hint_color_control = 0;
        hint_number_control = 0;
        hint_color_button = GameManager.instance_.h_c_b.GetComponent<Button>();
        hint_color_button.onClick.AddListener(hint_color);

        hint_number_button = GameManager.instance_.h_n_b.GetComponent<Button>();
        hint_number_button.onClick.AddListener(hint_number);
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

    public void FinishInit()
    {
        PhotonView.Get(this).RPC("FinishInitRPC", RpcTarget.All);
    }


    [PunRPC]
    public void FinishInitRPC()
    {
        SetState(new EnemyTurn(this));
    }


    // Update is called once per frame
    void Update()
    {
        stateView = GetState().GetType().ToString();
        if (_pv.IsMine)
        {
            if (GetState() is PlayerTurn)
            {
                GameManager.instance_.ShowState.text = "It's your turn!";
            }
            else
            {
                GameManager.instance_.ShowState.text = "It's other's turn";
            }
        }

        foreach (Card c in Hands)
        {
            c.SetPlayer(this);
        }
    }

    [PunRPC]
    public void StartTurn()
    {
        if (!_pv.IsMine)
            return;
        GameManager.instance_.db.gameObject.SetActive(true);
        SetState(new PlayerTurn(this));
    }

    public void OnDrawButton()
    {
        StartCoroutine(state_.DrawCard());
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

    public void hint_color()
    {
        StartCoroutine(state_.click_hint_color());
    }

    public void hint_number()
    {
        StartCoroutine(state_.click_hint_number());
    }




    public bool DrawCard()
    {
        if (Hands.Count >= hand_max)
            return false;
        Card newCard = DeckManager.Instance.DrawCard();
        UpdatePlayerHands(0, newCard.getId());

        return true;
    }

    public void UpdatePlayerHands(int option, int id)
    {
        PhotonView.Get(this).RPC("UpdateHands", RpcTarget.All, option, id);
    }

    [PunRPC]
    public void UpdateHands(int option, int id)
    {
        Debug.Log("Info : " + id);
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

    public void InitClickCardId()
    {
        clickcard_id = -1;
    }
    public bool PlayCard()
    {
        if (clickcard_id == -1)
        {
            Debug.Log("No click card operation");
            return false;
        }

        FieldManager.Instance.PlayCard(GameManager.instance_.GetCardbyId(clickcard_id));
        UpdatePlayerHands(1, clickcard_id);
        Debug.Log("PlayCard success");
        return true;
    }

    public bool Discard()
    {
        print("discard");
        if (clickcard_id == -1 || GameManager.instance_.HintEqualTen)
        {
            Debug.Log("No click card operation");
            return false;
        }


        FieldManager.Instance.Discard(GameManager.instance_.GetCardbyId(clickcard_id));
        UpdatePlayerHands(1, clickcard_id);
        Debug.Log("Discard success");
        return true;


    public void create_hint_color(){
       Debug.Log(clickcard_id);///////////hint在這裡    
        //clickcard_id.Gernerate_color_Hints();
    }
    public void create_hint_number(){
        //clickcard_id.Gernerate_number_Hints();
        Debug.Log(clickcard_id); ///////////hint在這裡
    }

    }
}