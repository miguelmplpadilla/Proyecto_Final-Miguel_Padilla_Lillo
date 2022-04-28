using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackController : MonoBehaviour {

    public bool detectado = false;
    public float nivelDeteccion = 0f;
    public GameObject detectionBar;
    public GameObject detectionAlert;
    public Animator animator;
    private GameObject player = null;
    public float distancia = 0f;
    public float speed = 3f;
    public float speedY = 2f;
    public GameObject shootingPoint1;
    public GameObject shootingPoint2;
    public GameObject bullet;
    public float bulletSpeed = 3;

    public bool mov = true;

    private void Update()
    {
        if (mov == true) {
            if (nivelDeteccion >= 100)
            {
                detectado = true;
            } else if (nivelDeteccion <= 0)
            {
                detectado = false;
            }

            if (nivelDeteccion > 0 && !detectado) {
                detectionAlert.GetComponent<SpriteRenderer>().color = new Color(250f,215f,0,1f);
            } else if (detectado == true) {
                detectionAlert.GetComponent<SpriteRenderer>().color = new Color(255f,0,0,1f);
            } else if (nivelDeteccion <= 0 && detectado == false) {
                detectionAlert.GetComponent<SpriteRenderer>().color = new Color(250f,215f,0,0);
            }

            if (nivelDeteccion > 50 || detectado) {
                if (player != null)
                {
                    if (player.transform.position.x > gameObject.transform.position.x)
                    {
                        gameObject.transform.localScale = new Vector3(1f,1f,1f);
                    }
                    else
                    {
                        gameObject.transform.localScale = new Vector3(-1f,1f,1f);
                    }
                    
                    if (detectado)
                    {
                        distancia = Vector3.Distance(gameObject.transform.position, player.transform.position);
                        if (distancia > 0.6f)
                        {
                            animator.SetBool("shoot", false);
                            animator.SetBool("run", true);
                            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                        }
                        else
                        {
                            animator.SetBool("run", false);
                            animator.SetBool("shoot", true);
                        }
                        
                        Vector2 posicionY = new Vector2(transform.position.x,player.transform.position.y);
                        transform.position = Vector2.MoveTowards(transform.position, posicionY, speedY * Time.deltaTime);
                    }
                }
            }
            else
            {
                animator.SetBool("shoot", false);
            }
        }
        else {
            animator.SetBool("shoot", false);
            animator.SetBool("run", false);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        
        

        //float tamano = (nivelDeteccion * 0.2f) / 100;
        //detectionBar.transform.localScale = new Vector3(tamano,0.02f,1f );
    }

    public void sumar(float num)
    {
        if (nivelDeteccion < 100)
        {
            nivelDeteccion += num;
        }
        
        if (nivelDeteccion > 100)
        {
            nivelDeteccion = 100;
        }
    }

    public void restar(float num)
    {
        if (nivelDeteccion > 0)
        {
            nivelDeteccion -= num;
        }
        if (nivelDeteccion < 0)
        {
            nivelDeteccion = 0;
        }
    }

    public void setPlayer(GameObject p)
    {
        player = p;
    }

    public void shoot(int point)
    {
        Vector3 start = new Vector3(0,0,0);
        if (point == 1)
        {
            start = shootingPoint1.transform.position;
        }
        else
        {
            start = shootingPoint2.transform.position;
        }
        
        GameObject bullet = (GameObject) Instantiate(this.bullet, start, transform.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        if (transform.localScale.x > 0)
        {
            bulletRigidbody.velocity = new Vector2(1f * bulletSpeed, 0 * bulletSpeed);
        }
        else
        {
            bulletRigidbody.velocity = new Vector2(-1f * bulletSpeed, 0 * bulletSpeed);
        }

        bulletRigidbody.transform.localScale = transform.localScale;
    }
    
    public void setNivelDeteccion(float nivel)
    {
        nivelDeteccion = nivel;
    }

    public void setMov(bool m)
    {
        mov = m;
    }

}