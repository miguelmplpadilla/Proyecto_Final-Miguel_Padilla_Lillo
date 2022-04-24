using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrdenadorController : MonoBehaviour
{

    private bool activo = false;
    private bool enPuzle = false;
    public GameObject panelPuzle;
    
    void Update()
    {
        if (activo == true && enPuzle == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                enPuzle = true;
                panelPuzle.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            activo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            activo = false;
        }
    }
}
