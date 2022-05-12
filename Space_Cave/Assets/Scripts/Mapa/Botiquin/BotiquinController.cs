using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotiquinController : MonoBehaviour
{

    public Sprite spriteSinBotiquin;
    public BotonInteractuarController botonInteractuarController;

    private GameObject player;

    private bool curado = false;
    
    public void inter()
    {
        if (player.GetComponent<PlayerController>().life < 8 && !curado)
        {
            player.GetComponent<PlayerController>().life = 8;
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteSinBotiquin;
            botonInteractuarController.gameObject.SetActive(false);
            curado = true;
            player.GetComponentInChildren<InteractuarController>().interaactuando = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player = col.gameObject;
            botonInteractuarController.visible();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            botonInteractuarController.visible();
        }
    }
}
