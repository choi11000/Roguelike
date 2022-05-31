using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colletion1 : MonoBehaviour
{
    public void ChangeSceneBtn() // 메인 콜렉션 화면 이동
    {
        SceneManager.LoadScene("Colletion");
    }

    public void Mission1() // 10분 생존시 이동, 조건은 아직 미구현이라 바로 들어가짐
    {
        SceneManager.LoadScene("Mission101");
    }

    public void Mission2() // 20분 생존시 이동, 조건은 아직 미구현이라 바로 들어가짐
    {
        SceneManager.LoadScene("Mission102");
    }

    public void Mission3() // 30분 생존시 이동, 조건은 아직 미구현이라 바로 들어가짐
    {
        SceneManager.LoadScene("Mission103");
    }
}
