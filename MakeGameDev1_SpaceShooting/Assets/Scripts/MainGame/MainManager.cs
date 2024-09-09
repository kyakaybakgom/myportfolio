using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

    // 유성 프리팹
    public GameObject prefab_Asteroid;

    // pointUI
    public Text pointUI;

    public GameObject dyingTxt;

    // 적 개체 생성
    public GameObject prefab_Enemy; // 적 개체 프리팹
    float EnemySpawnTime = 5;       // 스폰 타임
    float beforeEnemyTime = 0;      // 이전 스폰 시간

    // datapath
    private DataPath dataPath = null;

    private readonly string updateFuncStr = "UpdateFunc";
    private float fupdateTime = 0.0f;

    // 유성 생성 갯수
    private readonly int maxAstroidNum = 100;
    private readonly int minAstroidNum = 0;
    private readonly int percentAstroidNum = 90;

    // Use this for initialization
    void Start ()
    {
        Init();
	}

    // 초기화
    private void Init()
    {
        if (dataPath == null)
            dataPath = DataPath.Instance;

        dyingTxt.SetActive(false);
        InitialLizeData(); // 점수 초기화

        // update 대용
        fupdateTime = Time.fixedDeltaTime;
        InvokeRepeating(updateFuncStr, fupdateTime, fupdateTime);
    }

    void UpdateFunc()
    {
        //유성 생성
        makeAsteroid();

        //적 생성
        if(Time.time - beforeEnemyTime > EnemySpawnTime)
        {
            Instantiate(prefab_Enemy);
            beforeEnemyTime = Time.time;
        }
        
        //점수 새로고침
        UIdraw();
    }

    //점수 초기화
    void InitialLizeData()
    {
        dataPath.gamePoint = 0;
        dataPath.shootAsteroid = 0;
        dataPath.shootEnemy = 0;
    }

    // 유성 생성
    void makeAsteroid()
    {
        if(Random.Range(minAstroidNum, maxAstroidNum) > percentAstroidNum)
        {
            Instantiate(prefab_Asteroid);
        }
    }
    
    void UIdraw()
    {
        pointUI.text = dataPath.gamePoint.ToString();
    }

    public IEnumerator dyingFunc()
    {
        dyingTxt.SetActive(true);
        
        yield return new WaitForSeconds(3);

        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
