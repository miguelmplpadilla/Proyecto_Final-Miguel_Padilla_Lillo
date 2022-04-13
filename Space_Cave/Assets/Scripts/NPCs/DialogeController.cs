using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class DialogeController : MonoBehaviour {

    public string idioma = "ES";
    public List<string> getTextoDialogos(TextAsset dialogos, string ablante)
    {
        List<string> textoDialogo = new List<string>();
        string fs = dialogos.text;
        string[] fLines = Regex.Split ( fs, "\n|\r|\r\n" );

        for (int i = 0; i < fLines.Length; i++)
        {

            string valueLine = fLines[i];
            string[] values = Regex.Split(valueLine, ",");
            if (values[0].Equals(ablante))
            {
                if (idioma.Equals("ES")) {
                    textoDialogo.Add(values[1]);
                } else if (idioma.Equals("EN")) {
                    textoDialogo.Add(values[2]);
                }
            }
        }
        
        return textoDialogo;
    }
}
