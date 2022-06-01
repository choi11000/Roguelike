using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int totalCoins;
    public int levels;

    public bool[] abilitiesUnlocked;

    public int Settings;

    public GameData()
    {
        totalCoins = 0;
        levels = 1;
        abilitiesUnlocked = new bool[5];
        //abilitiesUnlocked[0] = false;
        Settings = 1;
    }
}
