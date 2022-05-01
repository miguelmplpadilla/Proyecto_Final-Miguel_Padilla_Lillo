using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuntosController : MonoBehaviour
{
    private TextMeshProUGUI textoPuntos;
    private Animator puntosAnimator;
    private int puntos = 0;

    private void Awake() {
        textoPuntos = GetComponentInChildren<TextMeshProUGUI>();
        puntosAnimator = GetComponentInChildren<Animator>();
    }

    private void Start() {
        if (PlayerPrefs.HasKey("vida"))
        {
            if (!SceneManager.GetActiveScene().name.Equals("SampleScene")) {
                puntos = PlayerPrefs.GetInt("puntos");
            }
        }
    }

    private void LateUpdate()
    {
        textoPuntos.text = puntos.ToString();
    }

    public void setPuntos(int p)
    {
        puntos += p;
        puntosAnimator.SetTrigger("chispear");
    }

    public int getPuntos() {
        return puntos;
    }
    
}
