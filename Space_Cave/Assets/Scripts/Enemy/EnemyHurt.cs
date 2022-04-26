using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    public int life = 2;
    private Blink blink;

    private void Awake()
    {
        blink = GetComponent<Blink>();
    }

    public void Hit(int damage, GameObject player) {
        life -= damage;
        gameObject.SendMessage("setNivelDeteccion",100);
        if (life <= 0) {
            gameObject.GetComponent<Animator>().SetTrigger("morir");
            gameObject.SendMessage("setMov",false);
        }
        else {
            blink.takeDamage(1);
        }
        gameObject.SendMessage("setPlayer",player);
    }

    public void destroyEnemy() {
        Destroy(gameObject);
    }
}
