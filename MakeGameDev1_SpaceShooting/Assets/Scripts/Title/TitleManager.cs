using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour {

    public GameObject noticeTxt;
    public float onoffTime = 1;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("noticeAct");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }   	
	}

    IEnumerator noticeAct()
    {
        for (;;)
        {
            noticeTxt.SetActive(false);
            yield return new WaitForSeconds(onoffTime);
            noticeTxt.SetActive(true);
            yield return new WaitForSeconds(onoffTime);
        }
    }
}
