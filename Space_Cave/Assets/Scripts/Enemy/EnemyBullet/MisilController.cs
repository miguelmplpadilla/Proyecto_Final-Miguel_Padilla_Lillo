using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilController : MonoBehaviour
{

    private bool destruido = false;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("HurBoxPlayer"))
        {
            if (!destruido)
            {
                col.gameObject.GetComponentInParent<PlayerController>().hit(2);
                GetComponent<Animator>().SetTrigger("explotar");
                destruido = true;
            }
        }
        
        if (col.CompareTag("pared"))
        {
            if (!destruido)
            {
                GetComponent<Animator>().SetTrigger("explotar");
                destruido = true;
            }
        }
    }
}
