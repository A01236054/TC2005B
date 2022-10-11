// Script para cargar el jugador en la p�gina a trav�s de API

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadSecondPlayer : MonoBehaviour
{
    private string APIurl = "http://localhost:5000/getEnemy";
    public TimeSimulation TimeSimulation;

    public void OnClick()
    {
        StartCoroutine(Load());
    }
    void Start()
    {
    }
    IEnumerator Load()
    {
        yield return new WaitForSeconds(0.1f);

        var json = "{\"username\":\" " + TimeSimulation.user.username + "\"}";

        //string jsonUsername = JsonUtility.ToJson(TimeSimulation.user);
        string fullURL = APIurl;
        //Debug.Log(json);
        using (UnityWebRequest web = UnityWebRequest.Put(fullURL, json))
        {
            web.method = UnityWebRequest.kHttpVerbPUT;
            //web.useHttpContinue = false;
            //web.uploadHandler = (UploadHandler)new UploadHandlerRaw(body);
            //web.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            web.SetRequestHeader("Content-type", "application/json");
            web.SetRequestHeader("Accept", "application/json");
            yield return web.SendWebRequest();

            if (web.result == UnityWebRequest.Result.ConnectionError || web.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(web.error);
            }
            else
            {
                TimeSimulation.user2 = User.CreateFromJSON(web.downloadHandler.text);
                Debug.Log("Datos del USUARIO2 cargados correctamente: " + TimeSimulation.user2);
            }
        }
        StopCoroutine(Load());
    }
}
