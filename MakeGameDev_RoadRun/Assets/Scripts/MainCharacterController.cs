using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour {
    
    //string 변수 선언
    private const string m_Vertical = "Vertical";
    private const string m_Horizontal = "Horizontal";
    private const string m_Blend = "Blend";
    private const string m_Jump = "Jump";

    private const string m_Plane = "Plane";
    private const string m_Star = "STAR";
    private const string m_Obstacle = "Obstacle";
    
    Transform m_tranform;
    Rigidbody m_rigdbody;

    Animator m_anim;
    AudioSource m_audio;

    bool isGrounded = true;

    //speed
    float m_speed = 0.01f;

    //vertical, horizontal
    private float m_h = 0.0f;

    //SCORE
    int m_score = 10;

    public ScoreManager m_scoreManager;

    //audioClip
    public AudioClip m_JumpAudio;
    public AudioClip m_EndAudio;

    //endingPanel
    public GameObject m_endingPanel;

    //skill
    

    //초기화
    private void Awake()
    {
        m_tranform = this.transform;
        m_rigdbody = GetComponent<Rigidbody>();
        m_anim = GetComponent<Animator>();
        m_audio = GetComponent<AudioSource>();
        m_endingPanel.SetActive(false);
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //게임 리스타트
        if (DataManager.Instance.GameAct.Equals(false))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }

        if (DataManager.Instance.GameAct.Equals(false)) return;

        //걷기
        m_h = Input.GetAxis(m_Horizontal); //좌우
        
        m_tranform.position += Vector3.right * (m_h * m_speed);

        //점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded.Equals(true))
        {
            m_anim.CrossFade(m_Jump, 0.1f);
            m_rigdbody.velocity += Vector3.up * 5.0f;

            m_audio.PlayOneShot(m_JumpAudio);

            isGrounded = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (DataManager.Instance.GameAct.Equals(false)) return;

        if (other.CompareTag(m_Star))
        {
            DataManager.Instance.ScoreData += m_score;
            m_scoreManager.ScoreUpdateFunc();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (DataManager.Instance.GameAct.Equals(false)) return;

        if (collision.transform.CompareTag(m_Plane))
        {
            isGrounded = true;
        }

        if (collision.transform.CompareTag(m_Obstacle))
        {
            DataManager.Instance.GameAct = false;
            m_anim.CrossFade("Dead", 0.1f);
            m_audio.PlayOneShot(m_EndAudio);

            m_endingPanel.SetActive(true);
        }
        else
        {

        }
    }
}
