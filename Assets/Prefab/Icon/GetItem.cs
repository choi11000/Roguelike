using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    //public Transform obj;
    public GameObject Item;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        //Item.transform.position = obj.position + new Vector3(0, 1, 0);
        Destroy(Item, 1f);
    }
}
