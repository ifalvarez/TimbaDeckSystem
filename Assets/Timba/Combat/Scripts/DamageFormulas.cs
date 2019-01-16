using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Library of Attack functions.
/// Common calculations of attack damage should be performed using one of this functions.
/// Missing common functions should be added here as well
/// </summary>
public class DamageFormulas {

    /// <summary>
    /// Basic physical attack.
    /// source attack vs target armor
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    public static float Physical(float attack, float armor) {
        return attack * ((1 / (1 + armor)));
    }

}
