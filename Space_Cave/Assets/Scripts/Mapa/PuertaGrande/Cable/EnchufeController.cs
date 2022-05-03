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
            accion = true;
            botonInteractuarController.visible();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            accion = false;
            botonInteractuarController.visible();
        }
    }
    
    public void inter(GameObject p)
    {
        if (accion == true && enchufado == false)
        {
            botonInteractuarController.gameObject.SetActive(false);
            bobina.GetComponent<BobinaController>().setEnchufado(true, p);
            enchufado = true;
        }
    }
}
