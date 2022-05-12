using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarController : MonoBehaviour
{

    private bool hablar = false;
    private GameObject objectinteractuar;
    public bool interaactuando = false;

    public KeyCode interactuar = KeyCode.F;
    
    public int numeroJugador = 1;

    private void Awake()
    {
        if (numeroJugador == 2)
        {
            interactuar = KeyCode.Return;
        }
    }

    void Update()
    {
        if (hablar == true)
        {
            if (!interaactuando) {
                if (Input.GetButtonDown("Interactuar"))
                {
                    objectinteractuar.SendMessage("inter", gameObject);
                    interaactuando = true;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Interactuar"))
        {
            hablar = true;
            objectinteractuar = col.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactuar"))
        {
            hablar = false;
            objectinteractuar = null;
        }
    }
}
