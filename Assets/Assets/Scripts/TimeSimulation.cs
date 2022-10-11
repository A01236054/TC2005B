using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using UnityEngine.UI;

public class TimeSimulation : MonoBehaviour
{
    private float time;
    static public TimeSimulation instanceTimeSimulation; // Permite acceder a la clase en otro script
    public Text textCoins;
    public Text textHistoriasCompleted;
    public LoadPlayer LoadPlayer;
    public Exit Exit;
    private int timeSimulated;
    private int CicloHistoria = 1;
    public User user;
    public User user2;
    

    public IEnumerator TimeSimulator()
    {
        for (int index = 0;  index < CSVReader.instanceCSVReader.totalArrays; index++) { // Valida que el �ndice no se salga de los arreglos totales, de 0 a 248 para 249 historias
            if (CSVReader.instanceCSVReader.myHistoriaList.historia[index].status == "Closed") // Valida que la historia est� abierta
            {
                index++; // Si est� cerrada, se pasa a la siguiente
            }
            else {
                if(index % 2 == 0)
                {
                    Exit.OnClick();
                }
                time = float.Parse(CSVReader.instanceCSVReader.myHistoriaList.historia[index].duration, CultureInfo.InvariantCulture.NumberFormat); // De string a float la duraci�n de la historia
                timeSimulated = 365; // Cantidad de veces que pasa de r�pido el tiempo en la simulaci�n, 1 segundo = 365 d�as = 1 a�o10
                yield return new WaitForSeconds(time/timeSimulated); // Se espera cierto tiempo
                CSVReader.instanceCSVReader.myHistoriaList.historia[index].status = "Closed"; // Lo marca como completado
                user.coins++; // Asigna a la clase de player, el valor de monedas para la API
                //Debug.Log("Monedas:"+user.coins);
                textCoins.text = ":" + user.coins.ToString(); // Actualiza el texto que indica monedas actuales
                textHistoriasCompleted.text += CSVReader.instanceCSVReader.myHistoriaList.historia[index].issueKey + "\n"; // Texto que indica el ID de la historia completada
                index++; // Se va al siguiente arreglo (registro).
            }
        }
        // Una vez terminadas todas las historias
        for(int i=0;  i < CSVReader.instanceCSVReader.totalArrays; i++) // Para cada historia
        {
            CSVReader.instanceCSVReader.myHistoriaList.historia[i].status = "Open"; // Pone su estatus a abierto para comenzar de nuevo
        }
        CicloHistoria++; // N�mero de ciclos en los que se encuentra completando toda la base de datos, empezando desde 1
        textHistoriasCompleted.text = "Ciclo " + CicloHistoria + "\n\n"; // Reinicia texto
        //StopAllCoroutines(); // Para la corutina
        StartCoroutine(TimeSimulator()); // Itera de nuevo
    }

    private void Awake()
    {
        user = new User();
        user2 = new User();
        
        // Permite acceder a la clase a trav�s de la instancia de objeto
        if (instanceTimeSimulation == null)
        {
            instanceTimeSimulation = this; 
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadPlayer.OnClick();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
