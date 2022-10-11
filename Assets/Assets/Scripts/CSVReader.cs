using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CSVReader : MonoBehaviour
{
    public TextAsset textAssetData;
    public Text textCSVHistoria;
    public int totalArrays;
    static public CSVReader instanceCSVReader; // Permite acceder a la clase en otro script

    [System.Serializable]
    public class Historia
    {
        public string issueKey;
        public string status;
        public string priority;
        public string severity;
        public string projectName;
        public string projectLead;
        public string issueType;
        public string created;
        public string customField;
        public string summary;
        public string assignee;
        public string customFieldInitiative;
        public string updated;
        public string duration;
    }

    [System.Serializable]
    public class HistoriaList
    {
        //public Historia[] historia { get; set; }
        public Historia[] historia;
    }

    public HistoriaList myHistoriaList = new HistoriaList();

    // Lee el archivo CSV que está separado en comas y extrae cada historia
    public void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None); // Separa los datos por campos 
        totalArrays = (data.Length - 14) / 14; // Total de arreglos es igual al tamaño total de los campos de todas las historias, menos las del título (14 campos) dividido entre 14 (14 columnas) = 249 arreglos (ya se excluye títulos)
        myHistoriaList.historia = new Historia[totalArrays]; // total de arreglos (3500 elementos o campos totales incluyendo títulos, 3486 excluyendo títulos) 
        textCSVHistoria.text = (data.Length - 14) + " campos sin incluir títulos"; // Texto que escribe estos elementos
        for (int index = 0; index < totalArrays; index++) // De 0 a 248
        {
            // 14 del row para saltarse el primer renglón, + n para acceder al campo de columna requerida
            myHistoriaList.historia[index] = new Historia();
            myHistoriaList.historia[index].issueKey = data[14 * (index + 1)];
            // myHistoriaList.historia[index].status = "Open"; // Al principio abre todas las historias
            myHistoriaList.historia[index].status = data[14 * (index + 1) + 1];
            myHistoriaList.historia[index].priority = data[14 * (index + 1) + 2];
            myHistoriaList.historia[index].severity = data[14 * (index + 1) + 3];
            myHistoriaList.historia[index].projectName = data[14 * (index + 1) + 4];
            myHistoriaList.historia[index].projectLead = data[14 * (index + 1) + 5];
            myHistoriaList.historia[index].issueType = data[14 * (index + 1) + 6];
            myHistoriaList.historia[index].created = data[14 * (index + 1) + 7];
            myHistoriaList.historia[index].customField = data[14 * (index + 1) + 8];
            myHistoriaList.historia[index].summary = data[14 * (index + 1) + 9];
            myHistoriaList.historia[index].assignee = data[14 * (index + 1) + 10];
            myHistoriaList.historia[index].customFieldInitiative = data[14 * (index + 1) + 11];
            myHistoriaList.historia[index].updated = data[14 * (index + 1) + 12];
            myHistoriaList.historia[index].duration = data[14 * (index + 1) + 13];
        }
        // Llama a función para simular tiempo
        StartCoroutine(TimeSimulation.instanceTimeSimulation.TimeSimulator());
    }

    private void Awake()
    {
        // Permite acceder a la clase a través de la instancia de objeto
        if (instanceCSVReader == null)
        {
            instanceCSVReader = this; 
        }
        else
        {
            Destroy(this.gameObject); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        textCSVHistoria.text = "";
        ReadCSV();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
