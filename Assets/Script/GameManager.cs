using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public drawButton db;
    public playButton pb;
    public discardButton dcb;
    public TMPro.TMP_Text ShowState;
    public button_hint_color h_c_b;
    public button_hint_number h_n_b;
    public List<Card> objectPool_;
    public List<PhotonView> players_views = new List<PhotonView>();
    public List<Player> players_ = new List<Player>();
    public List<Enemy> enemies_ = new List<Enemy>();
    public Enemy player_;
    public static GameManager instance_;
    public int number_of_hint;
    public int hint_max;
    public int errorPoint = 0;
    public int errorPoint_max;
    private int playerIndex = 0;
    public int PlayerIndex { get { return playerIndex; } }

    private int enemyIndex = 0;
    public bool IsHintLeft { get { return number_of_hint > hint_max; } }

    public bool ErrorLessThanMax { get { return errorPoint < errorPoint_max; } }
    public bool HintEqualTen { get { return number_of_hint == hint_max; } }

    private int turn = 0;

    public enum Point
    {
        HintPoint,
        ErrorPoint
    }

    private void Start()
    {
        instance_ = this;
        StartCoroutine(InitGame());
        number_of_hint = 10;
        hint_max = 10;
        errorPoint_max = 3;
    }

    public void updatePoints(Point p)
    {
        PhotonView.Get(this).RPC("UpdatePoints", RpcTarget.All, p);
    }

    [PunRPC]
    private void UpdatePoints(Point option)
    {
        switch (option)
        {
            case Point.HintPoint:
                number_of_hint -= 1;
                break;
            case Point.ErrorPoint:
                errorPoint += 1;
                break;
        }
    }

    public void SetEnemy(Player p)
    {
        enemies_[enemyIndex++].AddPlayer(p);
    }

    public void SetPlayer(Player p)
    {
        player_.AddPlayer(p);
    }
    public Player FindPlayerInView(Photon.Realtime.Player myPlayer)
    {
        foreach (PhotonView photonView in players_views)
        {
            if (photonView.Controller.Equals(myPlayer))
                return photonView.GetComponent<Player>();
        }
        return null;
    }

    // [PunRPC]
    // private void CheckDeckUpdate(int option)
    // {
    //     switch (option)
    //     {
    //         case 0:
    //             CheckDeck = 0;
    //             break;
    //         case 1:
    //             CheckDeck += 1;
    //             break;
    //     }
    // }



    IEnumerator InitGame()
    {
        yield return new WaitUntil(() => players_views.Count == PhotonNetwork.CurrentRoom.PlayerCount);
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            players_.Add(FindPlayerInView(player));
        }

        yield return new WaitUntil(() => players_.Count == PhotonNetwork.CurrentRoom.PlayerCount);
        print("player count " + players_.Count);
        //PhotonView.Get(this).RPC("Game", RpcTarget.All);
        StartCoroutine(InitPlayer());
    }


    IEnumerator InitPlayer()
    {
        foreach (Player p in players_)
        {
            p.Initialize();
            yield return new WaitUntil(() => p.GetComponent<PlayerSystem>().GetState() is EnemyTurn);
        }

        PhotonView.Get(this).RPC("Game", RpcTarget.All);
    }


    [PunRPC]
    private void Game()
    {
        ChangeTurn();
    }

    public Card GetCardbyId(int id)
    {
        return objectPool_[id];
    }

    public void AddPlayer(Player tmp)
    {
        PhotonView playerPv_ = tmp.GetComponent<PhotonView>();

        PhotonView.Get(this).RPC("UpdatePlayerList", RpcTarget.All, playerPv_.ViewID);
    }

    [PunRPC]
    public void UpdatePlayerList(int playId)
    {
        PhotonView tmp = PhotonView.Find(playId);
        if (!players_views.Contains(tmp))
            players_views.Add(tmp);
    }

    public void ChangeTurn()
    {
        playerIndex %= players_.Count;
        turn++;
        Debug.LogFormat("start player {0} turn", playerIndex);
        players_[playerIndex].StartTurn();
    }

    public void TurnEnds()
    {
        PhotonView.Get(this).RPC("OnTurnChanged", RpcTarget.All);
    }

    [PunRPC]
    public void OnTurnChanged()
    {
        playerIndex += 1;
        Debug.Log("Turn Ends");
        ChangeTurn();
    }

    public void IsEndGame() {
        if (errorPoint == errorPoint_max) {
            SceneManager.LoadScene("GameOverScene");
        }
        else if (DeckManager.Instance.DeckCount > 0 ||FieldManager.Instance.canWinGame()) {
            SceneManager.LoadScene("GameClearScene");
        }
        else if (DeckManager.Instance.DeckCount <= 0) {
            SceneManager.LoadScene("GameClearScene");
        }
    }
}
