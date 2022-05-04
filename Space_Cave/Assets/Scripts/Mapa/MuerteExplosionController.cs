using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteExplosionController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            col.GetComponent<PlayerController>().hit(10);
        }
    }
}
