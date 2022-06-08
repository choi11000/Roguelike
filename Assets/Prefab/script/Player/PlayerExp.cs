using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public Text regionName;
    private float fadeTime;
    private bool fadingIn;
    public static float exp = 0f;
    [SerializeField] public static float MaxExp = 100f;
    public Image ExpBar;
    public GameObject auto, spin, circle;
    Spin_shot Spin;
    Auto_Shot Auto;
    CircleShot Circle;
    Basic_Auto_Shot Basic;
    Mage mage;
    // Start is called before the first frame update

    private void Start()
    {
        ExpBar = GetComponent<Image>();
        exp = 0f;
        mage = GameObject.Find("Mage").GetComponent<Mage>();
        Basic = GameObject.Find("BasicAttack").GetComponent<Basic_Auto_Shot>();
        auto = GameObject.Find("Mage").transform.Find("FireBall").gameObject;
        spin = GameObject.Find("Mage").transform.Find("Tornado").gameObject;
        circle = GameObject.Find("Mage").transform.Find("LightningBall").gameObject;
        Spin = GameObject.Find("Mage").transform.Find("Tornado").GetComponent<Spin_shot>();
        Auto = GameObject.Find("Mage").transform.Find("FireBall").GetComponent<Auto_Shot>();
        Circle = GameObject.Find("Mage").transform.Find("LightningBall").GetComponent<CircleShot>();
        regionName.CrossFadeAlpha(0, 0.0f, false);
        fadeTime = 0;
        fadingIn = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (exp >= MaxExp)
        {
            exp = 0;
            MaxExp += 50;
            Level.level += 1;
            LevelUpdate();
        }
        if (fadingIn)
        {
            FadeIn();
        }
        else if (regionName.color.a != 0)
        {
            regionName.CrossFadeAlpha(0, 0.5f, false);
        }
        ExpBar.fillAmount = exp / MaxExp;
    }

    public void LevelUpdate()
    {
        //level effect

        switch (Level.level)
        {
            case 1:
                break;
            case 2:
                auto.gameObject.SetActive(true);
                fadingIn = true;
                regionName.text = "파이어볼 획득";

                break;
            case 3:
                spin.gameObject.SetActive(true);
                fadingIn = true;
                regionName.text = "토네이도 획득";

                break;
            case 4:
                circle.gameObject.SetActive(true);
                fadingIn = true;
                regionName.text = "라이트닝볼 획득";

                break;
            default:

                Basic.SpellDamage += 2f;
                Auto.waitingTime -= 0.01f;
                Circle.waitingTime -= 0.01f;
                Basic.waitingTime -= 0.01f;
                mage.m_speed += 0.02f;
                break;

        }
    }
    void FadeIn()
    {
        regionName.CrossFadeAlpha(1, 0.5f, false);
        fadeTime += Time.deltaTime;
        if (regionName.color.a == 1 && fadeTime > 1.5f)
        {

            fadingIn = false;
            fadeTime = 0;
        }
    }
}

