using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaGrandeController : MonoBehaviour
{
    public bool abierta = false;

    void Start()
    {
        if (abierta)
        {
            gameObject.GetComponent<Animator>().SetTrigger("abrir");
        }
    }
}
