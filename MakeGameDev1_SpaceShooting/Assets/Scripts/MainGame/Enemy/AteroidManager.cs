using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AteroidManager : MonoBehaviour {

    public Transform expParticle;
    public AudioClip expSound;

    int speed;
    int rotX;
    int rotY;
    int rotZ;

    // Use this for initialization
    void Start()
    {
        InitAsteroid();
        //DestroySelf();
    }

    // Update is called once per frame
    void Update ()
    {
        float amtMove = speed * Time.deltaTime;

        transform.Rotate(new Vector3(rotX, rotY, rotZ) * Time.deltaTime);
        transform.Translate(Vector3.down * amtMove, Space.World);

        if (transform.position.y < -30)
        {
            Destroy(gameObject);
        }
	}

    void InitAsteroid()
    {
        speed = Random.Range(20, 50);

        rotX = Random.Range(-90,90);
        rotY = Random.Range(-90, 90);
        rotZ = Random.Range(-90, 90);

        float x = Random.Range(-40, 40);
        transform.position = new Vector3(x, 30, 37);
    }

    //destroy call
    public void CallDestroy()
    {
        DestroySelf();
    }

    void DestroySelf()
    {
        Instantiate(expParticle, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(expSound, transform.position);

        Destroy(gameObject);
    }
}
