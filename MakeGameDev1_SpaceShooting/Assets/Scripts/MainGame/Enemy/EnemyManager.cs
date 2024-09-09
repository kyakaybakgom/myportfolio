using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    float speed = 10;

    public GameObject respawnMissile;
    public GameObject enemyMissile;

    bool actBool = true;

    public Transform expParticle;
    public AudioClip expSound;

    // Use this for initialization
    void Start ()
    {
        InitEnemy();
        StartCoroutine("makeMissile");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(actBool)
        {
            float amtMove = speed * Time.deltaTime;
            this.transform.position = new Vector3(transform.position.x, transform.position.y - amtMove, transform.position.z);
        }

        if(this.transform.position.y < 0)
        {
            actBool = false;
        }

    }

    private void Update()
    {
        //player바라보기
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Transform lookTarget = GameObject.FindGameObjectWithTag("Player").transform;
            Vector3 DIRtARGETtRANFORM = lookTarget.position - transform.position;
            this.transform.up = DIRtARGETtRANFORM.normalized;
        }
    }
    

    void InitEnemy()
    {
        float x = Random.Range(-40, 40);
        transform.position = new Vector3(x, 30, 37);
    }

    IEnumerator makeMissile()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Instantiate(enemyMissile, respawnMissile.transform.position, transform.rotation);
        }
        
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
