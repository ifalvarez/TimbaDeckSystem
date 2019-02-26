using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Timba.CardRoguelike;
using Timba.Cards;
using UnityEngine;

/// <summary>
/// Prepares a fake board state to test the gameplay
/// </summary>
public class BoardDummy : MonoBehaviour
{
    public CardDatabase database;
    
    public void LoadDummyDeck() {
        // Add some cards to the deck
        for (int i = 0; i < 3; i++) {
            Board.Instance.player.drawPile.Add(database.cards[1].Clone());
            Board.Instance.player.drawPile.Add(database.cards[2].Clone());
            Board.Instance.player.drawPile.Add(database.cards[3].Clone());
        }

        // Search for the player CardOwner and assign it to all the deck cards
        CardOwner playerCardOwner = FindObjectsOfType<CardOwner>().Where(x => x.id == "player1").First();
        foreach (Card card in Board.Instance.player.drawPile.cards) {
            card.owner = playerCardOwner;
        }
    }

}
