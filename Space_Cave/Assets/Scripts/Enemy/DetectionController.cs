using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectionController : MonoBehaviour {

    private AtackController atackController;
    public bool detectado = false;
    public float numSumar = 1;
    public float numRestar = 1;
    public bool restar;

    private void Awake() {
        atackController = GetComponentInParent<AtackController>();
        StartCoroutine("srDeteccion");
    }

    IEnumerator srDeteccion() {
        while (true)
        {
            if (detectado == true)
            {
                atackController.sumar(numSumar);
            }
            else
            {
                if (restar == true)
                {
                    atackController.restar(numRestar);
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            atackController.setPlayer(other.gameObject);
            detectado = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            detectado = false;
        }
    }
}
