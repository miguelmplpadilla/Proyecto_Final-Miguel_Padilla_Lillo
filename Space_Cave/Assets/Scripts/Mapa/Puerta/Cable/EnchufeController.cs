using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EnchufeController : MonoBehaviour
{

    public GameObject bobina;
    
    private bool accion = false;
    private bool enchufado = false;
    private GameObject player;
    
    void Update()
    {
        if (accion == true && enchufado == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                bobina.GetComponent<BobinaController>().setEnchufado(true, player);
                enchufado = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player = col.gameObject;
            accion = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            accion = false;
        }
    }
}
