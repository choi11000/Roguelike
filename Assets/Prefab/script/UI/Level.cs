using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static int level = 1;
    [SerializeField]
    Text LevelText;


    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        LevelText.text = "Level : " + level;
        //GameManager.instance.level += 1;
        
    }
}
