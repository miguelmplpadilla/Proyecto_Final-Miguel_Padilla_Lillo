using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    
    public TextAsset dialogos;

    public Hablantes hablante;
    private String currentFrase = "";

    public GameObject panel;
    public GameObject gameObjectTexto;
    private TextMeshProUGUI texto;

    private List<String> frases = new List<string>();
    private DialogeController dialogeController;

    private bool hablar = false;
    private bool hablando = false;

    private void Awake()
    {
        dialogeController = GetComponent<DialogeController>();
        texto = gameObjectTexto.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        frases = dialogeController.getTextoDialogos(dialogos, hablante.ToString());
    }

    
    void Update()
    {
        if (hablar == true && hablando == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                hablando = true;
                panel.SetActive(true);
                StartCoroutine("mostrarFrase");
            }
        }

        if (hablando == true)
        {
            
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
        hablar = false;
        hablando = false;
        panel.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hablar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dejarHablar();
        }
    }
}

public enum Hablantes {
    NPC1,
    NPC2,
    NPC3
}
