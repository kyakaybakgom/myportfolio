using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private PlayerData playerData;

    private void Start()
    {
        playerData = transform.GetComponentInParent<PlayerController>().playerData;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == Constants.EnemyTag)
        {

        }
    }
}
