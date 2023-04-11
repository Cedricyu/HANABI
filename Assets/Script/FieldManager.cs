using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public static FieldManager Instance;
    [SerializeField] List<redCard> redCards;
    [SerializeField] List<whiteCard> whiteCards;
    [SerializeField] List<blueCard> blueCards;
    [SerializeField] List<greenCard> greenCards;
    [SerializeField] List<yellowCard> yellowCards;

    public void Start(){
        Instance = this;
    }

    public bool canPlay(Card playCard){
        Debug.Log("color "+playCard.getColor()+" number "+playCard.getNumber());
        if (playCard.GetType()==typeof(redCard) && (redCards.Count+1 == playCard.getNumber()) ){
            Debug.Log("red");
            redCards.Add((redCard)playCard);
        }
        else if (playCard.GetType()==typeof(blueCard) && (blueCards.Count+1 == playCard.getNumber()) )
        {
            Debug.Log("blue");
            blueCards.Add((blueCard)playCard);
        }
        else if (playCard.GetType()==typeof(whiteCard) && (whiteCards.Count+1 == playCard.getNumber()) )
        {
            Debug.Log("white");
            whiteCards.Add((whiteCard)playCard);
        }
        else if (playCard.GetType()==typeof(greenCard) && (greenCards.Count+1 == playCard.getNumber()) )
        {
            Debug.Log("green");
            greenCards.Add((greenCard)playCard);
        }
        else if (playCard.GetType()==typeof(yellowCard) && (yellowCards.Count+1 == playCard.getNumber()) )
        {
            Debug.Log("yellow");
            yellowCards.Add((yellowCard)playCard);
        }
        else{
            return false;
        }
        return true;
    }
}
