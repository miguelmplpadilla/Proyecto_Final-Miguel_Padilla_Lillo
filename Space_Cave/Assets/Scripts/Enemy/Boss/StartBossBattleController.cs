using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossBattleController : MonoBehaviour
{

    public GameObject boss;
    public Animator puerta;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            boss.GetComponent<BossController>().empezarAtacar();
            puerta.SetTrigger("cerrar");
            Destroy(gameObject);
        }
    }
}
