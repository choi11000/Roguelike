using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public Text pointsText;
    public Text pointsText2;
    // Start is called before the first frame update
    int point;

    private void Start()
    {
        point = GameManager.instance.point;
        Setup(point);
    }
    public void Setup(int score)
    {
        int coin = score / 10;
        GameManager.instance.coins += coin;
        GameManager.instance.GameOver();
        pointsText.text = score.ToString() + " POINTS";
        pointsText2.text = coin.ToString() + " COINS";
        //gameObject.SetActive(true);
    }
}
