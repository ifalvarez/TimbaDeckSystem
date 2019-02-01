using System;
using System.Collections;
using System.Collections.Generic;
using Timba.Cards;
using UnityEngine;

/// <summary>
/// Represents the whole game board and all it contains
/// This class has:
/// - The player, that in turn contains his card zones
/// - The enemies
/// - The relics in play
/// </summary>
[Serializable]
public class Board : PocoSingleton<Board>
{
    public CardPlayer player;
    public Enemy[] enemies;
    public Relic[] relics;

    public IEnumerator Turn() {
        // Player turn
        yield return new WaitUntil(() => player.hand.cards.Count == 0);

        // Enemies turn
        foreach(Enemy enemy in enemies) {
            enemy.TakeTurn();
        }
    }

    public Board() {
        player = new CardPlayer();
        enemies = new Enemy[0];
        relics = new Relic[0];
    }
}
