using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Cards/New Cards")]
public class CardData : ScriptableObject
{
    [SerializeField] private int number_;
    [SerializeField] private string color_;

    public int Number { get => number_; set => number_ = value; }
    public string Color { get => color_; set => color_ = value; }

    public void Play()
    {
        // Do something when the card is played
    }

    public static CardData Create(string color, int number)
    {
        var card = ScriptableObject.CreateInstance<CardData>();
        card.Color = color;
        card.Number = number;
        return card;
    }

    public CardData(string color, int number){
        number_ = number;
        color_ = color;
    }
}
