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

    public void Hit(int damage, GameObject player) {
        life -= damage;
        atackController.nivelDeteccion = 100f;
        if (life <= 0) {
            gameObject.GetComponent<Animator>().SetTrigger("morir");
            atackController.mov = false;
        }
        atackController.setPlayer(player);
    }

    public void destroyEnemy() {
        Destroy(gameObject);
    }
}
