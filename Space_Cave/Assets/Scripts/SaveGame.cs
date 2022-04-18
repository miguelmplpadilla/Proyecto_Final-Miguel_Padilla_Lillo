using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerController;
    private GunController gunController;
    private OpcionesContorller opcionesController;

    private void Awake()
    {
        playerController = player.gameObject.GetComponent<PlayerController>();
        gunController = player.gameObject.GetComponent<GunController>();
        opcionesController = GetComponent<OpcionesContorller>();
    }

    public void guardarPartida()
    {
        PlayerPrefs.SetInt("vida", playerController.life);
        PlayerPrefs.SetInt("balas", gunController.bulletNum);
        PlayerPrefs.SetFloat("playerX", player.gameObject.transform.position.x);
        PlayerPrefs.SetFloat("playerY", player.gameObject.transform.position.y);
        PlayerPrefs.SetString("idioma", opcionesController.getIdioma());
        PlayerPrefs.Save();
    }
}
