using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpcionesContorller : MonoBehaviour {

    public string idioma = "Español";
    public List<GameObject> cambioIdioma = new List<GameObject>();
    public Animator animatorPanelOpciones;
    private SaveGame saveGame;

    public List<GameObject> players;

    private void Awake() {
        saveGame = GetComponent<SaveGame>();
        idioma = PlayerPrefs.GetString("idioma");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            abrirOpciones();
        }
    }
    
    public void guardarPartida(bool salir) {
        saveGame.guardarPartida();
        if (salir) {
            Application.Quit();
        }
    }

    public void abrirOpciones() {
        animatorPanelOpciones.SetTrigger("abrir");
    }
    
    public void cerrarOpciones() {
        animatorPanelOpciones.SetTrigger("cerrar");
    }

    public void cambiarIdioma(TMPro.TMP_Dropdown dropdown) {
        idioma = dropdown.options[dropdown.value].text;
        for (int i = 0; i < cambioIdioma.Count; i++) {
            if (cambioIdioma[i].CompareTag("UI"))
            {
                cambioIdioma[i].GetComponent<IdiomaOpciones>().cambiarIdioma();
            } else if (cambioIdioma[i].CompareTag("NPC"))
            {
                cambioIdioma[i].GetComponent<NPCController>().cambiarIdioma();
            }
        }
    }

    public string getIdioma() {
        return idioma;
    }
}
