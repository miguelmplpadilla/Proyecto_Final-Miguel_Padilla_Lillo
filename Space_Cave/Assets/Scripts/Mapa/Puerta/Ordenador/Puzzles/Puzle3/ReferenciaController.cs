using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenciaController : MonoBehaviour {

    public bool enDestino = false;
    
    private void OnTriggerStay2D(Collider2D col) {
        if (col.CompareTag("conectorPuzle")) {
            enDestino = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("conectorPuzle")) {
            enDestino = false;
        }
    }
}
