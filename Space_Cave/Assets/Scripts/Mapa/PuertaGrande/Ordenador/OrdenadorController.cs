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
    private BotonInteractuarController botonInteractuarController;

    private GameObject[] players;

    private void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        botonInteractuarController = GetComponentInChildren<BotonInteractuarController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            activo = true;
            botonInteractuarController.visible();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            activo = false;
            botonInteractuarController.visible();
        }
    }

    public void inter()
    {
        if (activo == true && enPuzle == false)
        {
            enPuzle = true;
            panelPuzle.SetActive(true);
            botonInteractuarController.gameObject.SetActive(false);
            for (int i = 0; i < players.Length; i++)
            {
                players[i].GetComponent<PlayerController>().mov = false;
            }
        }
        else
        {
            players[0].GetComponentInChildren<InteractuarController>().interaactuando = false;
        }
    }
}
