using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody2D e_body2d;
    protected BoxCollider2D boxCollider;
    public GameObject hitBox;

    Transform target;
    public Transform rayCast;
    public LayerMask rayCastMask;
    public float rayCastLength;
    public float attackDistance;    // minimum distance for attack
    public float health;
    private EnemySpawn enemySpawn;
    Spin_shot Spin;
    Auto_Shot Auto;
    CircleShot Circle;
    Basic_Auto_Shot Basic;
    public GameObject itemDropManager;


    public float timer;             // timer for cooldown between attacks
    int movementFlag = 0; //0:idle 1:left 2:right
    [SerializeField] public static float maxHealth = 10f;
    [SerializeField][Range(1f, 4f)] float moveSpeed = 3f;
    [SerializeField][Range(0f, 2f)] float contactDistance = 1f;
    [SerializeField] public static float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private float GetExp = 10f;
    private float canAttack;
    //private RaycastHit2D hit;
    private GameObject tar;
    private Animator anim;
    private float distance; // store the distance between enemy and player
    private float distanceY;
    private bool attackMode;
    //private bool inRange;   // check if enemy is cooling after attack
    private bool cooling;   // Enemy is cooling after attack
    private float intTimer;

    //bool follow;
    public bool isHit = false;


    public void Setup(EnemySpawn enemySpawn)
    {
        this.enemySpawn = enemySpawn;
    }
    protected void Awake()
    {
        e_body2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        intTimer = timer;
        anim = GetComponent<Animator>();

        StartCoroutine(ResetCollider());

    }
    IEnumerator ResetCollider()
    {
        while (true)
        {
            yield return null;
            if (!hitBox.activeInHierarchy)
            {
                yield return new WaitForSeconds(0.5f);
                hitBox.SetActive(true);
                isHit = false;
            }
        }
    }
    private void Update()
    {
        if (!isHit)
        {
            if (contactDistance >= 0 && contactDistance <= 1)
            {
                EnemyLogic();
            }

            else
            {
                anim.SetBool("Run", false);
                StopAttack();
            }
        }


    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        Vector2 pos = gameObject.transform.position;
        Vector2 pos2 = target.transform.position;
        if (distance > attackDistance)
        {
            Move();
            StopAttack();

        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }
    public void Move()
    {
        string dist = "";

        anim.SetBool("Run", true);
        if (Vector2.Distance(transform.position, target.position) > contactDistance)
        {
            Vector3 playerPos = target.transform.position;

            if (playerPos.x < transform.position.x)
                dist = "Left";
            else if (playerPos.x > transform.position.x)
                dist = "Right";
        }
        else
        {
            if (movementFlag == 1)
                dist = "Left";
            else if (movementFlag == 2)
                dist = "Right";
        }

        if (dist == "Left")
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(-2, 2, 1);
        }
        else if (dist == "Right")
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(2, 2, 1);
        };


    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        anim.SetBool("Run", false);
        anim.SetBool("Attack", true);
    }
    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }
    private void Start()
    {
        health = maxHealth;
        e_body2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Basic = GameObject.Find("Mage").transform.Find("BasicAttack").GetComponent<Basic_Auto_Shot>();
        Spin = GameObject.Find("Mage").transform.Find("Tornado").GetComponent<Spin_shot>();
        Auto = GameObject.Find("Mage").transform.Find("FireBall").GetComponent<Auto_Shot>();
        Circle = GameObject.Find("Mage").transform.Find("LightningBall").GetComponent<CircleShot>();

    }


    public void TakeDamage(float dmg)
    {
        health -= dmg;
        isHit = true;

        //Debug.Log("Enemy Health: " + health);


        if (health >= 0) //Hit
        {
            e_body2d.velocity = Vector2.zero;
        }
        else
        {
            itemDropManager.GetComponent<ItemDropManager>().Spawnner();
            Destroy(gameObject);
            PlayerExp.exp += GetExp;
        }
        hitBox.SetActive(false);
    }
    /*
    private void FixedUpdate()
    {
        Move();
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Auto"))
        {
            anim.SetTrigger("Hit");
            TakeDamage(Auto.SpellDamage);
        }
        else if (collision.transform.CompareTag("Circle"))
        {
            anim.SetTrigger("Hit");
            TakeDamage(Circle.SpellDamage);
        }
        else if (collision.transform.CompareTag("Spin"))
        {
            anim.SetTrigger("Hit");
            TakeDamage(Spin.SpellDamage);
        }
        else if (collision.transform.CompareTag("Basic"))
        {
            anim.SetTrigger("Hit");
            TakeDamage(Basic.SpellDamage);

        }

    }
    public static void EnemyPU(int min)
    {
        int sw = min % 2;
        switch (sw)
        {
            case 0:
                attackDamage += 1;
                break;
            case 1:
                maxHealth += 2;
                break;
        }
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }



}
