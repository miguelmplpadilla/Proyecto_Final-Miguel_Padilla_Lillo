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

    public Sprite spriteAbierto;

    private bool abierto = false;

    private void Awake() {
        panelPuntos = GameObject.Find("PanelPuntuacion");
        puntosController = panelPuntos.GetComponent<PuntosController>();
    }

    public void inter() {
        if (enCollider && !abierto) {
            puntosController.setPuntos(puntos);
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteAbierto;
            abierto = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            enCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            enCollider = false;
        }
    }
}
