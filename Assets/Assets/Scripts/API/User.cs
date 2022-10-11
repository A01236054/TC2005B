// Script API que devuelve la clase Usuario en formato de Json

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class User
{
    public string username = "admin";
    public int helmetNum = 0;
    public int ordinaryNum = 0;
    public int generalNum = 0;
    public int totalNum = 0;
    public int coins = 0;
    public int wins = 0;
    public int numAchUnlocked = 0;
    public bool[] achievements = { false, false, false, false, false, false };
    public bool[] weapons = { false, false, false, false};

    public static User CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<User>(jsonString);
    }
}
