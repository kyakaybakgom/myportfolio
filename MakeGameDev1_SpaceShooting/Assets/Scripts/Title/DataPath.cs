using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DataPath : MonoBehaviour {

    private static DataPath _instance = null;

    public static DataPath Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType(typeof(DataPath)) as DataPath;

                if(_instance == null)
                {
                    _instance = new GameObject("Datapath").AddComponent<DataPath>();
                }
            }

            return _instance;
        }
    }

    public int gamePoint { get; set; } //게임포인트
    public int shootAsteroid { get; set; } //유성 격파수
    public int shootEnemy { get; set; } // 적 격파수

    private void Start()
    {
        DontDestroyOnLoad(this);

        gamePoint = 0;
        shootAsteroid = 0;
        shootEnemy = 0;
    }
}
