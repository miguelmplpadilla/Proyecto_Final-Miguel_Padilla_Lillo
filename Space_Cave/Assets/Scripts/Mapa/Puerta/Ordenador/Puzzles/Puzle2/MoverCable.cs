using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MoverCable : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler {
    
    private bool enDestino = false;
    public GameObject puntoPartida;

    public GameObject enchufe;
    private GameObject colisionEnchufe;

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!enDestino) {
            transform.position = puntoPartida.transform.position;
        }
        else {
            if (enchufe.Equals(colisionEnchufe)) {
                transform.position = enchufe.transform.position;
            }
            else {
                transform.position = puntoPartida.transform.position;
                enDestino = false;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.position.y < 440 && eventData.position.y > 85)
        {
            transform.position = new Vector2(eventData.position.x, eventData.position.y);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        colisionEnchufe = null;
        enDestino = false;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        colisionEnchufe = col.gameObject;
        enDestino = true;
    }
}
