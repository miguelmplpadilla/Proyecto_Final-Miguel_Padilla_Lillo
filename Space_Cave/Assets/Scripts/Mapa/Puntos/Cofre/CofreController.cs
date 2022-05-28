using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CofreController : MonoBehaviour {

    public int puntos = 10;
    private bool enCollider = false;
    private GameObject panelPuntos;
    private PuntosController puntosController;
    private BotonInteractuarController botonInteractuarController;

    public Sprite spriteAbierto;

    private bool abierto = false;

    private void Awake() {
        panelPuntos = GameObject.Find("PanelPuntuacion");
        puntosController = panelPuntos.GetComponent<PuntosController>();
        botonInteractuarController = GetComponentInChildren<BotonInteractuarController>();
    }

    public void inter( GameObject player) {
        if (enCollider && !abierto) {
            puntosController.setPuntos(puntos);
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteAbierto;
            abierto = true;
            botonInteractuarController.visible();
            player.GetComponentInChildren<InteractuarController>().interaactuando = false;
            GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            player.GetComponentInChildren<InteractuarController>().interaactuando = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player") && !abierto) {
            enCollider = true;
            botonInteractuarController.visible();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player") && !abierto) {
            enCollider = false;
            botonInteractuarController.visible();
        }
    }
}
