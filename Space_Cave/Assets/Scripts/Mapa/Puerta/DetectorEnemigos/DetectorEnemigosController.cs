using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorEnemigosController : MonoBehaviour
{
    public GameObject[] enemigos;
    public Animator puerta;
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
                puerta.SetTrigger("abrir");
            }
        }
    }
}
