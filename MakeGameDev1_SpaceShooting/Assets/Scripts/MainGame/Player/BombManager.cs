using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombManager : MonoBehaviour {

    private const string m_bombTxt = "BombImage";

    public AudioClip explosionClip;

    public GameObject m_particle;

    public Image i_bomb;
    public GameObject bombPanel;
    
    int bombNum = 0;

    private void Start()
    {
        m_particle.SetActive(false);

        bombNum = 3;
        bombImageFunc();
    }
    
    public void BombFunc()
    {
        if(bombNum > 0)
        {
            bombNum--;
            bombImageRemove();

            m_particle.SetActive(true);
            AudioSource.PlayClipAtPoint(explosionClip, transform.position, 1.0f);

            StartCoroutine(explosionFunc());
        }
    }

    IEnumerator explosionFunc()
    {
        yield return new WaitForSeconds(2.0f);

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Asteroid"))
        {
            obj.GetComponent<AteroidManager>().CallDestroy();
            DataPath.Instance.gamePoint += 100;
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy0"))
        {
            obj.GetComponent<EnemyManager>().CallDestroy();
            DataPath.Instance.gamePoint += 150;
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("EnemyMissile"))
        {
            obj.GetComponent<EnemyMissile>().CallDestroy();
        }

        GetComponent<PlayerController>().bombProtect = false;
        m_particle.SetActive(false);
    }

    //폭탄 이미지 초기화
    void bombImageFunc()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag(m_bombTxt))
        {
            Destroy(obj);
        }

        for(int i=0; i < bombNum; i++)
        {
            Image obj = Instantiate(i_bomb);
            obj.transform.parent = bombPanel.transform;
            Vector3 vec = obj.GetComponent<RectTransform>().localPosition;
            vec.z = 0;
            obj.GetComponent<RectTransform>().localPosition = vec;
            obj.GetComponent<RectTransform>().localScale = Vector3.one;
        }
    }

    //폭탄 추가
    public void bombImageAdd()
    {
        bombNum++;

        Image obj = Instantiate(i_bomb);
        obj.transform.parent = bombPanel.transform;
        Vector3 vec = obj.GetComponent<RectTransform>().localPosition;
        vec.z = 0;
        obj.GetComponent<RectTransform>().localPosition = vec;
        obj.GetComponent<RectTransform>().localScale = Vector3.one;
    }

    //폭탄 감소
    void bombImageRemove()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag(m_bombTxt);
        Destroy(obj[obj.Length - 1]);
    }
}
