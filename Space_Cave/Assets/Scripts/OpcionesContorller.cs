using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesContorller : MonoBehaviour {
    
    public void abrirOpciones(Animator animator) {
        animator.SetTrigger("abrir");
    }
    
    public void cerrarOpciones(Animator animator) {
        animator.SetTrigger("cerrar");
    }
}
