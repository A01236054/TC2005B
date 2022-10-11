// Script para cargar el jugador en la página a través de API

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadPlayer : MonoBehaviour
{
    private string APIurl = "http://localhost:5000/users/";
    private string playerID;
    public TimeSimulation TimeSimulation;
    public void OnClick()
    {
        StartCoroutine(Load());
    }
        void Awake()
        {
        //Debug.Log("App.absURL = " + Application.absoluteURL);
        int question = Application.absoluteURL.IndexOf("?");
        if (question != -1)
        {
            string param = Application.absoluteURL.Split('?')[1];
            int equal = param.IndexOf("=");
            if (equal != -1)
            {
                playerID = param.Split("="[0])[1];
                //Debug.Log("playerID = " + playerID);
            }
        }
        else
        {
            playerID = "admin"; // Usuario por defecto en caso de error, tiene que coincidir con base de datos
        }
        StartCoroutine(Load());
        }

    public IEnumerator Load()
    {
        yield return new WaitForSeconds(0.03f);
        string fullURL = APIurl + playerID; // Carga la url con el playerID
        Debug.Log("URL para cargar usuarios = " + fullURL);
        UnityWebRequest web = UnityWebRequest.Get(fullURL);
        web.useHttpContinue = false;
        yield return web.SendWebRequest();
        if (web.result == UnityWebRequest.Result.ConnectionError || web.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error API: " + web.error);
        }
        else
        {
            Debug.Log(web.downloadHandler.text);
            TimeSimulation.user = User.CreateFromJSON(web.downloadHandler.text);
            //Debug.Log("Datos cargados correctamente del usuario : " + TimeSimulation.user.username);
        }
    }
}
