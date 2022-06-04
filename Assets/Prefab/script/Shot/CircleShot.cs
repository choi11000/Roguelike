using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShot : MonoBehaviour
{

    //총알을 생성
    public Mage mage;
    //발사될 총알 오브젝트
    public GameObject bullet;
    float timer;
    public float waitingTime = 2f;
    [SerializeField]
    public float SpellDamage = 5f;
    public int Circle_Num = 60;
    public GameData gameData;

    private void Awake()
    {
        gameData = SaveSystem.Load();
        if (gameData.abilitiesUnlocked[0])
        {
            SpellDamage += 2f;

        }
        if (gameData.abilitiesUnlocked[1])
        {
            waitingTime -= 0.01f;
        }
    }
    void Start()
    {
        timer = 0.0f;
        

    }

    private void Update()
    {
        timer += Time.deltaTime;


        if (timer > waitingTime)
        {
            if (!mage.isDie)
            {
                shot();
            }

            timer = 0;
        }

    }

    void shot()
    {
        //Target방향으로 발사될 오브젝트 수록
        

        for (int i = 0; i < 360; i += Circle_Num)
        {
            //총알 생성
            var temp = Instantiate(bullet);

            //2초후 삭제
            Destroy(temp, 2f);

            //총알 생성 위치를 캐릭터 좌표로 한다.
            temp.transform.position = mage.transform.position;


            //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입한다.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
        //총알을 Target 방향으로 이동시킨다.
        
    }

}
