using System;
using System.Collections.Generic;

namespace Timba.Cards {
    [Serializable]
    public class CardZone {
        public List<Card> cards;
        public bool isDiscardZone;
        public bool isDestroyZone;

        public event Action<Card> OnAdd;
        public event Action<Card> OnRemove;
                
        public CardZone() {
            cards = new List<Card>();
        }

        public void Add(Card card) {
            cards.Add(card);
            OnAdd?.Invoke(card);
            if (isDiscardZone)
                card.Discarded();
            if (isDestroyZone)
                card.Destroyed();
        }

        public void AddRange(List<Card> cardsToAdd) {
            cards.AddRange(cardsToAdd);
        }

        public Card Remove(Card card) {
            cards.Remove(card);
            OnRemove?.Invoke(card);
            return card;
        }

        public Card RemoveAt(int index) {
            Card card = cards[index];
            return Remove(card);            
        }

        public List<Card> Remove(List<Card> cardsToRemove) {
            List<Card> removedCards = new List<Card>();
            foreach (Card card in cardsToRemove) {
                cards.Remove(card);
                removedCards.Add(card);
            }
            return removedCards;
        }

        public List<Card> RemoveAll() {
            return Remove(cards);
        }

        /// <summary>
        /// Select a random card in this zone and move it to targetZone
        /// </summary>
        /// <param name="targetZone"></param>
        public void MoveRandom(CardZone targetZone) {
            if (cards.Count > 0) {
                targetZone.Add(cards.RemoveRandom());
            }
        }

        /// <summary>
        /// Move a card to a target zone
        /// </summary>
        /// <param name="card"></param>
        /// <param name="targetZone"></param>
        public void Move(Card card, CardZone targetZone) {
            Remove(card);
            targetZone.Add(card);
        }

        /// <summary>
        /// Move the card at index position in this zone to targetZone
        /// </summary>
        /// <param name="index"></param>
        /// <param name="targetZone"></param>
        public void MoveAt(int index, CardZone targetZone) {
            Card card = RemoveAt(index);
            targetZone.Add(card);
        }

        /// <summary>
        /// Move a list of cards in this zone to targetZone
        /// </summary>
        /// <param name="cardsToMove"></param>
        /// <param name="targetZone"></param>
        public void Move(List<Card> cardsToMove, CardZone targetZone) {
            foreach (Card card in cardsToMove) {
                Move(card, targetZone);
            }
        }

        /// <summary>
        /// Move all the cards in this zone to targetZone
        /// </summary>
        /// <param name="targetZone"></param>
        public void MoveAll(CardZone targetZone) {
            foreach (Card card in cards.ToArray()) {
                Move(card, targetZone);
            }
        }
    }
}