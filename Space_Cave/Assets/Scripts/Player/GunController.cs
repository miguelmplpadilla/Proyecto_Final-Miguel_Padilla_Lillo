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

                if (shooting == false) {
                    shoot();
                }

            }
            
        }
    }

    void shoot() {
        
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

    }
    
}
