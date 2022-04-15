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
    private Rigidbody2D playerRigidbody;
    public float bulletSpeed = 6;
    public bool gun = false;
    public bool shooting = false;
    public int bulletNum = 5;
    public GameObject bullets;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            gun = false;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            gun = true;
        }
        
        animator.SetBool("gun",gun);

        if (gun == true) {

            if (Input.GetKeyDown(KeyCode.Mouse0)) {
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
