// Script API

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Exit : MonoBehaviour
{
    public TimeSimulation TimeSimulation;

    // Lo activa al dar click en botón, llama a función
    public void OnClick()
    {
        StartCoroutine(Upload()); // Manda a la API todos los datos de la clase player
    }

    // Más información en función Upload2
    public void OnClick2()
    {
        StartCoroutine(Upload2()); // Manda a la API todos los datos de la clase player
    }

    IEnumerator Upload()
    {
        // VALIDAR LOGROS
        int suma = 0;
        for(int i=0; i<3; i++){
            if (TimeSimulation.user.weapons[i] == true) {
                suma++;
            }
        }
        if(suma >= 1)
        {
            TimeSimulation.user.achievements[4] = true;
        }
        else
        {
            TimeSimulation.user.achievements[4] = false;
        }
        if(TimeSimulation.user.totalNum >= 100)
        {
            TimeSimulation.user.achievements[0] = true;
        }
        else
        {
            TimeSimulation.user.achievements[0] = false;
        }
        if (TimeSimulation.user.totalNum >= 1000)
        {
            TimeSimulation.user.achievements[1] = true;
        }
        else
        {
            TimeSimulation.user.achievements[1] = false;
        }
        if (TimeSimulation.user.wins >= 1)
        {
            TimeSimulation.user.achievements[2] = true;
        }
        else
        {
            TimeSimulation.user.achievements[2] = false;
        }
        if (TimeSimulation.user.wins >= 3)
        {
            TimeSimulation.user.achievements[3] = true;
        }
        else
        {
            TimeSimulation.user.achievements[3] = false;
        }
        // Manda parámetro numAchUnlocked
        int achievementsSuma = 0;
        for (int i=0; i < TimeSimulation.user.achievements.Length; i++)
        {
            if (TimeSimulation.user.achievements[i] == true)
            {
                achievementsSuma++;
            }
        }

        TimeSimulation.user.numAchUnlocked = achievementsSuma;
        yield return new WaitForSeconds(0.29f); // Se espera para no sobreescribir al principio
        string APIurl = "http://localhost:5000/users/";
        string fullURL = APIurl + TimeSimulation.user.username;
        //string fullURL = APIurl + "admin";
        string jsonData = JsonUtility.ToJson(TimeSimulation.user);
        //byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonData);
        //UploadHandlerRaw upHandler = new UploadHandlerRaw(data);
        Debug.Log("JSON Usuario1 para subir datos-> " + jsonData);
        using (UnityWebRequest web = UnityWebRequest.Put(fullURL, jsonData))
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
                StopCoroutine(Upload());
            }
            else
            {
                Debug.Log("Se mandó correctamente los datos del usuario1");
                StopCoroutine(Upload());
            }
        }
    }

    // Por alguna razón, después del Simulate War y ganar (Script Peleas.cs), no envía datos del usuario para marcar wins,
    // específicamente por el comando yield return de la corutina, por lo que se crea este otro script, por lo que se elimino aquí el yield return
    IEnumerator Upload2()
    {
        // VALIDAR LOGROS
        int suma = 0;
        for (int i = 0; i < 3; i++)
        {
            if (TimeSimulation.user.weapons[i] == true)
            {
                suma++;
            }
        }
        if (suma >= 1)
        {
            TimeSimulation.user.achievements[4] = true;
        }
        else
        {
            TimeSimulation.user.achievements[4] = false;
        }
        if (TimeSimulation.user.totalNum >= 100)
        {
            TimeSimulation.user.achievements[0] = true;
        }
        else
        {
            TimeSimulation.user.achievements[0] = false;
        }
        if (TimeSimulation.user.totalNum >= 1000)
        {
            TimeSimulation.user.achievements[1] = true;
        }
        else
        {
            TimeSimulation.user.achievements[1] = false;
        }
        if (TimeSimulation.user.wins >= 1)
        {
            TimeSimulation.user.achievements[2] = true;
        }
        else
        {
            TimeSimulation.user.achievements[2] = false;
        }
        if (TimeSimulation.user.wins >= 3)
        {
            TimeSimulation.user.achievements[3] = true;
        }
        else
        {
            TimeSimulation.user.achievements[3] = false;
        }
        // Manda parámetro numAchUnlocked
        int achievementsSuma = 0;
        for (int i = 0; i < TimeSimulation.user.achievements.Length; i++)
        {
            if (TimeSimulation.user.achievements[i] == true)
            {
                achievementsSuma++;
            }
        }

        TimeSimulation.user.numAchUnlocked = achievementsSuma;
        string APIurl = "http://localhost:5000/users/";
        string fullURL = APIurl + TimeSimulation.user.username;
        //string fullURL = APIurl + "admin";
        Debug.Log("URL a mandar datos del usuario1: " + fullURL);
        string jsonData = JsonUtility.ToJson(TimeSimulation.user);
        //byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonData);
        //UploadHandlerRaw upHandler = new UploadHandlerRaw(data);
        Debug.Log("JSON Usuario1 para subir datos-> " + jsonData);
        using (UnityWebRequest web = UnityWebRequest.Put(fullURL, jsonData))
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
                StopCoroutine(Upload2());
            }
            else
            {
                Debug.Log("Se mandó correctamente los datos del usuario1");
                StopCoroutine(Upload2());
            }
        }
    }
}

