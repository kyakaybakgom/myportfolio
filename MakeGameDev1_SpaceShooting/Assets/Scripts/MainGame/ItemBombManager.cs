using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBombManager : MonoBehaviour {

    private const string m_up = "boxU";
    private const string m_right = "boxR";
    private const string m_left = "boxL";
    private const string m_down = "boxD";

    Vector3 moveVec = Vector3.zero;
    Transform m_transform;

    float m_speed = 1000.0f;

	// Use this for initialization
	void Start ()
    {
        m_transform = this.transform;

        //moveVec = Vector3.right * m_speed * Time.fixedDeltaTime;
        //m_transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 20));

        GetComponent<Rigidbody>().AddForce(new Vector3(1, 1, 0).normalized * m_speed);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //m_transform.Translate(moveVec);
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        //if (other.CompareTag(m_up))
        //{
        //    moveVec = Vector3.up * m_speed * Time.fixedDeltaTime;
        //}

        //if (other.CompareTag(m_down))
        //{
        //    moveVec = Vector3.down * m_speed * Time.fixedDeltaTime;
        //}

        //if (other.CompareTag(m_left))
        //{
        //    moveVec = Vector3.left* m_speed * Time.fixedDeltaTime;
        //}

        //if (other.CompareTag(m_right))
        //{
        //    moveVec = Vector3.right * m_speed * Time.fixedDeltaTime;
        //}
    }
}
