using System;

namespace Timba.Cards {
    public abstract class Card {
        public string id;
        public string name;
        public bool needsTarget;
        
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
        public void Play(object[] targets) {
            if (OnCardPlayed != null) {
                OnCardPlayed(this);
            }
            if (OnPlay != null) {
                OnPlay(this);
            }

            Execute(targets);

            if (OnCardResolved != null) {
                OnCardResolved(this);
            }
            if (OnResolve != null) {
                OnResolve(this);
            }
        }

        public void Play(object target) {
            Play(new object[] { target });
        }
        
        /// <summary>
        /// Should implement this card effect
        /// </summary>
        abstract public void Execute(object[] targets);
        
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