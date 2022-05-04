using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Recorder;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class NPCController : MonoBehaviour {

    public TextAsset dialogos;

    public string hablante;
    private String currentFrase = "";

    // Componentes
    private Animator animator;
    private GameObject player;


    // UI
    public Sprite image;
    public GameObject panel;
    public GameObject objectTexto;
    private TextMeshProUGUI texto;
    public GameObject imagePanel;
    private OpcionesContorller opcionesContorller;
    private BotonInteractuarController botonInteractuarController;
    public GameObject explosion;
    public Animator puerta;

    private List<String> frases = new List<string>();
    private DialogeController dialogeController;

    public bool hablar = false;
    public bool hablando = false;
    public string idioma = "Español";

    private GameObject[] players;

    private void Awake() {
        opcionesContorller = GameObject.Find("OpcionesController").GetComponent<OpcionesContorller>();
        dialogeController = GetComponent<DialogeController>();
        texto = objectTexto.GetComponent<TextMeshProUGUI>();
        animator = gameObject.GetComponent<Animator>();
        botonInteractuarController = GetComponentInChildren<BotonInteractuarController>();
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Start() {
        idioma = opcionesContorller.getIdioma();
        frases = dialogeController.getTextoDialogos(dialogos, hablante, idioma);
    }


    /*void Update()
    {
        if (hablar == true && hablando == false)
        {
            if (Input.GetKeyDown(KeyCode.F)) {
                player.GetComponent<PlayerController>().mov = false;
                hablando = true;
                panel.SetActive(true);
                imagePanel.GetComponent<Image>().sprite = image;
                StartCoroutine("mostrarFrase");
                animator.SetBool("talk",true);
                if (player.transform.position.x > gameObject.transform.position.x)
                {
                    gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                }
                else
                {
                    gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
                }
            }
        }
    }*/

    private void empezarHablar() {
        if (hablar == true && hablando == false) {
            player.GetComponent<PlayerController>().mov = false;
            hablando = true;
            panel.SetActive(true);
            imagePanel.GetComponent<Image>().sprite = image;
            StartCoroutine("mostrarFrase");
            animator.SetBool("talk", true);
            if (player.transform.position.x > gameObject.transform.position.x) {
                gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else {
                gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }

    IEnumerator mostrarFrase() {
        bool seguir = true;
        for (int i = 0; i < frases.Count; i++) {
            if (seguir == true) {
                if (frases[i].Equals("execute1")) {
                    explosion.SetActive(true);
                    seguir = true;
                } else if (frases[i].Equals("execute2")) {
                    puerta.SetTrigger("abrir");
                    seguir = true;
                } else if (frases[i].Equals("execute3")) {
                    player.GetComponent<GunController>().gun = true;
                    PlayerPrefs.SetInt("gun",1);
                }
                else {
                    for (int j = 0; j < frases[i].Length; j++) {
                        currentFrase = currentFrase + frases[i][j];
                        texto.text = currentFrase;
                        if (hablando == false) {
                            currentFrase = "";
                            yield break;
                        }

                        yield return new WaitForSeconds(0.01f);
                    }
                    seguir = false;
                }
                
                currentFrase = "";
            }

            while (!seguir) {
                if (Input.GetButtonDown("Interactuar")) {
                    seguir = true;
                }

                yield return null;
            }
        }

        dejarHablar();
    }

    private void dejarHablar() {
        player.GetComponent<PlayerController>().mov = true;
        StopCoroutine("mostrarFrase");
        hablando = false;
        panel.SetActive(false);
        animator.SetBool("talk", false);
        for (int i = 0; i < players.Length; i++) {
            players[i].GetComponent<PlayerController>().mov = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            hablar = true;
            botonInteractuarController.visible();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            hablar = false;
            botonInteractuarController.visible();
            currentFrase = "";
        }
    }

    public void cambiarIdioma() {
        idioma = opcionesContorller.getIdioma();
        frases = dialogeController.getTextoDialogos(dialogos, hablante, idioma);
    }

    public void inter(GameObject p) {
        if (!hablando) {
            player = p.transform.parent.gameObject;
            hablando = false;
            empezarHablar();

            for (int i = 0; i < players.Length; i++) {
                players[i].GetComponent<PlayerController>().mov = false;
            }
        }
    }
}
