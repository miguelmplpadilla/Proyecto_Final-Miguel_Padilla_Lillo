using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class DesplazadorController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    
    // abajo = 0
    // arriba = 280

    private RectTransform rectTransform;
    private GameObject destino;

    public bool pressed;
    private bool enDestino = false;

    private void Update()
    {
        if (pressed == false && enDestino == true)
        {
            transform.position = destino.transform.position;
        }
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.position.y < 440 && eventData.position.y > 85)
        {
            transform.position = new Vector2(transform.position.x, eventData.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Destino"))
        {
            enDestino = true;
            destino = col.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Destino"))
        {
            enDestino = false;
        }
    }
}
