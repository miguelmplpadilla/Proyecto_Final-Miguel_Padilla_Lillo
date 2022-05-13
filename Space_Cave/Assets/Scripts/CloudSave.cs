using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UnityEngine;

public class CloudSave : MonoBehaviour {
    public string servidorBaseDatos = "localhost";
    public string nombreBaseDatos = "space_cave";
    public string usrBaseDatos = "root";
    public string pwdBaseDatos = "";

    private string datosConexion;
    private MySqlConnection conexion;

    private void Start() {
        datosConexion = "Server=" + servidorBaseDatos
                                  + ";Database=" + nombreBaseDatos
                                  + ";Uid=" + usrBaseDatos
                                  + ";Pwd=" + pwdBaseDatos
                                  + ";";

        conectarBaseDatos();
    }


    public void registrar() {
        
    }

    private void conectarBaseDatos() {
        conexion = new MySqlConnection(datosConexion);
        try {
            conexion.Open();
            Debug.Log("Conexion corrrecta a base de datos");
        }
        catch (Exception error) {
            Debug.Log("Conexion incorrecta a base de datos: "+error);
        }

    }
}
