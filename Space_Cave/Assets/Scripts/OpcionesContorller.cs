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
        cambioIdioma.AddRange(GameObject.FindGameObjectsWithTag("Interactuar").ToList());
        players = GameObject.FindGameObjectsWithTag("Player").ToList();
        dropdown.value = dropdown.options.FindIndex(option => option.text == idioma);
    }

    private void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals("Inicio"))
        {
            if (Input.GetButtonDown("Opciones"))
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
            bool abrir = false;
            if (players.Count > 0)
            {
                abrir = players[0].GetComponentInChildren<InteractuarController>().interaactuando;
            }
            
            if (!abrir)
            {
                animatorPanelOpciones.SetTrigger("abrir");
                abierto = true;
                abriendo = true;
                if (players.Count > 0)
                {
                    if (!players[0].GetComponentInChildren<InteractuarController>().interaactuando)
                    {
                        players[0].GetComponent<PlayerController>().mov = false;
                        players[0].GetComponentInChildren<InteractuarController>().interaactuando = true;
                    }
                }
            }
        }
    }
    
    public void cerrarOpciones() {
        if (!abriendo)
        {
            animatorPanelOpciones.SetTrigger("cerrar");
            abierto = false;
            abriendo = true;
            if (players.Count > 0)
            {
                players[0].GetComponent<PlayerController>().mov = true;
                players[0].GetComponentInChildren<InteractuarController>().interaactuando = false;  
            }
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
            borrarPartida();
            
            PlayerPrefs.SetString("siguenteEscena", "Nivel1");
        }
        else
        {
            string nivel = "Nivel1";
            if (PlayerPrefs.HasKey("nivel"))
            {
                nivel = PlayerPrefs.GetString("nivel");
            }
            
            PlayerPrefs.SetString("siguenteEscena", nivel);
        }
        
        SceneManager.LoadScene("Load");
    }

    public void salirJuego() {
        if (PlayerPrefs.GetInt("autoGuardado") == 1)
        {
            borrarPartida();
        }
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void borrarPartida()
    {
        PlayerPrefs.DeleteKey("vida");
        PlayerPrefs.DeleteKey("balas");
        PlayerPrefs.DeleteKey("playerX");
        PlayerPrefs.DeleteKey("playerY");
        PlayerPrefs.DeleteKey("nivel");
        PlayerPrefs.DeleteKey("puntos");
        PlayerPrefs.DeleteKey("gun");
        PlayerPrefs.Save();
    }

    public void volverInicio()
    {
        SceneManager.LoadScene("Inicio");
    }
    
}
