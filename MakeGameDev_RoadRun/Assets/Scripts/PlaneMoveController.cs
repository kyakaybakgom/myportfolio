using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMoveController : MonoBehaviour {

    Transform m_transform;

    //speed
    float m_speed = 0.01f;

    private void Awake()
    {
        m_transform = this.transform;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (DataManager.Instance.GameAct.Equals(false)) return;

        m_transform.position += Vector3.back * m_speed;

        if(m_transform.position.z <= -50)
        {
            destroyFunc();
        }
	}

    void destroyFunc()
    {
        Destroy(this.gameObject);
    }
}
