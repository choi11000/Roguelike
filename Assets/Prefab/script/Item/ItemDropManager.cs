using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemDropManager : MonoBehaviour
{
    public ItemToSpawn[] itemToSpawn;

    public Enemy enemy;
    //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
        
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
    public void Spawnner()
    {
        float randomNum = Random.Range(0, 100);

        for (int i = 0; i < itemToSpawn.Length; i++)
        {
            if (randomNum >= itemToSpawn[i].minSpawnProb && randomNum <= itemToSpawn[i].maxSpawnProb)
            {
                Debug.Log(randomNum + " " + itemToSpawn[i].item.name);


                //itemToSpawn[i].item.transform.position = mage.transform.position + new Vector3(0, 1, 0);
                Instantiate(itemToSpawn[i].item, transform.position, Quaternion.identity);
                //spell power up
                
                //Destroy(itemToSpawn[i].item, 2f);
                break;


            }
        }

    }



}
