using System;
using System.Collections;
using System.Collections.Generic;
using Timba.Cards;
using Timba.Players;
using UnityEngine;

namespace Timba.CardRoguelike {
    /// <summary>
    /// Card player implementation for CardRoguelike.
    /// This class has:
    /// - All the zones the player owns
    /// - Common operations the player can perform
    /// </summary>
    [Serializable]
    public class CardPlayer : Player {
        public Character[] characters;
        public CardZone hand;
        public CardStack drawPile;
        public CardStack discardPile;
        public CardStack destroyedPile;
        public Relic[] relics;

        public int drawPerTurn = 5;
        public int maxHandSize = 10;

        private bool endTurn;

        public CardPlayer() {
            hand = new CardZone();
            discardPile = new CardStack() { isDiscardZone = true };
            destroyedPile = new CardStack() { isDestroyZone = true };
            drawPile = new CardStack() { resuplyFrom = discardPile };
        }

        public void Draw(int amount = 1) {
            for (int i = 0; i < amount; i++) {
                hand.Add(drawPile.Draw());
            }
        }

        public void Discard(Card card) {
            hand.Move(card, discardPile);
        }

        public void Discard(Card[] cards) {
            foreach (Card c in cards) {
                Discard(c);
            }
        }

        public void DiscardRandom() {
            hand.MoveRandom(discardPile);
        }

        public void DiscardAll() {
            Discard(hand.cards.ToArray());
        }

        public Card RandomCardFromHand() {
            return hand.cards.RandomItem();
        }

        public IEnumerator TakeTurn() {
            // Player turn
            for (int i = 0; i < drawPerTurn; i++) {
                Draw();
            }
            yield return new WaitUntil(() => endTurn);
            Debug.Log("Player turn finished");
            endTurn = false;
            DiscardAll();
        }

        public void EndTurn() {
            endTurn = true;
        }
    }



}