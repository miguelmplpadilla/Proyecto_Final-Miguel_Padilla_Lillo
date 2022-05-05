using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class Puzzle1Controller : MonoBehaviour
{
    public GameObject[] objectDesplazador = new GameObject[4];
    private DesplazadorController[] desplazadorControllers = new DesplazadorController[4];
    public Animator puerta;
    
    private bool[] listos = new bool[4];
    private bool[] comprobacion = {true, true, true, true };
    
    private GameObject[] players;

    private void Awake()
    {
        desplazadorControllers[0] = objectDesplazador[0].GetComponent<DesplazadorController>();
        desplazadorControllers[1] = objectDesplazador[1].GetComponent<DesplazadorController>();
        desplazadorControllers[2] = objectDesplazador[2].GetComponent<DesplazadorController>();
        desplazadorControllers[3] = objectDesplazador[3].GetComponent<DesplazadorController>();
        
        players = GameObject.FindGameObjectsWithTag("Player");

        StartCoroutine("moverDesplazadores");
    }

    void Update()
    {
        listos[0] = desplazadorControllers[0].listo;
        listos[1] = desplazadorControllers[1].listo;
        listos[2] = desplazadorControllers[2].listo;
        listos[3] = desplazadorControllers[3].listo;

        if (Enumerable.SequenceEqual(listos, comprobacion))
        {
            puerta.SetTrigger("abrir");
            gameObject.transform.parent.gameObject.SetActive(false);
            for (int i = 0; i < players.Length; i++)
            {
                players[i].GetComponent<PlayerController>().mov = true;
            }
            Destroy(gameObject);
        }
        
    }

    IEnumerator moverDesplazadores()
    {
        int i = 0;
        while (true)
        {
            float verticalInput = Input.GetAxisRaw("Vertical");
            desplazadorControllers[i].transform.position = new Vector2(desplazadorControllers[i].transform.position.x, desplazadorControllers[i].transform.position.y+verticalInput*10);
            if (desplazadorControllers[i].listo)
            {
                i++;
            }
            yield return null;
        }
    }
}
