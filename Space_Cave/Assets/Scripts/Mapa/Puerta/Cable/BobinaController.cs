using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BobinaController : MonoBehaviour {

    public GameObject ultimoCable;
    public GameObject mano;
    public GameObject enchufe;
    public GameObject puerta;
    public GameObject linea;
    public CinemachineVirtualCamera camara;

    public bool enchufado = false;
    public bool accion = false;
    private bool posicion = false;
    
    void Update()
    {
        if (accion == true && enchufado == false) {
            if (Input.GetKeyDown(KeyCode.F)) {
                ultimoCable.GetComponent<HingeJoint2D>().connectedAnchor = mano.transform.position;
                ultimoCable.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                linea.SetActive(true);
                posicion = true;
            }
        }
        
        if (posicion == true) {
            if (enchufado == false)
            {
                ultimoCable.transform.position = mano.transform.position;
            }
            else
            {
                ultimoCable.transform.position = enchufe.transform.position;
            }
        }
        else
        {
            ultimoCable.transform.position = transform.position;
        }

        if (!mano.activeInHierarchy)
        {
            enchufado = false;
            posicion = false;
            linea.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            accion = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            accion = false;
        }
    }

    public void setEnchufado(bool e, GameObject player)
    {
        StartCoroutine(moverPuerta(player));
        enchufado = e;
        puerta.GetComponent<Animator>().SetTrigger("abrir");
    }
    
    IEnumerator moverPuerta(GameObject player)
    {
        camara.Follow = puerta.transform;
        yield return new WaitForSeconds(1f);
        camara.Follow = player.transform;
    }
}
