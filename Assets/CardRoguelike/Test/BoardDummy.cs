using System.Collections;
using System.Collections.Generic;
using Timba.Cards;
using UnityEngine;

public class BoardDummy : MonoBehaviour
{
    public CardDatabase database;
    
    private void Awake() {
        Board.Instance = new Board();
        for (int i = 0; i < 3; i++) {
            Board.Instance.player.drawPile.Add(database.cards[1].Clone());
            Board.Instance.player.drawPile.Add(database.cards[2].Clone());
            Board.Instance.player.drawPile.Add(database.cards[3].Clone());
        }
        Board.Instance.player.Draw(3);
    }

}
