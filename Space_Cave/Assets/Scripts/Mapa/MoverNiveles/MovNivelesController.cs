using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovNivelesController : MonoBehaviour {
    public string nivel;
    public PuntosController puntosController;
    public bool guardarHistorialPuntos;
    public CloudSave cloudSave;
    public OpcionesContorller opcionesContorller;
    
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            PlayerPrefs.SetInt("vida",col.GetComponent<PlayerController>().life);
            PlayerPrefs.SetInt("puntos", puntosController.getPuntos());

            if (guardarHistorialPuntos)
            {
                cloudSave.guardarHistorialPuntos();
                opcionesContorller.borrarPartida();
                cloudSave.borrarPartidaNube();
            }
            
            PlayerPrefs.SetString("siguenteEscena", nivel);
            
            SceneManager.LoadScene("Load");
        }
    }
}
