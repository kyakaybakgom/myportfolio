using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour {
    
    //string 변수 선언
    private const string m_Vertical     = "Vertical";
    private const string m_Horizontal   = "Horizontal";
    private const string m_Blend        = "Blend";
    private const string m_Jump         = "Jump";

    private const string m_Plane        = "Plane";
    private const string m_Star         = "STAR";
    private const string m_Obstacle     = "Obstacle";
    
    Transform m_tranform;
    Rigidbody m_rigdbody;

    Animator m_anim;
    AudioSource m_audio;

    private DataManager dataManager = null;

    //speed
    float m_speed = 0.01f;

    //vertical, horizontal
    private float m_h = 0.0f;
    
    private readonly float  m_jumpForce         = 6.0f;     // 점프 속도

    private bool isGrounded = true; // 캐릭터가 지면에 있는지 확인

    //SCORE
    int m_score = 10;

    public ScoreManager m_scoreManager;

    //audioClip
    public AudioClip m_JumpAudio;
    public AudioClip m_EndAudio;

    //endingPanel
    public GameObject m_endingPanel;

    //skill
    

    
    // Use this for initialization
    void Start ()
    {
        Init();
    }

    // 초기화
    void Init() 
    {
        m_tranform = this.transform;
        m_rigdbody = GetComponent<Rigidbody>();
        m_anim = GetComponent<Animator>();
        m_audio = GetComponent<AudioSource>();
        m_endingPanel.SetActive(false);

        dataManager = dataManager ?? DataManager.Instance;

        isGrounded = true;
    }
	
	void Update ()
    {
        if (dataManager.GameAct.Equals(true))
        {
            //걷기
            WalkFunc();

            // 점프
            JumpFunc();
        }
        else
        {
            //게임 리스타트
            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
    }

    void WalkFunc()
    {
        m_h = Input.GetAxis(m_Horizontal); //좌우

        m_tranform.position += Vector3.right * (m_h * m_speed);
    }

    void JumpFunc()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded.Equals(true))
        {
            m_anim.CrossFade(m_Jump, 0.1f);

            // 점프 높이에 따른 속도 계산
            m_rigdbody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);

            m_audio.PlayOneShot(m_JumpAudio);

            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (dataManager.GameAct.Equals(false)) return;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(m_Star))
        {
            dataManager.ScoreData += m_score;
            m_scoreManager.ScoreUpdateFunc();
        }

        if (collision.transform.CompareTag(m_Plane))
        {
            if (!isGrounded)
                isGrounded = true;
        }

        if (collision.transform.CompareTag(m_Obstacle))
        {
            dataManager.GameAct = false;
            m_anim.CrossFade("Dead", 0.1f);
            m_audio.PlayOneShot(m_EndAudio);

            m_endingPanel.SetActive(true);
        }
        else
        {

        }
    }
}
