using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {

    Transform m_transform;

    float m_speed = 0.02f;

    private void Awake()
    {
        m_transform = this.transform;
    }

    // Update is called once per frame
    void Update ()
    {
        if (DataManager.Instance.GameAct.Equals(false)) return;

        m_transform.position += Vector3.back * m_speed;

        if (m_transform.position.z <= -50)
        {
            Destroy(this.gameObject);
        }
        
	}
}
