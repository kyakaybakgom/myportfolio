using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    Text m_scoreTxt;

	// Use this for initialization
	void Start ()
    {
        m_scoreTxt = GetComponent<Text>();

        m_scoreTxt.text = "0";
	}
	
    public void ScoreUpdateFunc()
    {
        m_scoreTxt.text = DataManager.Instance.ScoreData.ToString();
    }
}
