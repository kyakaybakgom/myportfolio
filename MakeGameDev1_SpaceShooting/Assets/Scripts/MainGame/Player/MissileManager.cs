using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManager : MonoBehaviour {

    int speed = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float amtMove = speed * Time.deltaTime;
        transform.Translate(Vector3.up * amtMove);

        if(transform.position.y > 30)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Asteroid")
        {
            other.SendMessage("DestroySelf");

            DataPath.Instance.gamePoint += 100;
            DataPath.Instance.shootAsteroid++;

            Destroy(gameObject);
        }

        if(other.transform.tag == "Enemy0")
        {
            other.SendMessage("DestroySelf");

            DataPath.Instance.gamePoint += 150;
            DataPath.Instance.shootEnemy++;

            Destroy(gameObject);
        }
    }
    
}
