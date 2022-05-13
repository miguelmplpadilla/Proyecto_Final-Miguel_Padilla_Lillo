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
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactuar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactuar = false;
        }
    }

    public void inter(GameObject p)
    {
        if (interactuar)
        {
            p.GetComponentInParent<PlayerController>().mov = false;
            panelGuardadoPartida.SetActive(true);
        }
    }

    public void iniciarSesion(GameObject panelInicioSesion)
    {
        panelInicioSesion.SetActive(true);
    }
    
    public void registrar(GameObject panelRegistrar)
    {
        panelRegistrar.SetActive(true);
    }

    public void cerrarPanelGuardado(GameObject panelGuardado)
    {
        panelGuardado.SetActive(false);
        player.GetComponent<PlayerController>().mov = true;
        player.GetComponentInChildren<InteractuarController>().interaactuando = false;
    }
}
