using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectionController : MonoBehaviour {
    
    public bool detectado = false;
    public float numSumar = 1;
    public float numRestar = 1;
    public bool restar;

    private void Awake() {
        StartCoroutine("srDeteccion");
    }

    IEnumerator srDeteccion() {
        while (true)
        {
            if (detectado == true)
            {
                gameObject.transform.parent.gameObject.SendMessage("sumar", numSumar);
            }
            else
            {
                if (restar == true)
                {
                    gameObject.transform.parent.gameObject.SendMessage("restar", numRestar);
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.transform.parent.gameObject.SendMessage("setPlayer", other.gameObject);
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
