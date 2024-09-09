using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacleManager : MonoBehaviour {

    Transform m_transform;

    public GameObject[] m_ObstacleType;

    float createRandomTime = 0.0f;

    private void Awake()
    {
        m_transform = this.transform;
    }

    private void Start()
    {
        Invoke("createObstacleFunc", 0.3f);
    }

    void createObstacleFunc()
    {
        int obstacleType = Random.Range(0, m_ObstacleType.Length);

        Instantiate(m_ObstacleType[obstacleType], m_ObstacleType[obstacleType].transform.position, Quaternion.identity);

        createRandomTime = Random.Range(3.0f, 5.0f);

        if (DataManager.Instance.GameAct.Equals(true))
        {
            Invoke("createObstacleFunc", createRandomTime);
        }
    }
}
