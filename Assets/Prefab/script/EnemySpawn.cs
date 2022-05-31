using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public bool enableSpawn = false;
    public GameObject Enemy;
    private List<Enemy> enemyList;
    
    public List<Enemy> EnemyList => enemyList;

    private void Awake()
    {
        enemyList = new List<Enemy>();

        StartCoroutine("SpawnEnemy");
    }
    void SpawnEnemy()
    {
        float randomX = Random.Range(-7f, 7f); 
        float randomY = Random.Range(-7f, 7f);
        
        if (enableSpawn)
        {
            GameObject clone = (GameObject)Instantiate(Enemy, new Vector3(randomX, randomY, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성
            Enemy enemy = clone.GetComponent<Enemy>();

            enemyList.Add(enemy);

        }
    }
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2, 1f); //2초후 부터, SpawnEnemy함수를 1초마다 반복해서 실행 
        
    }
    void Update()
    {

    }
    public void DestroyEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);

        Destroy(enemy.gameObject);
    }
}
