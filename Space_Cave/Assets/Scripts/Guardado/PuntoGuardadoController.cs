using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuntoGuardadoController : MonoBehaviour
{
    private bool interactuar = false;
    public GameObject panelGuardadoPartida;
    public GameObject player;
    public BotonInteractuarController botonInteractuarController;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (interactuar == false)
            {
                botonInteractuarController.visible();
            }
            interactuar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            botonInteractuarController.visible();
            interactuar = false;
        }
    }

    public void inter(GameObject p)
    {
        if (interactuar)
        {
            p.GetComponentInParent<PlayerController>().mov = false;
            panelGuardadoPartida.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    public void iniciarSesion(GameObject panelInicioSesion)
    {
        panelInicioSesion.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
    
    public void registrar(GameObject panelRegistrar)
    {
        panelRegistrar.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    public void cerrarPanelGuardado(GameObject panelGuardado)
    {
        panelGuardado.GetComponent<RectTransform>().localScale = new Vector3(0, 1, 1);
        player.GetComponent<PlayerController>().mov = true;
        player.GetComponentInChildren<InteractuarController>().interaactuando = false;
    }

    public void volver(GameObject panel)
    {
        panel.GetComponent<RectTransform>().localScale = new Vector3(0, 1, 1);
    }
}
