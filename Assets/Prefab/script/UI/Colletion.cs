using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colletion : MonoBehaviour
{

    public void ChangeSceneBtn() // 메인화면 이동
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Stage1() // 스테이지1 화면 이동
    {
        SceneManager.LoadScene("Colletion1");
    }
}
