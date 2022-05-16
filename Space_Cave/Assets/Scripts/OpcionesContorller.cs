using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpcionesContorller : MonoBehaviour {

    public string idioma = "Español";
    public List<GameObject> cambioIdioma = new List<GameObject>();
    public Animator animatorPanelOpciones;
    private SaveGame saveGame;
    public TMPro.TMP_Dropdown dropdown;

    private bool abierto = false;

    public List<GameObject> players;

    private void Awake() {
        saveGame = GetComponent<SaveGame>();
        //idioma = PlayerPrefs.GetString("idioma");
    }

    private void Start()
    {
        cambioIdioma = GameObject.FindGameObjectsWithTag("Idioma").ToList();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!abierto)
            {
                abrirOpciones();
                abierto = true;
            }
            else
            {
                cerrarOpciones();
                abierto = false;
            }
            
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

    public void cambiarIdioma() {
        idioma = dropdown.options[dropdown.value].text;
        for (int i = 0; i < cambioIdioma.Count; i++) {
            cambioIdioma[i].SendMessage("cambiarIdioma");
        }
        PlayerPrefs.SetString("idioma", idioma);
        PlayerPrefs.Save();
    }

    public string getIdioma() {
        return idioma;
    }

    public void cambiarNivel(bool nuevaPartida) {
        if (nuevaPartida) {
            PlayerPrefs.DeleteAll();
        }
        SceneManager.LoadScene("Nivel1");
    }

    public void salirJuego() {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    
}
