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
    private List<GameObject> cambioIdioma = new List<GameObject>();
    public Animator animatorPanelOpciones;
    private SaveGame saveGame;
    public TMPro.TMP_Dropdown dropdown;
    private bool abriendo = false;

    public bool abierto = false;

    public List<GameObject> players;

    private void Awake() {
        saveGame = GetComponent<SaveGame>();
        idioma = PlayerPrefs.GetString("idioma");
    }

    private void Start()
    {
        cambioIdioma = GameObject.FindGameObjectsWithTag("Idioma").ToList();
        players = GameObject.FindGameObjectsWithTag("Player").ToList();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!abierto)
            {
                abrirOpciones();
            }
            else
            {
                cerrarOpciones();
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
        if (!abriendo)
        {
            if (!players[0].GetComponentInChildren<InteractuarController>().interaactuando)
            {
                animatorPanelOpciones.SetTrigger("abrir");
                abierto = true;
                abriendo = true;
                players[0].GetComponent<PlayerController>().mov = false;
                players[0].GetComponentInChildren<InteractuarController>().interaactuando = true;
            }
        }
    }
    
    public void cerrarOpciones() {
        if (!abriendo)
        {
                animatorPanelOpciones.SetTrigger("cerrar");
                abierto = false;
                abriendo = true;
                players[0].GetComponent<PlayerController>().mov = true;
                players[0].GetComponentInChildren<InteractuarController>().interaactuando = false;
        }
    }

    public void setAbriendo(bool a)
    {
        abriendo = a;
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
