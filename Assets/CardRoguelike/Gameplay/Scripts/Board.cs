using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Timba.Cards;
using UnityEngine;

namespace Timba.CardRoguelike {

    /// <summary>
    /// Represents the whole game board and all it contains
    /// Manages the lifecycle of one encounter
    /// This class has:
    /// - The player, that in turn contains his card zones
    /// - The enemies
    /// - The relics in play
    /// </summary>
    [Serializable]
    public class Board : MonoSingleton<Board> {
        public CardPlayer player;
        public CardPlayer enemy;
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
            yield return StartCoroutine(player.TakeTurn());
            yield return StartCoroutine(enemy.TakeTurn());

            // Enemies turn
            /*foreach (Enemy enemy in enemies) {
                yield return StartCoroutine(enemy.TakeTurn());
            }*/
            Debug.LogFormat("End of turn {0}", number);
        }

        private void Update() {
            // Win Condition
            bool win = enemy.characters.Where(x => x.combatant.hp > 0).Count() == 0;

            // Lose Condition
            bool lose = player.characters.Where(x => x.combatant.hp > 0).Count() == 0;
        }
    }
}