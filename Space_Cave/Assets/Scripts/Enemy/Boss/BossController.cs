using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    private float startAngle = 0f, endAngle = 360f;
    public int numBalas = 20;
    
    public GameObject hellPoint;
    public GameObject vida;
    public GameObject player;
    public GameObject shootingPoint;
    public GameObject shootingPoint2;
    
    public GameObject bullet;
    public GameObject misil;
    
    void Update()
    {
        vida.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2((20*GetComponentInChildren<EnemyHurt>().life), 15.086f);
    }

    public void bulletHellFire()
    {
        float angleStep = (endAngle - startAngle) / numBalas;
        float angle = startAngle;

        for (int i = 0; i < numBalas + 1; i++)
        {
            float bulDirX = hellPoint.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = hellPoint.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - hellPoint.transform.position).normalized;

            GameObject bul = (GameObject) Instantiate(bullet);
            bul.transform.position = hellPoint.transform.position;
            bul.transform.rotation = hellPoint.transform.rotation;
            bul.GetComponent<BulletBossController>().moveDirection = bulDir;

            angle += angleStep;

        }
    }

    public void shoot(int bala)
    {
        Vector3 start = new Vector3(0,0,0);

        if (bala == 1)
        {
            start = shootingPoint.transform.position;
            GameObject bul = (GameObject) Instantiate(misil, start, transform.rotation);
            Rigidbody2D bulletRigidbody = bul.GetComponent<Rigidbody2D>();

            Vector2 moveDirection = (player.transform.position - transform.position).normalized * 0.7f;
            
            bulletRigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);
        } else if (bala == 2)
        {
            start = shootingPoint2.transform.position;
            GameObject bul = (GameObject) Instantiate(bullet, start, transform.rotation);
            Rigidbody2D bulletRigidbody = bul.GetComponent<Rigidbody2D>();
            bul.GetComponent<SpriteRenderer>().sortingOrder = 2;

            Vector2 moveDirection = (player.transform.position - transform.position).normalized * 0.6f;
            
            bulletRigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
    }

    public void setPlayer(GameObject p)
    {
        player = p;
    }
}
