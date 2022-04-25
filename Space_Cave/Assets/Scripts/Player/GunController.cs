using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public Animator animator;
    public GameObject player;
    public GameObject shootPoint;
    public GameObject bullet;
    public float bulletSpeed = 6;
    public bool gun = false;
    public bool shooting = false;
    public int bulletNum = 5;
    public GameObject bullets;

    public KeyCode disparar = KeyCode.Space;
    public KeyCode taser = KeyCode.Alpha1;
    public KeyCode pistola = KeyCode.Alpha2;
    
    public int numeroJugador = 1;

    private void Awake()
    {
        if (numeroJugador == 2)
        {
            disparar = KeyCode.RightControl;
            taser = KeyCode.Alpha9;
            pistola = KeyCode.Alpha0;
        }
    }

    void Update() {

        if (Input.GetKeyDown(taser)) {
            gun = false;
        } else if (Input.GetKeyDown(pistola)) {
            gun = true;
        }
        
        animator.SetBool("gun",gun);

        if (gun == true) {

            if (Input.GetKeyDown(disparar)) {
                if (bulletNum > 0)
                {
                    if (shooting == false) {
                        shoot();
                    }
                }
            }
            
        }

        bullets.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(15*bulletNum, 20);
        
    }

    void shoot()
    {

        bulletNum--;
        
        animator.SetTrigger("shoot");

        Vector3 start = shootPoint.transform.position;
        
        GameObject bullet = (GameObject) Instantiate(this.bullet, start, transform.rotation);
        bullet.GetComponent<BulletController>().padre = gameObject;
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
    
}
