using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : MonoBehaviour {
    public Combatant source;
    public Attack attackPrefab;

    private void OnCollisionEnter2D(Collision2D collision) {
        Combatant target = collision.collider.GetComponentInChildren<Combatant>();
        if(target != null) {
            //Attack attack = Instantiate(attackPrefab, collision.contacts[0].point, Quaternion.identity);
            //attack.source = source;
            //attack.target = target;
        }
    }
}
