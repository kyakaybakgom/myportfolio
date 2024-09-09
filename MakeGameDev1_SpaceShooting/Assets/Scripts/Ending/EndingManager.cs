using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour {

    public Text scoreTxt; //스코어표시
    public Text shootAstTxt; //유성 격추수 표시
    public Text shootEnemyTxt; //적 격추수 표시

    public GameObject reTxt; //restart 표시

    public float reTime = 0.8f;

	// Use this for initialization
	void Start ()
    {
        scoreTxt.text = DataPath.Instance.gamePoint.ToString();
        shootAstTxt.text = DataPath.Instance.shootAsteroid.ToString();
        shootEnemyTxt.text = DataPath.Instance.shootEnemy.ToString();
        StartCoroutine("pushReBT");
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown("k"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
	}

    IEnumerator pushReBT()
    {
        for (;;)
        {
            reTxt.SetActive(false);
            yield return new WaitForSeconds(reTime);
            reTxt.SetActive(true);
            yield return new WaitForSeconds(reTime);
        }
    }
}
