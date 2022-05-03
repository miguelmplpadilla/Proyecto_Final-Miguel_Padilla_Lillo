using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenciaController : MonoBehaviour {

    public bool enDestino = false;
    private RotarCalibrador rotarCalibrador;
    public Puzle2Controller puzle2Controller;
    private bool parar = false;

    private void Awake()
    {
        rotarCalibrador = gameObject.transform.parent.GetComponent<RotarCalibrador>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("InteractuarPuzle"))
        {
            if (enDestino && rotarCalibrador.girar && !parar)
            {
                puzle2Controller.siguenteCalibrador();
                parar = true;
            }
        }
    }

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
