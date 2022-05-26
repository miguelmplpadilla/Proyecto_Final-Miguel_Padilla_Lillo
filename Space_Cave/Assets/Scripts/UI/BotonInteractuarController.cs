using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonInteractuarController : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private Image image;
    public Sprite teclado;
    public Sprite mando;
    public bool ui = false;

    private void Awake() {
        if (ui)
        {
            image = GetComponent<Image>();
        }
        else
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
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
        if (ui)
        {
            if (Input.GetJoystickNames().Length > 0)
            {
                image.sprite = mando;
            }
            else
            {
                image.sprite = teclado;
            }
        }
        else
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
    }

    public void visible() {
        if (ui)
        {
            if (image.enabled) {
                image.enabled = false;
            }
            else {
                image.enabled = true;
            }
        }
        else
        {
            if (spriteRenderer.enabled) {
                spriteRenderer.enabled = false;
            }
            else {
                spriteRenderer.enabled = true;
            }
        }
    }
}
