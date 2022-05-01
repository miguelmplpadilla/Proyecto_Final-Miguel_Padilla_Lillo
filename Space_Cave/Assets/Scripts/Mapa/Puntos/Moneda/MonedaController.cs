using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaController : MonoBehaviour
{
    private int puntos = 10;
    private PuntosController puntosController;

    private void Awake() {
        puntosController = GameObject.Find("PanelPuntuacion").GetComponent<PuntosController>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            puntosController.setPuntos(puntos);
            Destroy(gameObject);
        }
    }

    public void setPuntos(int p)
    {
        puntos = p;
    }
}
