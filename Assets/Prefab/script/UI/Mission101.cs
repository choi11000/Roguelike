using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mission101 : MonoBehaviour
{
    public void ChangeSceneBtn() // 미션1 타이틀 이동
    {
        SceneManager.LoadScene("Colletion1");
    }
}
