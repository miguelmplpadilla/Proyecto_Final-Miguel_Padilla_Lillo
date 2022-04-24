using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableSegment : MonoBehaviour {

    public GameObject connectedAbove, connectedBelow;
    private LineRendererCable lineRendererCable;

    private void Awake() {
        lineRendererCable = GameObject.Find("LineRendererCable").GetComponent<LineRendererCable>();
    }

    void Start() {
        lineRendererCable.gameObject.SetActive(true);
        connectedAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        CableSegment aboveSegment = connectedAbove.GetComponent<CableSegment>();
        if (aboveSegment != null) {
            aboveSegment.connectedBelow = gameObject;
            float spriteBottom = connectedAbove.GetComponent<SpriteRenderer>().bounds.size.y;
            spriteBottom = spriteBottom * 40;
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, spriteBottom * -1);
        }
        else {
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }
        
        lineRendererCable.setPoint(gameObject);
        GetComponentInParent<BobinaController>().ultimoCable = gameObject;
        lineRendererCable.gameObject.SetActive(false);
    }
}
