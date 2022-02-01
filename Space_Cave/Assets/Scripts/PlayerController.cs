using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour {
    public float speed = 1f;
    public float gravity = 1f;
    private int scale = 1;
    private float horizontalInput = 0f;
    private float verticalInput = 0f;

    private Rigidbody2D _rigidbody;

    private bool jump = true;

    private void Awake() {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector3 localScale = transform.localScale;

        Debug.Log(horizontalInput + "  " + verticalInput);
        

        horizontalInput = Input.GetAxisRaw("Horizontal");

        verticalInput = Input.GetAxisRaw("Vertical");


        Vector2 verticalMovement = new Vector2(verticalInput, 0f);
        Vector2 horizontalMovement = new Vector2(horizontalInput, 0f);

        float verticalVelocity = verticalMovement.normalized.x * speed;
        float horizontalVelocity = horizontalMovement.normalized.x * speed;


        _rigidbody.velocity = new Vector2(horizontalVelocity, verticalVelocity);

        if (horizontalInput > 0) {
            localScale.x = scale;
        }
        else if (horizontalInput < 0) {
            localScale.x = -scale;
        }

        transform.localScale = localScale;

        if (Input.GetButtonDown("Jump") && jump == true) {
        }
    }
}