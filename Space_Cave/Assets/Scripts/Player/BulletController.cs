using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("He tocado algo");
        if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
