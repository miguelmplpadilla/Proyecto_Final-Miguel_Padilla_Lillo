using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpcionesController : MonoBehaviour
{

    public OpcionesContorller opcionesContorller;
    
    public void cambiarAbriendo()
    {
        opcionesContorller.setAbriendo(false);
    }
}
