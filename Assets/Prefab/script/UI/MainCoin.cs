using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCoin : MonoBehaviour
{
    // Start is called before the first frame update
    public Text CoinText;
    // Start is called before the first frame update
    int point, coin;
    RunningTime RunningTime;

    private void Start()
    {
        point = GameManager.instance.point;
        coin = point / 10;
        Setup(coin);
    }
    public void Setup(int score)
    {
        
        CoinText.text = coin.ToString();
        //gameObject.SetActive(true);
    }
}
