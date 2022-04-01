using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackController : MonoBehaviour {

    public bool detectado = false;
    public float nivelDeteccion = 0f;
    public GameObject detectionBar;

    private void Update()
    {
        if (nivelDeteccion >= 100)
        {
            detectado = true;
        } else if (nivelDeteccion <= 0)
        {
            detectado = false;
        }
        
        float tamano = (nivelDeteccion * 0.2f) / 100;
        detectionBar.transform.localScale = new Vector3(tamano,0.02f,1f );
    }

    public void sumar(float num)
    {
        if (nivelDeteccion < 100)
        {
            nivelDeteccion += num;
        }
        
        if (nivelDeteccion > 100)
        {
            nivelDeteccion = 100;
        }
    }

    public void restar(float num)
    {
        if (nivelDeteccion > 0)
        {
            nivelDeteccion -= num;
        }
        if (nivelDeteccion < 0)
        {
            nivelDeteccion = 0;
        }
    }

}
