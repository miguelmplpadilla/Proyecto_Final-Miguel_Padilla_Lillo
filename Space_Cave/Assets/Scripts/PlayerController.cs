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
    public int timeDash = 20;
    private float speed = 1f;
    private float dashSpeed = 2f;
    private int scale = 1;
    private float horizontalInput = 0f;
    private float verticalInput = 0f;

    private Vector2 input;

    private Rigidbody2D _rigidbody;

    private bool jump = true;

    private void Awake() {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {

        movimiento();

        flip();

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
        
        _rigidbody.velocity = new Vector2(input.normalized.x * speed, input.normalized.y * speed);

        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine("dash");
        }
        
    }

    IEnumerator dash() {
        speed = dashSpeed;
        
        for (int i = 0; i < timeDash; i++) {
            yield return null;
        }

        speed = defaultSpeed;
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