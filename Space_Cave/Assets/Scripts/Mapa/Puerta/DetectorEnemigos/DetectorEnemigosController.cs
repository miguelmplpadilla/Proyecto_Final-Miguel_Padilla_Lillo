using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorEnemigosController : MonoBehaviour
{
    public GameObject[] enemigos;
    public Animator[] puertas;
    private bool abierto = false;


    private void LateUpdate()
    {
        if (!abierto)
        {
            int j = 0;
            for (int i = 0; i < enemigos.Length; i++)
            {
                if (enemigos[i] == null)
                {
                    j++;
                }
            }

            if (j == enemigos.Length)
            {
                for (int i = 0; i < puertas.Length; i++) {
                    puertas[i].SetTrigger("abrir");
                }
            }
        }
    }
}
