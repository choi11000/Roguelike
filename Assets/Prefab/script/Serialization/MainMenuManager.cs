using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private GameData gameData;

    public Text uicoins;

    private void Awake()
    {
        gameData = SaveSystem.Load();
        RefreshUI();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RefreshUI()
    {
        uicoins.text = gameData.totalCoins.ToString();
    }
}
