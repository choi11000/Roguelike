using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class ItemToSpawn
{
    public GameObject item;
    public float spawnRate;
    public float minSpawnProb, maxSpawnProb;

}

public class LootSystem : MonoBehaviour
{
    public ItemToSpawn[] itemToSpawn;
    Mage mage;

    Spin_shot Spin;
    Auto_Shot Auto;
    CircleShot Circle;
    //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        mage = GameObject.Find("Mage").GetComponent<Mage>();
        Spin = GameObject.Find("Mage").transform.Find("Tornado").GetComponent<Spin_shot>();
        Auto = GameObject.Find("Mage").transform.Find("FireBall").GetComponent<Auto_Shot>();
        Circle = GameObject.Find("Mage").transform.Find("LightningBall").GetComponent<CircleShot>();
        for (int i = 0; i < itemToSpawn.Length; i++)
        {
            if (i == 0)
            {
                itemToSpawn[i].minSpawnProb = 0;
                itemToSpawn[i].maxSpawnProb = itemToSpawn[i].spawnRate - 1;
            }
            else
            {
                itemToSpawn[i].minSpawnProb = itemToSpawn[i - 1].maxSpawnProb + 1;
                itemToSpawn[i].maxSpawnProb = itemToSpawn[i].minSpawnProb + itemToSpawn[i].spawnRate - 1;
            }
        }
        
    }

    // Update is called once per frame
    private void Spawnner()
    {
        float randomNum = Random.Range(0, 100);

        for(int i = 0; i < itemToSpawn.Length; i++)
        {
            if(randomNum>=itemToSpawn[i].minSpawnProb && randomNum <= itemToSpawn[i].maxSpawnProb)
            {
                Debug.Log(randomNum + " " + itemToSpawn[i].item.name);
                
                
                //itemToSpawn[i].item.transform.position = mage.transform.position + new Vector3(0, 1, 0);
                Instantiate(itemToSpawn[i].item, this.transform.position, Quaternion.identity);


                //spell power up
                string spellname = itemToSpawn[i].item.name;

                switch (spellname)
                {
                    case "F_Ball":
                        Auto.SpellDamage += 2f;
                        if (Auto.FBall_Num > 30)
                        {
                            Auto.FBall_Num -= 15;
                        }
                        else
                        {
                            Auto.FBall_Num = 30;
                        }

                        if (Auto.waitingTime > 0.5f)
                        {
                            Auto.waitingTime -= 0.1f;
                        }
                        else
                        {
                            Auto.waitingTime = 0.5f;
                        }
                        break;
                    case "LightningBall":
                        Circle.SpellDamage += 2f;

                        if (Circle.Circle_Num > 30)
                        {
                            Circle.Circle_Num -= 5;
                        }
                        else
                        {
                            Circle.Circle_Num = 30;
                        }

                        if (Circle.waitingTime > 0.5f)
                        {
                            Circle.waitingTime -= 0.2f;
                        }
                        else
                        {
                            Circle.waitingTime = 0.5f;
                        }
                        break;
                    case "Tornado":
                        Spin.SpellDamage += 2f;
                        if (Spin.waitingTime > 0.1f)
                        {
                            Spin.waitingTime -= 0.05f;
                        }
                        else
                        {
                            Spin.waitingTime = 0.1f;
                        }
                        break;
                }
                /*
                if (itemToSpawn[i].item.name == "F_Ball")
                {
                    Auto.SpellDamage += 2f;
                    if (Auto.FBall_Num > 30)
                    {
                        Auto.FBall_Num -= 15;
                    }
                    else
                    {
                        Auto.FBall_Num = 30;
                    }

                    if (Auto.waitingTime > 0.5f)
                    {
                        Auto.waitingTime -= 0.1f;
                    }
                    else
                    {
                        Auto.waitingTime = 0.5f;
                    }
                    

                }
                else if (itemToSpawn[i].item.name == "LightningBall")
                {
                    Circle.SpellDamage += 2f;
                    
                    if (Circle.Circle_Num > 30)
                    {
                        Circle.Circle_Num -= 5;
                    }
                    else
                    {
                        Circle.Circle_Num = 30;
                    }

                    if (Circle.waitingTime < 0.5f)
                    {
                        Circle.waitingTime -= 0.2f;
                    }
                    else
                    {
                        Circle.waitingTime = 0.5f;
                    }
                }
                else if (itemToSpawn[i].item.name == "Tornado")
                {
                    Spin.SpellDamage += 2f;
                    if (Spin.waitingTime > 0.1f)
                    {
                        Spin.waitingTime -= 0.05f;
                    }
                    else
                    {
                        Spin.waitingTime = 0.1f;
                    }
                }
                */
                break;


            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Spawnner();
            Destroy(this.gameObject);
        }
    }

}
