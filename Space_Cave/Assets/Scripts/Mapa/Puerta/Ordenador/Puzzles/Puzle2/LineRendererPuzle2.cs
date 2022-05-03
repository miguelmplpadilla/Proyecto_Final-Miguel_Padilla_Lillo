using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererPuzle2 : MonoBehaviour {
    private LineRenderer lr;
    public GameObject position1;
    public GameObject position2;

    private void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, position1.transform.position);
        lr.SetPosition(1, position2.transform.position);
        lr.startColor = Color.red;
        lr.endColor = Color.red;
    }
}
