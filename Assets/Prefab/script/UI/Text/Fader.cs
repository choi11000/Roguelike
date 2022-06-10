using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public Text regionName;
    private float fadeTime;
    private bool fadingIn;

    // Start is called before the first frame update
    void Start()
    {
        regionName.CrossFadeAlpha(0, 0.0f, false);
        fadeTime = 0;
        fadingIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingIn)
        {
            FadeIn();
        }
        else if(regionName.color.a != 0)
        {
            regionName.CrossFadeAlpha(0, 0.5f, false);
        }
    }

    void FadeIn()
    {
        regionName.CrossFadeAlpha(1, 0.5f, false);
        fadeTime += Time.deltaTime;
        if(regionName.color.a == 1 && fadeTime > 1.5f)
        {
            fadingIn = false;
            fadeTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fire_Icon")
        {
            fadingIn = true;
            regionName.text = "파이어 볼 " + "데미지 +2 " + "쿨타임 -10% ";
        }
        else if(collision.tag == "Lightning_Icon")
        {
            fadingIn = true;
            regionName.text = "라이트닝 볼 " + "데미지 +2 " + "쿨타임 -10%";
        }
        else if(collision.tag == "Tornado_Icon")
        {
            fadingIn = true;
            regionName.text = "토네이도 " + "데미지 +2 " + "쿨타임 -10%";
        }
    }
}
