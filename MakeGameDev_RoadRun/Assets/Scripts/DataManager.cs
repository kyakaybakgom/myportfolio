using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    //싱글턴
    private static DataManager _instance = null;

    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(DataManager)) as DataManager;

                if (_instance == null)
                {
                    Debug.LogError("DataManager Singleton Error...");
                }
            }

            return _instance;
        }
    }
    
    //저장할 데이터 변수들
    public int ScoreData;
    public bool GameAct = true;

    private void Awake()
    {
        //변수 초기화
        ScoreData = 0;
        GameAct = true;
    }

}
