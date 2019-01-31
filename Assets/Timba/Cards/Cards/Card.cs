using System;
using UnityEngine;

namespace Timba.Cards {
    [Serializable]
    public class Card : ISerializationCallbackReceiver {
        public string id;
        public string name;
        public bool needsTarget;
        public CardBehaviour[] behaviours;
        
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

        #region CustomSerialization

        [SerializeField]
        public SerializableCardBehaviour[] serializableBehaviours = new SerializableCardBehaviour[0];

        public void OnBeforeSerialize() {
            serializableBehaviours = new SerializableCardBehaviour[behaviours.Length];
            for(int i = 0; i < behaviours.Length; i++) {
                if(behaviours[i] != null) {
                    serializableBehaviours[i] = new SerializableCardBehaviour() {
                        type = behaviours[i].GetType().FullName,
                        parameters = behaviours[i].Parameters
                    };
                }
            }
        }

        public void OnAfterDeserialize() {
            behaviours = new CardBehaviour[serializableBehaviours.Length];
            for (int i = 0; i < serializableBehaviours.Length; i++) {
                Type type = Type.GetType(serializableBehaviours[i].type);
                if(type != null) {
                    behaviours[i] = (CardBehaviour) Activator.CreateInstance(type);
                    behaviours[i].Parameters = serializableBehaviours[i].parameters;    
                }
            }
        }
        #endregion
    }

}