using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            Color color = new Color();
            ColorUtility.TryParseHtmlString("#E77C00", out color);
            col.GetComponent<Image>().color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("conectorPuzle")) {
            enDestino = false;
            Color color = new Color();
            ColorUtility.TryParseHtmlString("#800000", out color);
            other.GetComponent<Image>().color = color;
        }
    }
}
