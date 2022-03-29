using System;
using System.Collections;
using System.Linq;
using Unity.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class Blink : MonoBehaviour
    {
        public Material original, blink;

        public void takeDamage()
        {
            StartCoroutine("blinking");
        }

        IEnumerable blinking()
        {
            GetComponent<SpriteRenderer>().material = blink;
            yield return new WaitForSeconds(2f);
            GetComponent<SpriteRenderer>().material = original;
        }
    }
}