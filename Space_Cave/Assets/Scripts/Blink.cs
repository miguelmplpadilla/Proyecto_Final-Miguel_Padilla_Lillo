using System;
using System.Collections;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Material original, blink;

    public void takeDamage(int repeticiones)
    {
        StartCoroutine("blinking", repeticiones);
    }

    IEnumerator blinking(int repeticiones)
    {
        for (int i = 0; i < repeticiones; i++) {
            GetComponent<SpriteRenderer>().material = blink;
            yield return new WaitForSeconds(0.5f);
            GetComponent<SpriteRenderer>().material = original;
        }
    }
}