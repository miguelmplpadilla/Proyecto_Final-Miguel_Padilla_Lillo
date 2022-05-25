using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class StartBossBattleController : MonoBehaviour
{

    public GameObject boss;
    public Animator puerta;
    public CinemachineVirtualCamera camara;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            boss.GetComponent<BossController>().empezarAtacar();
            puerta.SetTrigger("cerrar");
            camara.Follow = boss.transform;
            camara.m_Lens.OrthographicSize = 1.5f;
            camara.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.393f;
            Destroy(gameObject);
        }
    }
}
