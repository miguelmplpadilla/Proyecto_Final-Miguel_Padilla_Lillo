using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaPequenaController : MonoBehaviour
{

    private Animator puerta;

    private void Awake()
    {
        puerta = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            puerta.SetTrigger("abrir");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puerta.SetTrigger("cerrar");
        }
    }
}
