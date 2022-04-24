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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
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
    
    public void inter(GameObject p)
    {
        if (accion == true && enchufado == false)
        {
            bobina.GetComponent<BobinaController>().setEnchufado(true, p);
            enchufado = true;
        }
    }
}
