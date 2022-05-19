using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public KeyCode recargar = KeyCode.R;
    
    public int numeroJugador = 1;

    private bool recargando = false;

    private void Awake()
    {
        if (numeroJugador == 2)
        {
            disparar = KeyCode.RightControl;
            recargar = KeyCode.P;
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("gun"))
        {
            if (!SceneManager.GetActiveScene().name.Equals("SampleScene"))
            {
                if (PlayerPrefs.GetInt("gun") == 1)
                {
                    gun = true;
                }
            }
        }
    }

    void Update() {
        animator.SetBool("gun",gun);

        if (gun && player.GetComponent<PlayerController>().mov) {

            if (!bullets.transform.parent.gameObject.activeSelf) {
                bullets.transform.parent.gameObject.SetActive(true);
            }
            
            if (Input.GetButtonDown("Fire")) {
                if (bulletNum > 0)
                {
                    if (shooting == false) {
                        shoot();
                    }
                }
            }

            if (!recargando)
            {
                if (Input.GetButtonDown("Reload"))
                {
                    recargando = true;
                    StartCoroutine("reload");
                }
            }
            
            /*if (bulletNum <= 0 && !recargando)
            {
                recargando = true;
                StartCoroutine("reload");
            }*/
            
            if (!recargando)
            {
                bullets.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(15*bulletNum, 20);
            }

        }

        

    }


    IEnumerator reload()
    {
        for (int i = bulletNum; i < 5; i++)
        {
            bullets.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(15*(i+1), 20);
            yield return new WaitForSeconds(0.2f);
        }
        bulletNum = 5;
        recargando = false;
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

    public void setGur()
    {
        gun = true;
        PlayerPrefs.SetInt("gun",1);
        PlayerPrefs.SetInt("autoGuardado", 1);
        PlayerPrefs.Save();
    }
    
}
