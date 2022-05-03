using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puzle2Controller : MonoBehaviour
{
    public RotarCalibrador[] calibradores;
    public int final = 0;
    public Animator puerta;
    public PlayerController playerController;

    private void Start()
    {
        calibradores[final].startRotar();
    }

    public void siguenteCalibrador()
    {
        calibradores[final].stopRotar();
        final++;
        if (final >= calibradores.Length)
        {
            puerta.SetTrigger("abrir");
            transform.parent.gameObject.SetActive(false);
            playerController.mov = true;
        }
        else
        {
            calibradores[final].startRotar();
        }
    }
}
