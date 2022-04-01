using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionController : MonoBehaviour {

    public AtackController atackController;
    public bool detectado = false;

    private void Awake() {
        StartCoroutine("sumarDeteccion");
    }

    IEnumerator sumarDeteccion() {
        yield return null;
    }
    
}
