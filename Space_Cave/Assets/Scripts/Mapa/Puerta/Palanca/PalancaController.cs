using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalancaController : MonoBehaviour
{

    private bool accion = false;
    private bool abierto = false;
    public Animator puerta;
    public Sprite palancaAbierta;
    public Sprite palancaCerrada;
    private BotonInteractuarController botonInteractuarController;

    private void Awake() {
        botonInteractuarController = GetComponentInChildren<BotonInteractuarController>();
    }

    void Update()
    {

        if (abierto == false)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = palancaCerrada;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = palancaAbierta;
        }
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

    public void inter()
    {
        if (accion == true)
        {
            abierto = !abierto;
            if (abierto == true)
            {
                puerta.SetTrigger("abrir");
            }
            else
            {
                puerta.SetTrigger("cerrar");
            }
        }
    }
}
