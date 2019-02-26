using System;
using System.Collections;
using System.Collections.Generic;
using Timba.Cards;
using UnityEngine;

namespace Timba.CardRoguelike {

    /// <summary>
    /// Represents the whole game board and all it contains
    /// This class has:
    /// - The player, that in turn contains his card zones
    /// - The enemies
    /// - The relics in play
    /// </summary>
    [Serializable]
    public class Board : MonoSingleton<Board> {
        public CardPlayer player;
        public Enemy[] enemies;
        public Relic[] relics;
        private bool endPlayerTurn;
        private bool isGameFinished;
        private int turnNumber;

        protected override void OnAwake() {
            isGameFinished = false;
            Card.OnCardPlayed += Card_OnCardPlayed;
        }

        private void Card_OnCardPlayed(Card card) {
            player.Discard(card);
        }

        private void Start() {
            FindObjectOfType<BoardDummy>().LoadDummyDeck();
            StartCoroutine(TurnLoop());
        }

        public IEnumerator TurnLoop() {
            while (!isGameFinished) {
                turnNumber++;
                yield return StartCoroutine(Turn(turnNumber));
            }
            Debug.Log("Game finished");
        }

        public IEnumerator Turn(int number) {
            Debug.LogFormat("Start of turn {0}", number);
            // Player turn
            for (int i = 0; i < player.drawPerTurn; i++) {
                player.Draw();
            }
            yield return new WaitUntil(() => endPlayerTurn);
            Debug.Log("Player turn finished");
            endPlayerTurn = false;
            player.DiscardAll();

            // Enemies turn
            foreach (Enemy enemy in enemies) {
                yield return StartCoroutine(enemy.TakeTurn());
            }
            Debug.LogFormat("End of turn {0}", number);
        }

        public void EndTurn() {
            endPlayerTurn = true;
        }
    }
}