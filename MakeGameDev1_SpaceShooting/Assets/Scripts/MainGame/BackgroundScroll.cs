using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour {

    float speed = 3f;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //페이지 스크롤 속도
        float ofs = speed * Time.deltaTime;
        
        transform.position = new Vector3(0, transform.position.y - ofs, 748);

        //y범위를 넘었을 때 자기자신 삭제
        if(transform.position.y <= -56)
        {
            BackGroundManager.Instance.copyBackground();
            Destroy(gameObject);
        }
    }
}
