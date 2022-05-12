using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BobinaController : MonoBehaviour {

    public GameObject ultimoCable;
    public GameObject mano = null;
    public GameObject enchufe;
    public GameObject puerta;
    public GameObject linea;
    public CinemachineVirtualCamera camara;

    public bool enchufado = false;
    public bool accion = false;
    public bool posicion = false;
    
    private BotonInteractuarController botonInteractuarController;
    
    private void Awake() {
        botonInteractuarController = gameObject.transform.GetChild(2).GetComponent<BotonInteractuarController>();
    }
    
    void Update()
    {

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
            if (ultimoCable != null) {
                ultimoCable.transform.position = transform.position;
            }
        }

        if ( mano != null)
        {
            if (!mano.activeInHierarchy)
            {
                enchufado = false;
                posicion = false;
                linea.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            accion = true;
            botonInteractuarController.visible();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            accion = false;
            botonInteractuarController.visible();
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

    public void inter(GameObject p)
    {
        mano = p.transform.parent.GetChild(3).gameObject;
        botonInteractuarController.gameObject.SetActive(false);
        
        if (accion == true && enchufado == false) {
            ultimoCable.GetComponent<HingeJoint2D>().connectedAnchor = mano.transform.position;
            ultimoCable.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            linea.SetActive(true);
            posicion = true;
        }
        p.GetComponentInChildren<InteractuarController>().interaactuando = false;
    }
}
