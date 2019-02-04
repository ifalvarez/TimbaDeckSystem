using UnityEngine;

namespace Timba.Combat {
    /// <summary>
    /// Any object that can engage in combat should have a Combatant component.
    /// This keeps track of all the stats as combat actions are resolved.
    /// </summary>
    public class Combatant : MonoBehaviour {

        public Stats stats;

        // Stat convenience properties
        public float hp {
            get {
                return stats.hp;
            }
            set {
                stats.hp.Value = value;
            }
        }

        public float mp {
            get {
                return stats.mp;
            }
            set {
                stats.mp.Value = value;
            }
        }
        //TODO: other stats methods


    }
}