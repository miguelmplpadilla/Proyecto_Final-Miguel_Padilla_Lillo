using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpcionesContorller : MonoBehaviour {

    public string idioma = "Español";
    public List<GameObject> cambioIdioma = new List<GameObject>();

    public void abrirOpciones(Animator animator) {
        animator.SetTrigger("abrir");
    }
    
    public void cerrarOpciones(Animator animator) {
        animator.SetTrigger("cerrar");
    }

    public void cambiarIdioma(TMP_Dropdown dropdown) {
        idioma = dropdown.options[dropdown.GetComponent<Dropdown>().value].text;
        for (int i = 0; i < cambioIdioma.Count; i++) {
            cambioIdioma[i].GetComponent<IdiomaOpciones>().cambiarIdioma();
        }
    }

    public string getIdioma() {
        return idioma;
    }
}
