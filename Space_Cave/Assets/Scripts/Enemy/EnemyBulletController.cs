using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private GameObject[] players;
    private GameObject player;

    public float bulletSpeed = 0f;
    
    public bool seguir = true;

    private void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Start()
    {
        StartCoroutine("destruir");

        if (players.Length > 1)
        {
            if (Vector3.Distance(players[0].transform.position, transform.position) > Vector3.Distance(players[1].transform.position,transform.position))
            {
                player = players[1];
            }
            else
            {
                player = players[0];
            }
        }
        else
        {
            player = players[0];
        }
        
        StartCoroutine("contarSeguir");
    }

    private void Update()
    {
        if (seguir)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, bulletSpeed*Time.deltaTime);
        }

    }

    IEnumerator contarSeguir()
    {
        yield return new WaitForSeconds(3);
        seguir = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(player.transform.position.x-transform.position.x,player.transform.position.y-transform.position.y);
    }

    IEnumerator destruir()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("HurBoxPlayer"))
        {
            col.gameObject.GetComponentInParent<PlayerController>().hit(1);
            Destroy(gameObject);
        }
    }
}
