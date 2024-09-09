using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour {

    int speed = 40;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float amtMove = speed * Time.deltaTime;
        transform.Translate(Vector3.up * amtMove);

        if (transform.position.y < -30)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            other.SendMessage("DestroySelf");
            Destroy(gameObject);
        }
    }

    public void CallDestroy()
    {
        Destroy(gameObject);
    }
}
