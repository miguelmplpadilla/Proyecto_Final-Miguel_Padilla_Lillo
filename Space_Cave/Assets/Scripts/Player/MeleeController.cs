using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour {

    public int damage = 1;

    private void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if (other.CompareTag("HurtBoxMelee")) {
                EnemyHurt hurt = other.GetComponentInParent<EnemyHurt>();
                hurt.Hit(damage);
            }
        }
    }
}
