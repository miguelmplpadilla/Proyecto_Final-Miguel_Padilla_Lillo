using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarNivel : MonoBehaviour
{
    
    void Start()
    {
        string levelToLoad = PlayerPrefs.GetString("siguenteEscena");

        StartCoroutine(MakeTheLoad(levelToLoad));
    }

    IEnumerator MakeTheLoad(string level)
    {
        //yield return new WaitForSeconds(1f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        while (operation.isDone == false)
        {
            yield return null;
        }
    }
}
