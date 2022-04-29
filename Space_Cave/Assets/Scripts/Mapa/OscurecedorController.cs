using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscurecedorController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("HurBoxPlayer"))
        {
            animator.SetTrigger("desvanecer");
        }
    }
}
