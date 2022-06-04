using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Move : MonoBehaviour {

    public float speed = 10f;
    PlayerExp Exp;
    public GameData gameData;
    private void Awake()
    {
        gameData = SaveSystem.Load();
        if (gameData.abilitiesUnlocked[4])
        {
            speed += 1;
        }
    }
    private void Start()
    {
        //생성으로부터 2초 후 삭제
        Destroy(gameObject, 2f);
        Exp = GameObject.Find("ExpFill").GetComponent<PlayerExp>();
    }

    private void Update()
    {
        //두번째 파라미터에 Space.World를 해줌으로써 Rotation에 의한 방향 오류를 수정함
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
        SpeedUp();
    }

    void SpeedUp()
    {
        if(Exp.ExpBar.fillAmount == 1)
        {
            speed += 0.01f;
        }
    }
}
