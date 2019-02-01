using System.Collections;
using System.Collections.Generic;
using Timba.Cards;
using UnityEngine;

public class BoardDummy : MonoBehaviour
{
    public CardDatabase database;
    
    private void Awake() {
        Board.Instance = new Board();
        for (int i = 0; i < 5; i++) {
            Board.Instance.player.hand.Add(database.cards[0]);
        }
    }

}
