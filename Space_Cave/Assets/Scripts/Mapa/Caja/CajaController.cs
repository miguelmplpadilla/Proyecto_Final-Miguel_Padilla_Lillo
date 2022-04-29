using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CajaController : MonoBehaviour
{
    public int life = 3;
    private Blink blink;
    private Animator animator;

    private void Awake()
    {
        blink = GetComponent<Blink>();
        animator = GetComponent<Animator>();
    }

    public void hit()
    {
        life--;
        if (life <= 0)
        {
            animator.SetTrigger("destruir");
        }
        else
        {
            blink.takeDamage(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("bala"))
        {
            hit();
            Destroy(col.gameObject);
        }
    }
}
