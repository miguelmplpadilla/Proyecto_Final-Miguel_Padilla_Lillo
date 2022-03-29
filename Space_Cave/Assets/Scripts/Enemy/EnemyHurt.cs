using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    public int life = 2;

    public void Hit(int damage) {
        life -= damage;
        if (life <= 0) {
            Destroy(gameObject);
        }
    }
}
