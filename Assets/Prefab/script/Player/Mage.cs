using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    [SerializeField] public float m_speed = 1.0f;

    

    public Animator m_animator;
    public Rigidbody2D m_body2d;
    BoxCollider2D boxCollider;
    SpriteRenderer sr;
    private int m_facingDirection = 1;
    private int m_currentAttack = 0;
    private float m_timeSinceAttack = 0.0f;
    private float m_delayToIdle = 0.0f;
    public bool isHit;
    public bool isDie = true;
    public GameData gameData;
    [SerializeField] private bl_Joystick Joystick;
    //[SerializeField] private JoyStickMovement Joystick;
    //public GameObject monster;

    private void Awake()
    {
        gameData = SaveSystem.Load();
        if (gameData.abilitiesUnlocked[3])
        {
            m_speed += 0.01f;
        }
    }
    // Use this for initialization
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Increase timer that controls attack combo
        //m_timeSinceAttack += Time.deltaTime;

        // -- Handle input and movement --
        //float inputX = Input.GetAxis("Horizontal");
        //float inputY = Input.GetAxis("Vertical");
        // Swap direction of sprite depending on walk direction

        if(PlayerHealth.health > 0f)
        {
            PlayerAnim();
        }
        
        //Set AirSpeed in animator
        //m_animator.SetFloat("AirSpeedY", m_body2d.velocity.y);

        //Death
        /*
        if (Input.GetKeyDown("e"))
        {
            //m_animator.SetBool("isDie", isDie);
            m_animator.SetTrigger("Die");
        }

        
        //Hurt
        else if (Input.GetKeyDown("q"))
            m_animator.SetTrigger("hurt");

        //Attack
        else if (Input.GetMouseButtonDown(0) && m_timeSinceAttack > 0.25f)
        {
            m_currentAttack = 1;
            m_animator.SetTrigger("Attack" + m_currentAttack);

            // Reset timer
            m_timeSinceAttack = 0.0f;
        }
        
        */

    }
    /*
    private void FixedUpdate()
    {
        if(IsPlayingAnim("hurt") || isHit)
        {
            m_body2d.velocity *= 0.98f;
            return;
        }
    }
    */
    // Animation Events
    // Called in end of roll animation.

    public bool IsPlayingAnim(string AnimName)
    {
        if (m_animator.GetCurrentAnimatorStateInfo(0).IsName(AnimName))
        {
            return true;
        }
        return false;
    }

    public void MyAnimSetTrigger(string AnimName)
    {
        if (!IsPlayingAnim(AnimName))
        {
            m_animator.SetTrigger(AnimName);
        }
    }

    void PlayerAnim()
    {
        //float inputX = Input.GetAxis("Horizontal");
        //float inputY = Input.GetAxis("Vertical");
        float inputX = Joystick.Horizontal;
        float inputY = Joystick.Vertical;

        if (!IsPlayingAnim("hurt") && !IsPlayingAnim("Die"))
        {
            //Run
            if (Mathf.Abs(inputX) > Mathf.Epsilon)
            {
                // Reset timer
                m_delayToIdle = 0.05f;
                MyAnimSetTrigger("Run");
            }
            else if (Mathf.Abs(inputY) > Mathf.Epsilon)
            {
                // Reset timer
                m_delayToIdle = 0.05f;
                MyAnimSetTrigger("Run");
            }
            //Idle
            else
            {
                // Prevents flickering transitions to idle
                m_delayToIdle -= Time.deltaTime;
                if (m_delayToIdle < 0)
                    MyAnimSetTrigger("Idle");
            }
            if (inputX > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                m_facingDirection = 1;
            }

            else if (inputX < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                m_facingDirection = -1;
            }

            if (inputY > 0)
            {
                GetComponent<SpriteRenderer>().flipY = false;
                m_facingDirection = 1;
            }

            // Move
            m_body2d.velocity = new Vector2(inputX * m_speed, inputY * m_speed);

            //Vector2 translate = (new Vector2(h, v) * Time.deltaTime) * m_speed/5;
            //transform.Translate(translate);
        }
        
    }    

}
