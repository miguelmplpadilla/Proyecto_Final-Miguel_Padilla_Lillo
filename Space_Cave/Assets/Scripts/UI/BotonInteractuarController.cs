using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonInteractuarController : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    public Sprite teclado;
    public Sprite mando;

    private void Awake() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (gameObject.transform.parent.localScale.x > 0) {
            gameObject.transform.localScale = new Vector2(1f,1f);
        }
        else {
            gameObject.transform.localScale = new Vector2(-1f,1f);
        }
    }

    private void LateUpdate()
    {
        if (Input.GetJoystickNames().Length > 0)
        {
            spriteRenderer.sprite = mando;
        }
        else
        {
            spriteRenderer.sprite = teclado;
        }
    }

    public void visible() {
        if (spriteRenderer.enabled) {
            spriteRenderer.enabled = false;
        }
        else {
            spriteRenderer.enabled = true;
        }
    }
}
