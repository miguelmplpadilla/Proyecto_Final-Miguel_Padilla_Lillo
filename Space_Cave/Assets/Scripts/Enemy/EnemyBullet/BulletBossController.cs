using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBossController : MonoBehaviour
{

    public float moveSpeed = 1f;
    public Vector2 moveDirection;

    void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("pared"))
        {
            Destroy(gameObject);
        }
        
        if (col.CompareTag("HurBoxPlayer"))
        {
            col.gameObject.GetComponentInParent<PlayerController>().hit(1);
            Destroy(gameObject);
        }
    }
}
