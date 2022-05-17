using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilController : MonoBehaviour
{

    private bool destruido = false;

    public void destruirMisil()
    {
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("HurBoxPlayer"))
        {
            if (!destruido)
            {
                col.gameObject.GetComponentInParent<PlayerController>().hit(2);
                GetComponent<Animator>().SetTrigger("explotar");
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                destruido = true;
            }
        }
        
        if (col.CompareTag("pared"))
        {
            if (!destruido)
            {
                GetComponent<Animator>().SetTrigger("explotar");
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                destruido = true;
            }
        }
    }
}
