using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Peleas : MonoBehaviour
{
    public TimeSimulation TimeSimulation;
    public LoadPlayer LoadPlayer;
    public LoadSecondPlayer LoadSecondPlayer;
    public Exit Exit;
    public float h1;
    public float o1;
    public float g1;
    public bool w1u1;
    public bool w2u1;
    public bool w3u1;
    public bool w4u1;
    public int u1s1;
    public int u1s2;
    public int u1s3;
    public int userPoints1 = 0;
    public float h2;
    public float o2;
    public float g2;
    public bool w1u2;
    public bool w2u2;
    public bool w3u2;
    public bool w4u2;
    public int u2s1;
    public int u2s2;
    public int u2s3;
    public int userPoints2 = 0;
    int[] op1 = {1,2,3};
    int[] op2 = {3,2,1};
    public int time;
    public User user;
    // 1 = ordinary
    // 2 = helmet
    // 3 = general

    public void igualarUsers()
    {
        h1 = TimeSimulation.user.helmetNum;
        o1 = TimeSimulation.user.ordinaryNum;
        g1 = TimeSimulation.user.generalNum;
        w1u1 = TimeSimulation.user.weapons[0];
        w2u1 = TimeSimulation.user.weapons[1];
        w3u1 = TimeSimulation.user.weapons[2];
        w4u1 = TimeSimulation.user.weapons[3];
        h2 = TimeSimulation.user2.helmetNum;
        o2 = TimeSimulation.user2.ordinaryNum;
        g2 = TimeSimulation.user2.generalNum;
        w1u2 = TimeSimulation.user2.weapons[0];
        w2u2 = TimeSimulation.user2.weapons[1];
        w3u2 = TimeSimulation.user2.weapons[2];
        w4u2 = TimeSimulation.user2.weapons[3];
    }

    public void acomodarRandom()
    {

        u1s1 = op1[0];
        u1s2 = op1[1];
        u1s3 = op1[2];


        u2s1 = op2[0];
        u2s2 = op2[1];
        u2s3 = op2[2];
    }

    public float verificarArmas(float soldado,bool a1, bool a2, bool a3, bool a4){
        if(a1){
            soldado = soldado*1.15f;
        }
        else if(a2){
            soldado = soldado*1.20f;
        }
        else if(a3){
            soldado = soldado*1.25f;
        }
        else if(a4){
            soldado = soldado*1.30f;
        }
        return soldado;
    }

    public void desventaja(float soladado)
    {
        soladado = soladado*0.6f;
    }

    public void verificarCasos()
    {
        //caso ordinary
        if(u1s1 == 1){
            if(u2s1 == 1){
                o1 = verificarArmas(o1,w1u1,w2u1,w3u1,w4u1);
                o2 = verificarArmas(o2,w1u2,w2u2,w3u2,w4u2);
                if(o1 > o2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s1 == 2){
                o1 = verificarArmas(o1,w1u1,w2u1,w3u1,w4u1);
                h2 = verificarArmas(h2,w1u2,w2u2,w3u2,w4u2);
                desventaja(h2);
                if(o1 > h2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s1 == 3){
                o1 = verificarArmas(o1,w1u1,w2u1,w3u1,w4u1);
                g2 = verificarArmas(g2,w1u2,w2u2,w3u2,w4u2);
                desventaja(o1);
                if(o1 > g2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
        }
        // caso helmet
        if(u1s1 == 2){
            if(u2s1 == 1){
                h1 = verificarArmas(h1,w1u1,w2u1,w3u1,w4u1);
                o2 = verificarArmas(o2,w1u2,w2u2,w3u2,w4u2);
                desventaja(h1);
                if(h1 > o2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s1 == 2){
                h1 = verificarArmas(h1,w1u1,w2u1,w3u1,w4u1);
                h2 = verificarArmas(h2,w1u2,w2u2,w3u2,w4u2);
                
                if(h1 > h2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s1 == 3){
                h1 = verificarArmas(h1,w1u1,w2u1,w3u1,w4u1);
                g2 = verificarArmas(g2,w1u2,w2u2,w3u2,w4u2);
                desventaja(g2);
                if(h1 > g2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
        }
        // caso general
        if(u1s1 == 3){
            if(u2s1 == 1){
                g1 = verificarArmas(g1,w1u1,w2u1,w3u1,w4u1);
                o2 = verificarArmas(o2,w1u2,w2u2,w3u2,w4u2);
                desventaja(o2);
                if(g1 > o2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s1 == 2){
                g1 = verificarArmas(g1,w1u1,w2u1,w3u1,w4u1);
                h2 = verificarArmas(h2,w1u2,w2u2,w3u2,w4u2);
                desventaja(g1);
                if(g1 > h2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s1 == 3){
                g1 = verificarArmas(g1,w1u1,w2u1,w3u1,w4u1);
                g2 = verificarArmas(g2,w1u2,w2u2,w3u2,w4u2);
                if(g1 > g2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
        }

        /////////////////////////////////////////////////

        //caso ordinary
        if(u1s2 == 1){
            if(u2s2 == 1){
                o1 = verificarArmas(o1,w1u1,w2u1,w3u1,w4u1);
                o2 = verificarArmas(o2,w1u2,w2u2,w3u2,w4u2);
                if(o1 > o2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s2 == 2){
                o1 = verificarArmas(o1,w1u1,w2u1,w3u1,w4u1);
                h2 = verificarArmas(h2,w1u2,w2u2,w3u2,w4u2);
                desventaja(h2);
                if(o1 > h2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s2 == 3){
                o1 = verificarArmas(o1,w1u1,w2u1,w3u1,w4u1);
                g2 = verificarArmas(g2,w1u2,w2u2,w3u2,w4u2);
                desventaja(o1);
                if(o1 > g2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
        }
        // caso helmet
        if(u1s2 == 2){
            if(u2s2 == 1){
                h1 = verificarArmas(h1,w1u1,w2u1,w3u1,w4u1);
                o2 = verificarArmas(o2,w1u2,w2u2,w3u2,w4u2);
                desventaja(h1);
                if(h1 > o2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s2 == 2){
                h1 = verificarArmas(h1,w1u1,w2u1,w3u1,w4u1);
                h2 = verificarArmas(h2,w1u2,w2u2,w3u2,w4u2);
                
                if(h1 > h2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s2 == 3){
                h1 = verificarArmas(h1,w1u1,w2u1,w3u1,w4u1);
                g2 = verificarArmas(g2,w1u2,w2u2,w3u2,w4u2);
                desventaja(g2);
                if(h1 > g2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
        }
        // caso general
        if(u1s2 == 3){
            if(u2s2 == 1){
                g1 = verificarArmas(g1,w1u1,w2u1,w3u1,w4u1);
                o2 = verificarArmas(o2,w1u2,w2u2,w3u2,w4u2);
                desventaja(o2);
                if(g1 > o2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s2 == 2){
                g1 = verificarArmas(g1,w1u1,w2u1,w3u1,w4u1);
                h2 = verificarArmas(h2,w1u2,w2u2,w3u2,w4u2);
                desventaja(g1);
                if(g1 > h2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s2 == 3){
                g1 = verificarArmas(g1,w1u1,w2u1,w3u1,w4u1);
                g2 = verificarArmas(g2,w1u2,w2u2,w3u2,w4u2);
                if(g1 > g2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
        }

        //////////////////////////////////////////////////

        //caso ordinary
        if(u1s3 == 1){
            if(u2s3 == 1){
                o1 = verificarArmas(o1,w1u1,w2u1,w3u1,w4u1);
                o2 = verificarArmas(o2,w1u2,w2u2,w3u2,w4u2);
                if(o1 > o2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s3 == 2){
                o1 = verificarArmas(o1,w1u1,w2u1,w3u1,w4u1);
                h2 = verificarArmas(h2,w1u2,w2u2,w3u2,w4u2);
                desventaja(h2);
                if(o1 > h2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s3 == 3){
                o1 = verificarArmas(o1,w1u1,w2u1,w3u1,w4u1);
                g2 = verificarArmas(g2,w1u2,w2u2,w3u2,w4u2);
                desventaja(o1);
                if(o1 > g2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
        }
        // caso helmet
        if(u1s3 == 2){
            if(u2s3 == 1){
                h1 = verificarArmas(h1,w1u1,w2u1,w3u1,w4u1);
                o2 = verificarArmas(o2,w1u2,w2u2,w3u2,w4u2);
                desventaja(h1);
                if(h1 > o2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s3 == 2){
                h1 = verificarArmas(h1,w1u1,w2u1,w3u1,w4u1);
                h2 = verificarArmas(h2,w1u2,w2u2,w3u2,w4u2);
                
                if(h1 > h2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s3 == 3){
                h1 = verificarArmas(h1,w1u1,w2u1,w3u1,w4u1);
                g2 = verificarArmas(g2,w1u2,w2u2,w3u2,w4u2);
                desventaja(g2);
                if(h1 > g2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
        }
        // caso general
        if(u1s3 == 3){
            if(u2s3 == 1){
                g1 = verificarArmas(g1,w1u1,w2u1,w3u1,w4u1);
                o2 = verificarArmas(o2,w1u2,w2u2,w3u2,w4u2);
                desventaja(o2);
                if(g1 > o2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s3 == 2){
                g1 = verificarArmas(g1,w1u1,w2u1,w3u1,w4u1);
                h2 = verificarArmas(h2,w1u2,w2u2,w3u2,w4u2);
                desventaja(g1);
                if(g1 > h2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
            if(u2s3 == 3){
                g1 = verificarArmas(g1,w1u1,w2u1,w3u1,w4u1);
                g2 = verificarArmas(g2,w1u2,w2u2,w3u2,w4u2);
                if(g1 > g2){
                    userPoints1++;
                }
                else{
                    userPoints2++;
                }
            }
        }
    }

    public void verificarUP()
    {
        if(userPoints1 >= userPoints2)
        {
            Debug.Log("Ganaste");
            if (TimeSimulation.user.totalNum < TimeSimulation.user2.totalNum) // Logro ganar en desventaja numérica inicial
            {
                TimeSimulation.user.achievements[5] = true;
            }
            TimeSimulation.user.wins++;
            Exit.OnClick2();
            Debug.Log("User points1 : " + userPoints1);
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            Debug.Log("Perdiste");
            Debug.Log("User points2 : " + userPoints2);
            SceneManager.LoadScene("LoseScene");
        }
    }

    // Asegura que se carguen bien los datos de la base de datos y vuelve a igualar
    IEnumerator MatchTime(){
        LoadPlayer.OnClick();
        LoadSecondPlayer.OnClick();
        yield return new WaitForSeconds(0.5f);
        StopCoroutine(MatchTime());
        igualarUsers();
    }

    // funcion para iniciar el timer
    public void StartTimer(){
        StartCoroutine(MatchTime());
    }

    public void startWar()
    {
        StartTimer(); // Vuelve a validar que se carguen los usuarios de base de datos
        acomodarRandom();
        verificarCasos();
        verificarUP();
    }


    // Start is called before the first frame update
    void Start()
    {
        LoadPlayer.Load();
        igualarUsers();
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("User points1 : " + userPoints1);
        //Debug.Log("User points2 : " + userPoints2);
    }
}
