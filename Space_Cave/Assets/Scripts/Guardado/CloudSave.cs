using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloudSave : MonoBehaviour {
    public string servidorBaseDatos = "localhost";
    public string nombreBaseDatos = "space_cave";
    public string usrBaseDatos = "root";
    public string pwdBaseDatos = "";

    private string datosConexion;
    private MySqlConnection conexion;
    private bool conectado = false;

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

    public void abrirMenu(GameObject menu)
    {
        menu.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    public void cargarPartidaNube()
    {
        bool realizar = true;
        if (!conectado) {
            realizar = conectarBaseDatos();
        }

        if (realizar)
        {
            if (PlayerPrefs.HasKey("usuario"))
            {
                MySqlCommand cmd = conexion.CreateCommand();
                cmd.CommandText = "SELECT * FROM `partida` WHERE `fk_usuario` = '"+PlayerPrefs.GetInt("idUsuario")+"'";
                MySqlDataReader resultado = cmd.ExecuteReader();

                resultado.Read();
                
                if (resultado.HasRows)
                {
                    PlayerPrefs.SetInt("vida", resultado.GetInt32(6));
                    PlayerPrefs.SetString("nivel", resultado.GetString(1));
                    PlayerPrefs.SetInt("puntos", resultado.GetInt32(2));
                    PlayerPrefs.SetFloat("playerX", float.Parse(resultado.GetString(3)));
                    PlayerPrefs.SetFloat("playerY", float.Parse(resultado.GetString(4)));
                    PlayerPrefs.SetInt("gun", resultado.GetInt32(7));
                    PlayerPrefs.Save();

                    SceneManager.LoadScene("Nivel1");
                }
                else
                {
                    bool decision = EditorUtility.DisplayDialog(
                        "Error carga",
                        "No existe ninguna partida guardada en el servidor", 
                        "Ok"
                    );
                }
                
                resultado.Close();
                
            }else
            {
                bool decision = EditorUtility.DisplayDialog(
                    "Error guardado",
                    "Necesitas iniciar sesion para poder guardar en la nube", 
                    "Ok"
                );
            }

        } else {
            bool decision = EditorUtility.DisplayDialog(
                "Error de conexion",
                "No se ha podido realizar la conexion a la base de datos, pruebe mas tarde", 
                "Ok"
            );
        }
    }

    public void registrar() {
        bool realizar = true;
        if (!conectado) {
            realizar = conectarBaseDatos();
        }

        if (realizar) {
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
                resultado.Close();

                MySqlCommand cmd2 = conexion.CreateCommand();
                cmd2.CommandText = "SELECT * FROM `usuarios` WHERE `nombre` = '"+nombreRegistro.text+"' AND `contrasena` = '"+contrasenaRegistro.text+"'";
                MySqlDataReader resultado2 = cmd2.ExecuteReader();

                resultado2.Read();
            
                PlayerPrefs.SetInt("idUsuario", resultado2.GetInt32(0));
                PlayerPrefs.SetString("usuario", nombreRegistro.text);
                PlayerPrefs.Save();

                resultado2.Close();
                
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
        else {
            bool decision = EditorUtility.DisplayDialog(
                "Error de conexion",
                "No se ha podido realizar la conexion a la base de datos, pruebe mas tarde", 
                "Ok"
            );
        }
        
    }

    public void guardarNube()
    {
        
        bool realizar = true;
        if (!conectado) {
            realizar = conectarBaseDatos();
        }

        if (realizar) {
            GetComponent<SaveGame>().guardarPartida();

            if (PlayerPrefs.HasKey("usuario"))
            {
                
                MySqlCommand cmd1 = conexion.CreateCommand();
                cmd1.CommandText = "SELECT * FROM `partida` WHERE `fk_usuario` = '"+PlayerPrefs.GetInt("idUsuario")+"'";
                MySqlDataReader resultado1 = cmd1.ExecuteReader();

                if (!resultado1.HasRows)
                {
                    resultado1.Close();
                    MySqlCommand cmd = conexion.CreateCommand();
                
                    cmd.CommandText = "INSERT INTO `partida` (`id`,`nivel`, `puntuacion`, `posicionX`, `posicionY`, `fk_usuario`, `vida`, `pistola`) VALUES (NULL ,'"+PlayerPrefs.GetString("nivel")+"', '"+PlayerPrefs.GetInt("puntos")+"', '"+PlayerPrefs.GetFloat("playerX")+"', '"+PlayerPrefs.GetFloat("playerY")+"', '"+PlayerPrefs.GetInt("idUsuario")+"', '"+PlayerPrefs.GetInt("vida")+"', '"+PlayerPrefs.GetInt("gun")+"')";
                    MySqlDataReader resultado = cmd.ExecuteReader();
                    resultado.Close();
                }
                else
                {
                    resultado1.Close();
                    MySqlCommand cmd = conexion.CreateCommand();
                
                    cmd.CommandText = "UPDATE `partida` SET `nivel` = '"+PlayerPrefs.GetString("nivel")+"', `puntuacion` = '"+PlayerPrefs.GetInt("puntos")+"', `posicionX` = '"+PlayerPrefs.GetFloat("playerX")+"', `posicionY` = '"+PlayerPrefs.GetFloat("playerY")+"', `fk_usuario` = '"+PlayerPrefs.GetInt("idUsuario")+"', `vida` = '"+PlayerPrefs.GetInt("vida")+"', `pistola` = '"+PlayerPrefs.GetInt("gun")+"' WHERE `fk_usuario` = '"+PlayerPrefs.GetInt("idUsuario")+"'";
                    MySqlDataReader resultado = cmd.ExecuteReader();
                    resultado.Close();
                }
                
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
        else {
            bool decision = EditorUtility.DisplayDialog(
                "Error en la base de datos",
                "No se ha podido realizar la conexion con la base de datos, pruebe mas tarde", 
                "Ok"
            );
        }
    }

    public void iniciarSesion()
    {
        
        bool realizar = true;
        if (!conectado) {
            realizar = conectarBaseDatos();
        }

        if (realizar) {
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
                PlayerPrefs.Save();

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
        else {
            bool decision = EditorUtility.DisplayDialog(
                "Error en la base de datos",
                "No se ha podido realizar la conexion con la base de datos, pruebe mas tarde", 
                "Ok"
            );
        }
    }

    private bool conectarBaseDatos() {
        conexion = new MySqlConnection(datosConexion);
        try {
            conexion.Open();
            conectado = true;
            return true;
        }
        catch (Exception error) {
            Debug.Log("Conexion incorrecta a base de datos: " + error);
            conectado = false;
            return false;
        }
    }
}
