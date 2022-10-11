using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModifyArmy : MonoBehaviour
{
    public TimeSimulation TimeSimulation;
    public Text CantHelmet;
    public Text CantGeneral;
    public Text CantOrdinary;
    public Text CantArmy;
    public Text CantCoins;
    public Text BotonA1;
    public int ValorA1;
    public Text BotonA2;
    public int ValorA2;
    public Text BotonA3;
    public int ValorA3;
    public Text BotonA4;
    public int ValorA4;
    public SFXManager sfxManager;
    public Exit Exit;

    public void Back()
    {
        Exit.OnClick();
        SceneManager.LoadScene("ModifyA");
    }

    public void GoToMenu()
    {

        Exit.OnClick();
        SceneManager.LoadScene("MenuScene");
    }

    public void GoToWeapons()
    {
        Exit.OnClick();
        SceneManager.LoadScene("Weapons");
    }

    public void SumaHelmet()
    {
        //Debug.Log("Actuales coins: " + TimeSimulation.user.coins);
        if(TimeSimulation.user.coins > 0)
        {
        TimeSimulation.user.helmetNum++;
        CantHelmet.text =":" + TimeSimulation.user.helmetNum.ToString();
        TimeSimulation.user.totalNum++;
        CantArmy.text = ":" + TimeSimulation.user.totalNum.ToString();
        TimeSimulation.user.coins--;
        CantCoins.text = ":" + TimeSimulation.user.coins.ToString();
        }

    }

    public void SumaGeneral()
    {
        if(TimeSimulation.user.coins >= 0)
        {
        TimeSimulation.user.generalNum++;
        CantGeneral.text =":" + TimeSimulation.user.generalNum.ToString();
        TimeSimulation.user.totalNum++;
        CantArmy.text = ":" + TimeSimulation.user.totalNum.ToString();
        TimeSimulation.user.coins--;
        CantCoins.text = ":" + TimeSimulation.user.coins.ToString();
        }
    }

    public void SumaOrdinary()
    {
        if(TimeSimulation.user.coins >= 0)
        {
        TimeSimulation.user.ordinaryNum++;
        CantOrdinary.text =":" + TimeSimulation.user.ordinaryNum.ToString();
        TimeSimulation.user.totalNum++;
        CantArmy.text = ":" + TimeSimulation.user.totalNum.ToString();
        TimeSimulation.user.coins--;
        CantCoins.text = ":" + TimeSimulation.user.coins.ToString();
        }
    }

    public void RestaHelmet()
    {
        if(TimeSimulation.user.coins >= 0 && TimeSimulation.user.helmetNum > 0)
        {
        TimeSimulation.user.helmetNum--;
        CantHelmet.text =":" + TimeSimulation.user.helmetNum.ToString();
        TimeSimulation.user.totalNum--;
        CantArmy.text = ":" + TimeSimulation.user.totalNum.ToString();
        TimeSimulation.user.coins++;
        CantCoins.text = ":" + TimeSimulation.user.coins.ToString();
        }

    }
    public void RestaGeneral()
    {
        if(TimeSimulation.user.coins >= 0 && TimeSimulation.user.generalNum > 0)
        {
        TimeSimulation.user.generalNum--;
        CantGeneral.text =":" + TimeSimulation.user.generalNum.ToString();
        TimeSimulation.user.totalNum--;
        CantArmy.text = ":" + TimeSimulation.user.totalNum.ToString();
        TimeSimulation.user.coins++;
        CantCoins.text = ":" + TimeSimulation.user.coins.ToString();
        }
    }
    public void RestaOrdinary()
    {
        if(TimeSimulation.user.coins >= 0 && TimeSimulation.user.ordinaryNum > 0)
        {
        TimeSimulation.user.ordinaryNum--;
        CantOrdinary.text =":" + TimeSimulation.user.ordinaryNum.ToString();
        TimeSimulation.user.totalNum--;
        CantArmy.text = ":" + TimeSimulation.user.totalNum.ToString();
        TimeSimulation.user.coins++;
        CantCoins.text = ":" + TimeSimulation.user.coins.ToString();
        }
    }

    public void BuyArma1()
    {
    
        if(ValorA1 < TimeSimulation.user.coins && !TimeSimulation.user.weapons[0])
        {
            TimeSimulation.user.weapons[0] = true;
            BotonA1.text = "Sell";
            TimeSimulation.user.coins -= ValorA1;
        }
        else if(TimeSimulation.user.weapons[0])
        {
            TimeSimulation.user.weapons[0] = false;
            BotonA1.text = "Buy";
            TimeSimulation.user.coins += ValorA1;
        }
    }
    public void BuyArma2()
    {

        if(ValorA2 < TimeSimulation.user.coins && !TimeSimulation.user.weapons[1])
        {
            TimeSimulation.user.weapons[1] = true;
            BotonA2.text = "Sell";
            TimeSimulation.user.coins -= ValorA2;
        }
        else if(TimeSimulation.user.weapons[1])
        {
            TimeSimulation.user.weapons[1] = false;
            BotonA2.text = "Buy";
            TimeSimulation.user.coins += ValorA2;
        }
    }
    public void BuyArma3()
    {

        if(ValorA3 < TimeSimulation.user.coins && !TimeSimulation.user.weapons[2])
        {
            TimeSimulation.user.weapons[2] = true;
            BotonA3.text = "Sell";
            TimeSimulation.user.coins -= ValorA3;
        }
        else if(TimeSimulation.user.weapons[2])
        {
            TimeSimulation.user.weapons[2] = false;
            BotonA3.text = "Buy";
            TimeSimulation.user.coins += ValorA3;
        }
    }
    public void BuyArma4()
    {

        if(ValorA4 < TimeSimulation.user.coins && !TimeSimulation.user.weapons[3])
        {
            TimeSimulation.user.weapons[3] = true;
            BotonA4.text = "Sell";
            TimeSimulation.user.coins -= ValorA4;
        }
        else if(TimeSimulation.user.weapons[3])
        {
            TimeSimulation.user.weapons[3] = false;
            BotonA4.text = "Buy";
            TimeSimulation.user.coins += ValorA4;
        }
    }


    private void IniciarBotones()
    {
        if(TimeSimulation.user.weapons[0])
        {
            BotonA1.text = "Sell";
        }
        else
        {
            BotonA1.text = "Buy";
        }

        if(TimeSimulation.user.weapons[1])
        {
            BotonA2.text = "Sell";
        }
        else
        {
            BotonA2.text = "Buy";
        }

        if(TimeSimulation.user.weapons[2])
        {
            BotonA3.text = "Sell";
        }
        else
        {
            BotonA3.text = "Buy";
        }

        if(TimeSimulation.user.weapons[3])
        {
            BotonA4.text = "Sell";
        }
        else
        {
            BotonA4.text = "Buy";
        }
    }

    private void CallButtonsConstantly()
    {
        CantOrdinary.text = ":" + TimeSimulation.user.ordinaryNum.ToString();
        CantGeneral.text = ":" + TimeSimulation.user.generalNum.ToString();
        CantHelmet.text = ":" + TimeSimulation.user.helmetNum.ToString();
        CantArmy.text = ":" + TimeSimulation.user.totalNum.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        IniciarBotones(); // Constantemente porque al inicio no funciona
        CallButtonsConstantly();
    }
}
