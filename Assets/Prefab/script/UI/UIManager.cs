using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    Mage mage;

    private void Start()
    {
        mage = GameObject.Find("Mage").GetComponent<Mage>();
    }

    private void Update()
    {
        if (mage.isDie)
        {
            Invoke("EnableGameOverMenu", 2f);
        }
    }

    private void Invoke(string v)
    {
        throw new NotImplementedException();
    }

    public void EnableGameOverMenu()
    {
        SceneManager.LoadScene(2);
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
