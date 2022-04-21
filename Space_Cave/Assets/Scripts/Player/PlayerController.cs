using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour {
    public float defaultSpeed = 1f;
    public int life = 8;
    private float speed = 1f;
    private float dashSpeed = 2f;
    private int scale = 1;
    public Animator animator;
    public bool stop = false;
    public bool dashing = false;
    public bool mov = true;
    public Blink blink;
    private bool invulnerable = false;
    public GameObject vida;
    private GunController gunController;

    private Vector2 input;

    public Rigidbody2D _rigidbody;

    private void Awake() {
        speed = defaultSpeed;
        gunController = GetComponent<GunController>();
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("vida"))
        {
            life = PlayerPrefs.GetInt("vida");
            gunController.bulletNum = PlayerPrefs.GetInt("balas");
            gameObject.transform.position = new Vector2(PlayerPrefs.GetFloat("playerX"), PlayerPrefs.GetFloat("playerY"));
        }
    }

    void Update()
    {

        if (stop == false && mov == true) {
            flip();
        
            movimiento();
        }
        else
        {
            animator.SetBool("run",false);
            _rigidbody.velocity = new Vector2(input.normalized.x * 0, input.normalized.y * 0);
        }

        vida.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2((20*life), 15.086f);

    }

    void movimiento() {
        bool up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        bool down = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        bool right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        bool left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        
        if (up) {
            input.y = 1;
        } else if (down) {
            input.y = -1;
        }
        else {
            input.y = 0;
        }
        
        if (right) {
            input.x = 1;
        } else if (left) {
            input.x = -1;
        }
        else {
            input.x = 0;
        }
        
        if (up || down || right || left) {
            animator.SetBool("run",true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("dash");
                speed = dashSpeed;
            }
        }
        else
        {
            animator.SetBool("run",false);
        }
        
        if (dashing == false) {
            _rigidbody.velocity = new Vector2(input.normalized.x * speed, input.normalized.y * speed);
            speed = defaultSpeed;
        }
    }

    public void hit(int damage)
    {
        if (invulnerable == false) {
            life -= damage;
            if (life <= 0)
            {
                animator.SetTrigger("death");
            }
            else {
                blink.takeDamage(2);
                StartCoroutine("invulnerabilidad");
            }
        }
    }

    IEnumerator invulnerabilidad() {
        invulnerable = true;
        yield return new WaitForSeconds(1.5f);
        invulnerable = false;
    }

    void flip() {
        Vector3 localScale = transform.localScale;

        if (input.x > 0) {
            localScale.x = scale;
        }
        else if (input.x < 0) {
            localScale.x = -scale;
        }

        transform.localScale = localScale;
    }

    void desactivarPlayer() {
        gameObject.SetActive(false);
    }
}