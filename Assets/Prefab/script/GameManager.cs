using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameData gameData;
    public int point = 0;
    //public int level = 1;
    public int coins = 0;
    public bool[] abilities = new bool[5];

    // Start is called before the first frame update
    private void Awake()
    {
        
        gameData = SaveSystem.Load();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
        for(int i = 0; i < 5; i++)
        {
            abilities[i] = !gameData.abilitiesUnlocked[i];
        }
    }

    public void GameOver()
    {
        gameData.totalCoins += coins;
        SaveSystem.Save(gameData);
    }
}
