using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarCalibrador : MonoBehaviour {

    public bool girar = true;
    private RectTransform rectTransform;
    private float rotacion = 0;

    public float velocidadRotacion = 2;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start() {
        StartCoroutine("rotar");
    }

    IEnumerator rotar() {
        while (girar) {
            rotacion += Time.deltaTime * (velocidadRotacion*100);
            rectTransform.rotation = Quaternion.Euler(0,0,rotacion).normalized;
            if (rotacion <= -360) {
                rotacion = 0;
            }
            yield return null;
        }
        
        rectTransform.Rotate(0,0,0);
    }

    public void startRotar() {
        StartCoroutine("rotar");
    }
    
}
