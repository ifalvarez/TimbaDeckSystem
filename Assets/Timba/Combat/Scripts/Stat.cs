using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if(timeToRegen > 0 && value >= timeToRegen) {
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

    public static Stat operator +(Stat a, Stat b) {
        a.Value += b.Value;
        return a;
    }

    public static Stat operator -(Stat a, Stat b) {
        a.Value -= b.Value;
        return a;
    }

    public static implicit operator float(Stat a) {
        return a.Value;
    }

    public static Stat zero = new Stat(0);
}
