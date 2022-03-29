using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour {
    public float defaultSpeed = 1f;
    public int timeDash = 20;
    public int life = 5;
    private float speed = 1f;
    private float dashSpeed = 2f;
    private int scale = 1;
    private Animator animator;
    public bool stop = false;
    public bool dashing = false;
    private Blink blink;

    private Vector2 input;

    private Rigidbody2D _rigidbody;

    private void Awake() {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        blink = gameObject.GetComponent<Blink>();
        speed = defaultSpeed;
    }

    void Update()
    {

        if (stop == false) {
            flip();
        
            movimiento();
        }
        else
        {
            _rigidbody.velocity = new Vector2(input.normalized.x * 0, input.normalized.y * 0);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            blink.takeDamage();
        }

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
        life -= damage;
        if (life <= 0)
        {
            animator.SetTrigger("death");
        }
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
}