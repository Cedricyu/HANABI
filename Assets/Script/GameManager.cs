using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public drawButton db;
    public List<Card> objectPool_;
    public List<PhotonView> players_views = new List<PhotonView>();
    public List<Player> players_ = new List<Player>();
    public List<Enemy> enemies_ = new List<Enemy>();
    public Enemy player_;
    public static GameManager instance_;
    private int playerIndex = 0;
    private int enemyIndex = 0;
    private void Start()
    {
        instance_ = this;
        StartCoroutine(InitGame());
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

    IEnumerator InitGame()
    {
        yield return new WaitUntil(() => players_views.Count == PhotonNetwork.CurrentRoom.PlayerCount);
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            players_.Add(FindPlayerInView(player));
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
        PhotonView tmp =  PhotonView.Find(playId);
        if (!players_views.Contains(tmp))
            players_views.Add(tmp);
    }

    public void ChangeTurn()
    {  
        playerIndex %= players_.Count;
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
}
