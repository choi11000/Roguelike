using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Basic_Auto_Shot : MonoBehaviour
{
    //총알을 생성후 Target에게 날아갈 변수
    public Transform target;
    public Mage mage;

    //발사될 총알 오브젝트
    public GameObject bullet;
    float timer;
    public float waitingTime = 1f;
    private EnemySpawn enemySpawn;
    private float dist;
    [SerializeField]
    public float SpellDamage = 50f;
    private int FBall_Num = 360;
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

        InvokeRepeating("getClosestEnemy", 0, 1.0f);


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
        var bl = new List<Transform>();

        for (int i = 0; i < 360; i += FBall_Num)
        {
            //총알 생성
            var temp = Instantiate(bullet);

            //2초후 삭제
            Destroy(temp, 2f);

            //총알 생성 위치를 캐릭터 좌표로 한다.
            temp.transform.position = mage.transform.position;

            //?초후에 Target에게 날아갈 오브젝트 수록
            bl.Add(temp.transform);

            //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입한다.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
        //총알을 Target 방향으로 이동시킨다.
        StartCoroutine(BulletToTarget(bl));
    }

    IEnumerator BulletToTarget(List<Transform> bl)
    {


        yield return new WaitForSeconds(0.1f);



        for (int i = 0; i < bl.Count; i++)
        {

            //현재 총알의 위치에서 플레이의 위치의 벡터값을 뻴셈하여 방향을 구함
            var target_dir = target.transform.position - bl[i].position;

            //x,y의 값을 조합하여 Z방향 값으로 변형함. -> ~도 단위로 변형
            var angle = Mathf.Atan2(target_dir.y, target_dir.x) * Mathf.Rad2Deg;

            //Target 방향으로 이동
            bl[i].rotation = Quaternion.Euler(0, 0, angle);
        }

        //데이터 해제
        bl.Clear();
    }

    private IEnumerator SearchTarget()
    {
        while (true)
        {
            float closestDistSqr = Mathf.Infinity;

            for (int i = 0; i < enemySpawn.EnemyList.Count; ++i)
            {
                float distance = Vector3.Distance(enemySpawn.EnemyList[i].transform.position, transform.position);

                if (distance <= 15.0f && distance <= closestDistSqr)
                {
                    closestDistSqr = distance;
                    target = enemySpawn.EnemyList[i].transform;
                }
            }
        }
        yield return new WaitForSeconds(0.1f);
    }
    private GameObject FindNearestObjectByTag()
    {
        // 탐색할 오브젝트 목록을 List 로 저장합니다.
        var objects = GameObject.FindGameObjectsWithTag("Enemy").ToList();

        // LINQ 메소드를 이용해 가장 가까운 적을 찾습니다.
        var neareastObject = objects
            .OrderBy(obj =>
            {
                return Vector3.Distance(transform.position, obj.transform.position);
            })
        .FirstOrDefault();

        return neareastObject;
    }

    void getClosestEnemy()
    {
        //비용이 큼 - 특정 태그의 오브젝트를 모두 찾음
        GameObject[] taggedEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistSqr = Mathf.Infinity;//infinity 
        Transform closestEnemy = null;
        foreach (GameObject taggedEnemy in taggedEnemys)
        {
            Vector3 objectPos = taggedEnemy.transform.position;
            dist = (objectPos - transform.position).sqrMagnitude;
            // 특정 거리 안으로 들어올때
            if (dist < 20.0f)
            {
                // 그 거리가 제곱한 최단 거리보다 작으면
                if (dist < closestDistSqr)
                {
                    closestDistSqr = dist;
                    closestEnemy = taggedEnemy.transform;
                }
            }
        }
        target = closestEnemy;
    }

}
