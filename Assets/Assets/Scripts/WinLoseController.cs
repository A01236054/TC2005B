using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseController : MonoBehaviour
{
    public TimeSimulation TimeSimulation;

    public void BackToMenu()
    {
        
        SceneManager.LoadScene("MenuScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
