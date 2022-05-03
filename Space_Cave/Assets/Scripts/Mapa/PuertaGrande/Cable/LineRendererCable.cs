using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererCable : MonoBehaviour
{
    private LineRenderer lr;
    private List<GameObject> puntos = new List<GameObject>();

    private void Awake() {
        lr = GetComponent<LineRenderer>();
        puntos.Add(transform.parent.gameObject);
    }
    
    void Update()
    {
        if (puntos.Count > 0) {
            for (int i = 0; i < puntos.Count; i++) {
                lr.SetPosition(i, puntos[i].transform.position);
            }
        }
    }

    public void setPoint(GameObject punto) {
        puntos.Add(punto);
        lr.positionCount = puntos.Count;
    }
}
