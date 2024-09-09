using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlaneManager : MonoBehaviour {
    
    Transform m_tranform;

    public GameObject m_plane;

    GameObject currentGameobj = null;

    private void Awake()
    {
        m_tranform = this.transform;
    }

    private void Start()
    {
        createPlaneFunc();
    }

    private void Update()
    {
        if (currentGameobj != null)
        {
            //plane생성
            if (currentGameobj.transform.position.z <= 2.829667)
            {
                createPlaneFunc();
            }
        }
    }

    public void createPlaneFunc()
    {
        currentGameobj = Instantiate(m_plane, m_tranform.position, Quaternion.identity);
    }
}
