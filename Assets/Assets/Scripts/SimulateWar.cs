using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimulateWar : MonoBehaviour
{
    public int time;
    public bool win = true;
    public GameObject StartButton;
    public int numSoldado;
    public GameObject W1;
    public GameObject W2;
    public GameObject W3;
    public GameObject W4;
    public GameObject W1_2;
    public GameObject W2_2;
    public GameObject W3_2;
    public GameObject W4_2;
    public Text cantH;
    public Text cantO;
    public Text cantG;
    public Text cantH_2;
    public Text cantO_2;
    public Text cantG_2;
    public Text nombre1;    
    public Text nombre2;
    public TimeSimulation TimeSimulation;
    public User user;
    

    public void Armas()
   {
        if(TimeSimulation.user.weapons[0])
        {
            W1.SetActive(true);
        }
    } 

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
        StartButton.SetActive(true);
    }


    public void IniciarGuerra()
    {
        StartButton.SetActive(false);
        
        StartTimer();
    }

    // funcion para actuivar la escena final
    public void AcitveEndScene(){
        if(win)
        {
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            SceneManager.LoadScene("LoseScene");
        }
    }


    IEnumerator MatchTime(){
        yield return new WaitForSeconds(0.1f);

        //LoadPlayer.Load();
        //Debug.Log("Entró a base de datosss");
        StopCoroutine(MatchTime());
        AcitveEndScene();
        
    }

    // funcion para iniciar el timer
    public void StartTimer(){
        StartCoroutine(MatchTime());
    }

    // Start is called before the first frame update
    void Start()
    {
        W1.SetActive(TimeSimulation.user.weapons[0]);
    }

    // Update is called once per frame
    void Update()
    {
        W1.SetActive(TimeSimulation.user.weapons[0]);
        W2.SetActive(TimeSimulation.user.weapons[1]);
        W3.SetActive(TimeSimulation.user.weapons[2]);
        W4.SetActive(TimeSimulation.user.weapons[3]);
        W1_2.SetActive(TimeSimulation.user2.weapons[0]);
        W2_2.SetActive(TimeSimulation.user2.weapons[1]);
        W3_2.SetActive(TimeSimulation.user2.weapons[2]);
        W4_2.SetActive(TimeSimulation.user2.weapons[3]);
        cantG.text = ":" + TimeSimulation.user.generalNum;
        cantH.text = ":" + TimeSimulation.user.helmetNum;
        cantO.text = ":" + TimeSimulation.user.ordinaryNum;
        cantG_2.text = ":" + TimeSimulation.user2.generalNum;
        cantH_2.text = ":" + TimeSimulation.user2.helmetNum;
        cantO_2.text = ":" + TimeSimulation.user2.ordinaryNum;
        nombre1.text = TimeSimulation.user.username;
        nombre2.text = TimeSimulation.user2.username;
    }
}
