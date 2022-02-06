using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    private bool entrado = false;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (entrado == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Golpeado");
                /*if (player != null)
                {
                    player.transform.position = transform.parent.position;
                }*/
                Destroy(transform.parent.gameObject);
            }
        }
        
        Debug.Log(entrado);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        entrado = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        entrado = false;
    }
}
