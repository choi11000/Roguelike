﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFader : MonoBehaviour
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
        else if (regionName.color.a != 0)
        {
            regionName.CrossFadeAlpha(0, 0.5f, false);
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
