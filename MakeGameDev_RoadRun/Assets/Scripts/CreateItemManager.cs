using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItemManager : MonoBehaviour {

    public Vector3[] spawnItemVec;

    public GameObject Item_Star;

    private void Start()
    {
        Invoke("createItemFunc", Random.Range(3.0f, 5.0f));
    }
    
    void createItemFunc()
    {
        int randomVec = Random.Range(0, spawnItemVec.Length);

        Instantiate(Item_Star, spawnItemVec[randomVec], Quaternion.Euler(new Vector3(-90, 0, 0)));

        if (DataManager.Instance.GameAct.Equals(true))
        {
            Invoke("createItemFunc", Random.Range(3.0f, 5.0f));
        }
    }
}
