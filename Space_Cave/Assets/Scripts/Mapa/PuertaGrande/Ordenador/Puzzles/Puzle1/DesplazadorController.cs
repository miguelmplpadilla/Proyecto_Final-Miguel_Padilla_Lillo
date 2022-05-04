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
    private GameObject destino;

    private bool pressed;
    public bool enDestino = false;
    public bool listo = false;

    private void Update()
    {
        if (pressed == false && enDestino == true)
        {
            transform.position = destino.transform.position;
            listo = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
        listo = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < 0 && Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -1)
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
            listo = false;
            enDestino = false;
        }
    }
}
