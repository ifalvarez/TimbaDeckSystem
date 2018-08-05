using System;

namespace Timba.Cards {

    public class Card {
        public string id;
        public string name;
        
        /// <summary>
    /// Triggered when any card is played
    /// </summary>
        public static event Action<Card> OnCardPlayed;

        /// <summary>
        /// Triggered when any card is resolved
        /// </summary>
        public static event Action<Card> OnCardResolved;

        /// <summary>
        /// Triggered when any card is Discarded
        /// </summary>
        public static event Action<Card> OnCardDiscarded;

        /// <summary>
        /// Triggered when any card is Destroyed
        /// </summary>
        public static event Action<Card> OnCardDestroyed;

        /// <summary>
        /// Triggered when this card instance is played
        /// </summary>
        public event Action<Card> OnPlay;

        /// <summary>
        /// Triggered when this card instance is resolved
        /// </summary>
        public event Action<Card> OnResolve;

        /// <summary>
        /// Triggered when this card instance is discarded
        /// </summary>
        public event Action<Card> OnDiscard;

        /// <summary>
        /// Triggered when this card instance is destroyed
        /// </summary>
        public event Action<Card> OnDestroy;

        /// <summary>
        /// Plays a card
        /// </summary>
        public void Play() {
            if (OnCardPlayed != null) {
                OnCardPlayed(this);
            }
            if (OnPlay != null) {
                OnPlay(this);
            }
        }

        /// <summary>
        /// Resolves a card
        /// </summary>
        public void Resolve() {
            if (OnCardResolved != null) {
                OnCardResolved(this);
            }
            if (OnResolve != null) {
                OnResolve(this);
            }
        }

        /// <summary>
        /// Discard a card
        /// </summary>
        public void Discard() {
            if (OnCardDiscarded != null) {
                OnCardDiscarded(this);
            }
            if (OnDiscard != null) {
                OnDiscard(this);
            }
        }

        /// <summary>
        /// Destroys a card
        /// </summary>
        public void Destroy() {
            if (OnCardDestroyed != null) {
                OnCardDestroyed(this);
            }
            if (OnDestroy != null) {
                OnDestroy(this);
            }
        }
    }

}