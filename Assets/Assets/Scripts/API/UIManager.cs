// Script que inicializa y cambia UI del juego

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Elementos de la interfaz

    public static User player;
    static public UIManager instance;

    // Start is called before the first frame update
    void Start()
    {
        player = new User();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        //txtUsername.text = "username";
        //txtCoins.text = User.coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //txtUsername.text = User.username;
        //txtCoins.text = player.coins.ToString();
    }

    public void ButtonClick()
    {
    }
}
