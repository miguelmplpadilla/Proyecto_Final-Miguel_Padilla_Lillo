using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuntosController : MonoBehaviour
{
    public TextMeshProUGUI textoPuntos;
    private int puntos = 0;

    private void LateUpdate()
    {
        textoPuntos.text = puntos.ToString();
    }

    public void setPuntos(int p)
    {
        puntos += p;
    }
    
}
