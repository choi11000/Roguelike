using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningTime : MonoBehaviour
{
    float sec;
    public int min;
    Gameover gameover;
    [SerializeField]
    Text TimerText;

    private void Update()
    {
        Timer();
    }

    void Timer()
    {
        sec += Time.deltaTime;
        TimerText.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);

        if ((int)sec > 59)
        {
            sec = 0;
            min++;
            Enemy.EnemyPU(min);
            GameManager.instance.point += 1;
        }
    }
}
