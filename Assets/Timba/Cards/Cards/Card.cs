using System;
using System.Linq;
using UnityEngine;

namespace Timba.Cards {
    [Serializable]
    public class Card : ISerializationCallbackReceiver {
        public string id;
        public string name;
        [SerializeField]
        private string description = "";
        public string Description {
            get {
                string fullDescription = description;
                foreach(CardBehaviour b in behaviours) {
                    fullDescription += string.Format("\n{0}", b.Description);
                }
                return fullDescription;
            }
        }

        public TargetMask targetMask;
        public CardBehaviour[] behaviours = new CardBehaviour[0];
        
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
        public void Execute(object[] targets) {
            for(int i=0; i < behaviours.Length; i++) {
                behaviours[i].Execute(this, targets);
            }
        }
        
        /// <summary>
        /// Discard a card
        /// </summary>
        public void Discarded() {

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
        public void Destroyed() {
            if (OnCardDestroyed != null) {
                OnCardDestroyed(this);
            }
            if (OnDestroy != null) {
                OnDestroy(this);
            }
        }

        #region CustomSerialization

        [SerializeField]
        public SerializableCardBehaviour[] serializableBehaviours = new SerializableCardBehaviour[0];
        
        public void OnBeforeSerialize() {
            serializableBehaviours = new SerializableCardBehaviour[behaviours.Length];
            for(int i = 0; i < behaviours.Length; i++) {
                if(behaviours[i] != null) {
                    serializableBehaviours[i] = new SerializableCardBehaviour() {
                        type = behaviours[i].GetType().Name,
                        parameters = behaviours[i].Parameters
                    };
                }
            }
        }

        public void OnAfterDeserialize() {
            behaviours = new CardBehaviour[serializableBehaviours.Length];
            for (int i = 0; i < serializableBehaviours.Length; i++) {
                Type type = AvailableCardBehaviours.AvailableTypes.Where(x => x.Name == serializableBehaviours[i].type).First();
                behaviours[i] = (CardBehaviour) Activator.CreateInstance(type);
                behaviours[i].Parameters = serializableBehaviours[i].parameters;
                //Debug.LogFormat("Created behaviour: {0}", behaviours[i].GetType().Name);
            }
        }
        
        public Card Clone() {
            Card newCard = (Card) this.MemberwiseClone();
            newCard.behaviours = (CardBehaviour[]) this.behaviours.Clone();
            for(int i = 0; i < behaviours.Length; i++) {
                newCard.behaviours[i] = (CardBehaviour) Activator.CreateInstance(behaviours[i].GetType());
                newCard.behaviours[i].Parameters = (int[]) behaviours[i].Parameters.Clone();
            }
            return newCard;
        }
        #endregion
    }

}