using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour {

    public int damage = 1;
    public bool enter = false;
    private Collider2D otro;

    private void Update() {
        if (enter == true) {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                if (otro.CompareTag("HurtBoxEnemy")) {
                    EnemyHurt hurt = otro.GetComponentInParent<EnemyHurt>();
                    hurt.Hit(damage, gameObject);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        otro = other;
        enter = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        otro = null;
        enter = false;
    }
}
