using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin_shot : MonoBehaviour {

    //회전되는 스피드이다.
    public float rot_Speed=10;
    //총알이 발사될 위치이다.
    public Transform pos;

    //총알을 생성
    public Mage mage;
    //발사될 총알 오브젝트
    public GameObject bullet;
    float timer;
    public float waitingTime = 0.5f;
    [SerializeField]
    public float SpellDamage = 5f;
    public GameData gameData;

    private void Awake()
    {
        gameData = SaveSystem.Load();
        if (gameData.abilitiesUnlocked[0])
        {
            SpellDamage += 2f;

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
        //회전
        transform.Rotate(Vector3.forward * rot_Speed * 100 * Time.deltaTime);

        //총알 생성
        GameObject temp = Instantiate(bullet);

        //2초후 자동 삭제
        Destroy(temp, 2f);

        //총알 생성 위치
        temp.transform.position = mage.transform.position;

        //총알의 방향을 오브젝트의 방향으로 한다.
        //->해당 오브젝트가 오브젝트가 360도 회전하고 있으므로, Rotation이 방향이 됨.
        temp.transform.rotation = transform.rotation;
    }

    
}
