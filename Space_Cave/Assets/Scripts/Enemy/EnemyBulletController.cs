using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("destruir");
    }

    IEnumerator destruir()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("HurBoxPlayer"))
        {
            col.gameObject.GetComponentInParent<PlayerController>().hit(1);
        }
    }
}
