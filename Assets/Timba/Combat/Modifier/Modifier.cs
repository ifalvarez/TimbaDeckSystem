using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timba.Combat {
    /// <summary>
    /// Represents a buff, debuff and the like.
    /// Default implementation changes a target combatant stats and has a duration.
    /// What the modification does to the target can be changed by overriding the ApplyModification and RemoveModification methods.
    /// When the modifier is destroyed can be changed by overriding the IsActive method.
    /// </summary>
    public class Modifier : MonoBehaviour {
        public Stats deltaStats;
        public Combatant target;
        public float duration;
        public float startTime;

        public delegate void ModifierAction();
        public event ModifierAction OnApplyModification;
        public event ModifierAction OnRemoveModification;

        private void OnEnable() {
            ApplyModification();
            startTime = Time.time;
        }

        /// <summary>
        /// Implements the main behaviour of the modification.
        /// Default implementation adds the stats in deltaStats to the target stats.
        /// </summary>
        public virtual void ApplyModification() {
            target.stats += deltaStats;
            if (OnApplyModification != null) {
                OnApplyModification();
            }
        }

        private void Update() {
            if (!IsActive()) {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// This modifier game object will be destroyed when this method evaluates to false.
        /// Default implementation returns false after the modifier has lived for the specified duration
        /// </summary>
        /// <returns></returns>
        public virtual bool IsActive() {
            return Time.time <= startTime + duration;
        }

        private void OnDisable() {
            RemoveModification();
        }

        /// <summary>
        /// Implements the cleaning of the modification form the target.
        /// Default implementation removed the stats in deltaStats to the target stats.
        /// </summary>
        public virtual void RemoveModification() {
            target.stats -= deltaStats;
            if (OnRemoveModification != null) {
                OnRemoveModification();
            }
        }
    }
}