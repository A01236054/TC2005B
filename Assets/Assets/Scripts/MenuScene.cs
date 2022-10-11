using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScene : MonoBehaviour
{

    public void modifayArmy()
    {
        SceneManager.LoadScene("ModifyA");
    }

    public void simulateWar()
    {
        SceneManager.LoadScene("SimulateWar");
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
