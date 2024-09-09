using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour {

    public Transform prefabBackGound;

    private static BackGroundManager _instance = null;

    public static BackGroundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType(typeof(BackGroundManager)) as BackGroundManager;
            }

            return _instance;
        }
    }

    // Use this for initialization
    void Start()
    {
        Instantiate(prefabBackGound, new Vector3(0, 62, 44), Quaternion.identity);

        Instantiate(prefabBackGound, new Vector3(0, 1.5f, 44), Quaternion.identity);
    }
    
    public void copyBackground()
    {
        Instantiate(prefabBackGound, new Vector3(0, 62, 44), Quaternion.identity);
    }
}
