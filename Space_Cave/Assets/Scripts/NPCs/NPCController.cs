using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Recorder;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    
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

    private List<String> frases = new List<string>();
    private DialogeController dialogeController;

    private bool hablar = false;
    private bool hablando = false;
    public string idioma = "Español";

    private void Awake() {
        opcionesContorller = GameObject.Find("OpcionesController").GetComponent<OpcionesContorller>();
        dialogeController = GetComponent<DialogeController>();
        texto = objectTexto.GetComponent<TextMeshProUGUI>();
        animator = gameObject.GetComponent<Animator>();
        botonInteractuarController = GetComponentInChildren<BotonInteractuarController>();
    }

    void Start() {
        idioma = opcionesContorller.getIdioma();
        frases = dialogeController.getTextoDialogos(dialogos, hablante, idioma);
    }

    
    void Update()
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
    }

    IEnumerator mostrarFrase()
    {
        bool seguir = true;
        for (int i = 0; i < frases.Count; i++)
        {
            if (seguir == true)
            {
                for (int j = 0; j < frases[i].Length; j++)
                {
                    currentFrase = currentFrase + frases[i][j];
                    texto.text = currentFrase;
                    if (hablando == false)
                    {
                        currentFrase = "";
                        yield break;
                    }
                    yield return new WaitForSeconds(0.01f);
                }

                seguir = false;
                currentFrase = "";
            }

            while (!seguir)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    seguir = true;
                }
                yield return null;
            }
        }
        dejarHablar();
    }

    private void dejarHablar()
    {
        player.GetComponent<PlayerController>().mov = true;
        StopCoroutine("mostrarFrase");
        hablando = false;
        panel.SetActive(false);
        animator.SetBool("talk",false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hablar = true;
            botonInteractuarController.visible();
            player = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hablar = false;
            botonInteractuarController.visible();
            currentFrase = "";
            dejarHablar();
        }
    }
    
    public void cambiarIdioma() {
        idioma = opcionesContorller.getIdioma();
        frases = dialogeController.getTextoDialogos(dialogos, hablante, idioma);
    }
}
