using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timba.Combat {

    /// <summary>
    /// Represents a single stat of a combatant
    /// </summary>
    [System.Serializable]
    public struct Stat {
        [SerializeField]
        private float value;
        public bool isMinConstrained;
        public float minValue;
        public bool isMaxConstrained;
        public float maxValue;
        public float timeToRegen;
        private float regenTimer;

        public delegate void StatAction(Stat s);

        public float Value {
            get {
                return value;
            }
            set {
                this.value = Mathf.Max(value, isMinConstrained ? minValue : int.MinValue);
                this.value = Mathf.Min(this.value, isMaxConstrained ? maxValue : int.MaxValue);
            }
        }

        public float RegenTimer {
            get {
                return regenTimer;
            }
            set {
                if (timeToRegen > 0 && value >= timeToRegen) {
                    int regenAmount = Mathf.FloorToInt(value / timeToRegen);
                    Value += regenAmount;
                    value -= regenAmount;
                }
                regenTimer = value;
            }
        }

        public Stat(float value, bool isMinConstrained = false, float minValue = float.MinValue, bool isMaxConstrained = false, float maxValue = float.MaxValue, float timeToRegen = 0) {
            this.value = value;
            this.isMinConstrained = isMinConstrained;
            this.minValue = minValue;
            this.isMaxConstrained = isMaxConstrained;
            this.maxValue = maxValue;
            this.timeToRegen = timeToRegen;
            regenTimer = 0;
        }

        // Stat / Stat operations
        public static Stat operator +(Stat a, Stat b) {
            a.Value += b.Value;
            return a;
        }

        public static Stat operator -(Stat a, Stat b) {
            a.Value -= b.Value;
            return a;
        }

        // Stat / float and Stat / int operations
        // This are not commutative, not even the sum.
        // Will always return the type of the first operand
        public static Stat operator +(Stat a, float b) {
            a.Value += b;
            return a;
        }

        public static float operator +(float a, Stat b) {
            return a + b.value;
        }

        public static Stat operator -(Stat a, float b) {
            a.Value -= b;
            return a;
        }

        public static float operator -(float a, Stat b) {
            return a - b.Value;
        }

        public static Stat operator +(Stat a, int b) {
            a.Value += b;
            return a;
        }

        public static int operator +(int a, Stat b) {
            return a + (int)b.value;
        }

        public static Stat operator -(Stat a, int b) {
            a.Value -= b;
            return a;
        }

        public static int operator -(int a, Stat b) {
            return a - (int)b.Value;
        }

        // Implicit asignment operators
        public static implicit operator float(Stat a) {
            return a.Value;
        }

        public static implicit operator int(Stat a) {
            return (int)a.Value;
        }

        // Static common values
        public static Stat zero = new Stat(0);
    }
}