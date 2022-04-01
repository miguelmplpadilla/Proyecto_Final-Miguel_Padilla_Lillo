using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    public int life = 2;
    private AtackController atackController;

    private void Awake()
    {
        atackController = GetComponentInParent<AtackController>();
    }

    public void Hit(int damage) {
        life -= damage;
        atackController.nivelDeteccion = 100f;
        if (life <= 0) {
            Destroy(gameObject);
        }
    }
}
