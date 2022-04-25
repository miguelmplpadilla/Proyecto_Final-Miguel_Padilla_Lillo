using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    public int damage = 1;

    public GameObject padre;
    
    private void Start()
    {
        StartCoroutine("destruir");
    }

    IEnumerator destruir()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("HurtBoxEnemy")) {
            EnemyHurt hurt = other.GetComponentInParent<EnemyHurt>();
            hurt.Hit(damage, padre);
            Destroy(gameObject);
        }
    }
}
