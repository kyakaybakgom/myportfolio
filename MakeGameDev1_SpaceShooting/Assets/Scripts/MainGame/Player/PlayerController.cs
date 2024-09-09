using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private const string m_bombItem = "ItemBomb";
    private const string m_horizontal = "Horizontal";
    private const string m_vertical = "Vertical";

    int speed = 20; //좌우속도
    float fw = Screen.width * 0.08f; //전투기의 폭
    float fh = Screen.height * 0.08f; //전투기의 위아래 길이

    //미사일 발사 포인트
    public Transform LweaponPos;
    public Transform RweaponPos;

    //미사일
    public Transform missileObj;
    public AudioClip missileClip;

    public GameObject mineObj;
    bool actBool = true;

    float currentMissileTime = 0.0f;
    float shootMissileTime = 0.25f;

    //bomb protected
    public bool bombProtect = false;
    BombManager m_bombManager;

    private void Awake()
    {
        m_bombManager = GetComponent<BombManager>();
    }

    // Use this for initialization
    void Start ()
    {
        actBool = true;
        bombProtect = false;
	}

    private void FixedUpdate()
    {
        if (actBool)
        {
            MovingFighter();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (actBool)
        {
            currentMissileTime += Time.fixedDeltaTime;

            InputWeapon();
        }
	}

    //캐릭터 이동
    void MovingFighter()
    {
        float amtMove = speed * Time.fixedDeltaTime;
        float key = Input.GetAxis(m_horizontal); //좌우 키 입력
        float key1 = Input.GetAxis(m_vertical); //위아래 키 입력

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);

        //전투기 좌우 이동 범위 제한
        if ((key < 0 && pos.x > fw) || (key > 0 && pos.x < Screen.width - fw))
        {
            transform.Translate(Vector3.right * amtMove * key, Space.World);
            transform.eulerAngles = new Vector3(-90, 0, -key * 20); //좌우 이동시 전투기 기울기
        }

        //전투기 위아래 이동 범위 제한
        if((key1<0 && pos.y > fh) || (key1 > 0 && pos.y < Screen.height - fh))
        {
            transform.Translate(Vector3.up * amtMove * key1, Space.World);
        }
    }

    //미사일 발사
    void InputWeapon()
    {
        // 일반 미사일 발사
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(missileObj, LweaponPos.position, Quaternion.identity);
            Instantiate(missileObj, RweaponPos.position, Quaternion.identity);

            AudioSource.PlayClipAtPoint(missileClip, transform.position);

            currentMissileTime = 0.0f;
        }

        if (Input.GetKey(KeyCode.K) && currentMissileTime > shootMissileTime)
        {
            Instantiate(missileObj, LweaponPos.position, Quaternion.identity);
            Instantiate(missileObj, RweaponPos.position, Quaternion.identity);

            AudioSource.PlayClipAtPoint(missileClip, transform.position);

            currentMissileTime = 0.0f;
        }

        // 폭탄 발사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bombProtect.Equals(false))
            {
                bombProtect = true;
                m_bombManager.BombFunc();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(m_bombItem))
        {
            m_bombManager.bombImageAdd();
        }


        if (bombProtect) return;

        if(other.transform.tag == "Asteroid")
        {
            //cash asteroid
            other.SendMessage("DestroySelf");
            GameObject.FindGameObjectWithTag("MainManager").SendMessage("dyingFunc");
            actBool = false;
            mineObj.SetActive(false);
        }
    }

    public void DestroySelf()
    {
        GameObject.FindGameObjectWithTag("MainManager").SendMessage("dyingFunc");
        actBool = false;
        mineObj.SetActive(false);
    }
}
