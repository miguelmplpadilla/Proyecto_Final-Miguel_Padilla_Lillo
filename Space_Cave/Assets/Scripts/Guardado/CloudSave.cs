using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CloudSave : MonoBehaviour {
    public string servidorBaseDatos = "localhost";
    public string nombreBaseDatos = "space_cave";
    public string usrBaseDatos = "root";
    public string pwdBaseDatos = "";

    private string datosConexion;
    private MySqlConnection conexion;

    public TMP_InputField nombreInicioSesion;
    public TMP_InputField contrasenaInicioSesion;
    public TMP_InputField nombreRegistro;
    public TMP_InputField contrasenaRegistro;

    public TextMeshProUGUI textoUsuario;

    private void Start() {
        datosConexion = "Server=" + servidorBaseDatos
                                  + ";Database=" + nombreBaseDatos
                                  + ";Uid=" + usrBaseDatos
                                  + ";Pwd=" + pwdBaseDatos
                                  + ";";

        conectarBaseDatos();

        setUsuarioTexto();
    }

    private void setUsuarioTexto()
    {
        if (PlayerPrefs.HasKey("usuario"))
        {
            textoUsuario.text = PlayerPrefs.GetString("usuario");
        }
        else
        {
            textoUsuario.text = "Sesion no iniciada";
        }
    }


    public void registrar()
    {
        MySqlCommand cmd = conexion.CreateCommand();

        bool correcto = true;
        
        if (nombreRegistro.text.Length < 3 || nombreRegistro.text.Length > 10)
        {
            bool decision = EditorUtility.DisplayDialog(
                "Error registro",
                "Escribe un nombre de usuario", 
                "Ok"
            );
            correcto = false;
        }
        
        if (nombreRegistro.text.Length < 3 || nombreRegistro.text.Length > 10 && correcto)
        {
            bool decision = EditorUtility.DisplayDialog(
                "Error registro",
                "Escribe una contraseña", 
                "Ok"
            );
            correcto = false;
        }

        if (correcto)
        {
            cmd.CommandText = "INSERT INTO `usuarios` (`id`,`nombre`, `contrasena`) VALUES (NULL ,'"+nombreRegistro.text+"', '"+contrasenaRegistro.text+"')";
            MySqlDataReader resultado = cmd.ExecuteReader();

            resultado.Read();
            
            PlayerPrefs.SetInt("idUsuario", resultado.GetInt32(0));
            PlayerPrefs.SetString("usuario", nombreRegistro.text);
            PlayerPrefs.SetString("contrasena", contrasenaRegistro.text);

            nombreRegistro.text = "";
            contrasenaRegistro.text = "";

            bool decision = EditorUtility.DisplayDialog(
                "Registro correcto",
                "Usuario registrado correctamente", 
                "Ok"
            );
            
            nombreRegistro.transform.parent.gameObject.SetActive(false);
            
            setUsuarioTexto();
            resultado.Close();
        }
    }

    public void guardarNube()
    {
        
        GetComponent<SaveGame>().guardarPartida();
        
        MySqlCommand cmd = conexion.CreateCommand();
        
        if (PlayerPrefs.HasKey("usuario"))
        {
            cmd.CommandText = "INSERT INTO `partida` (`id`,`nivel`, `puntuacion`, `posicion_nivel`, `fk_usuario`, `vida`) VALUES (NULL ,'"+PlayerPrefs.GetString("nivel")+"', '"+PlayerPrefs.GetString("puntos")+"', '"+"1"+"', '"+PlayerPrefs.GetInt("idUsuario")+"', '"+PlayerPrefs.GetInt("vida")+"')";
            MySqlDataReader resultado = cmd.ExecuteReader();
            resultado.Close();
            
            bool decision = EditorUtility.DisplayDialog(
                "Guardado en la nube correcto",
                "Se ha guardado correctamente en la nube", 
                "Ok"
            );
        }
        else
        {
            bool decision = EditorUtility.DisplayDialog(
                "Error guardado",
                "Necesitas iniciar sesion para poder guardar en la nube", 
                "Ok"
            );
        }
    }

    public void iniciarSesion()
    {
        MySqlCommand cmd = conexion.CreateCommand();
        cmd.CommandText = "SELECT * FROM `usuarios` WHERE `nombre` = '"+nombreInicioSesion.text+"' AND `contrasena` = '"+contrasenaInicioSesion.text+"'";
        MySqlDataReader resultado = cmd.ExecuteReader();

        if (resultado.HasRows)
        {
            bool decision = EditorUtility.DisplayDialog(
                "Inicio de sesion correcto",
                "Se ha iniciado sesion correctamente", 
                "Ok"
            );

            resultado.Read();
            
            PlayerPrefs.SetInt("idUsuario", resultado.GetInt32(0));
            PlayerPrefs.SetString("usuario", nombreInicioSesion.text);
            PlayerPrefs.SetString("contrasena", contrasenaInicioSesion.text);

            nombreInicioSesion.text = "";
            contrasenaInicioSesion.text = "";
            
            nombreInicioSesion.transform.parent.gameObject.SetActive(false);
            setUsuarioTexto();
        }
        else
        {
            bool decision = EditorUtility.DisplayDialog(
                "Error inicio de sesion",
                "No se ha encontrado el usuario especificado", 
                "Ok"
            );
        }
        
        resultado.Close();
        
    }

    private void conectarBaseDatos() {
        conexion = new MySqlConnection(datosConexion);
        try {
            conexion.Open();
        }
        catch (Exception error) {
            Debug.Log("Conexion incorrecta a base de datos: "+error);
        }

    }
}
