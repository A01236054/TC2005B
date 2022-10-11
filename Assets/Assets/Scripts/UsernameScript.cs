using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameScript : MonoBehaviour
{
    public TimeSimulation TimeSimulation;
    public Text textUsuario;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textUsuario.text = "Bienvenido "+ TimeSimulation.user.username;
    }
}
