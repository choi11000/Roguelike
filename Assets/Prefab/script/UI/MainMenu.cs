using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // 게임 시작
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Upgrade() // 업그레이드 화면 이동
    {
        SceneManager.LoadScene("Upgrade");
    }

    public void Colletion() // 콜렉션 화면 이동
    {
        SceneManager.LoadScene("Colletion");
    }

    public void HowToPlay() // 게임방법 화면 이동
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Options() // 만든사람 화면 이동(표기는 OPTION이나 미처 변경을 하지 못함)
    {
        SceneManager.LoadScene("Option");
    }

}
