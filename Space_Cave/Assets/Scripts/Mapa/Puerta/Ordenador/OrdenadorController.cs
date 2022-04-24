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

    private GameObject[] players;

    private void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
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

    public void inter()
    {
        if (activo == true && enPuzle == false)
        {
            enPuzle = true;
            panelPuzle.SetActive(true);
        }

        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerController>().mov = false;
        }
    }
}
