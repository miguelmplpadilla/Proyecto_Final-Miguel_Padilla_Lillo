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
    
    private BotonInteractuarController botonInteractuarController;
    
    private void Awake() {
        botonInteractuarController = gameObject.transform.parent.GetChild(3).GetComponent<BotonInteractuarController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (bobina.GetComponent<BobinaController>().posicion)
            {
                accion = true;
                botonInteractuarController.visible();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (bobina.GetComponent<BobinaController>().posicion)
            {
                accion = false;
                botonInteractuarController.visible();
            }
        }
    }
    
    public void inter(GameObject p)
    {
        if (accion == true && enchufado == false && bobina.GetComponent<BobinaController>().posicion)
        {
            botonInteractuarController.gameObject.SetActive(false);
            bobina.GetComponent<BobinaController>().setEnchufado(true, p);
            enchufado = true;
            p.GetComponentInChildren<InteractuarController>().interaactuando = false;
        }
    }
}
