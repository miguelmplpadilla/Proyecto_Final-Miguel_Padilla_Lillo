using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovNivelesController : MonoBehaviour {
    public string nivel;
    
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            SceneManager.LoadScene(nivel);
        }
    }
}
