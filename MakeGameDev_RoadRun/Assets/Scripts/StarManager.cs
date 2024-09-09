using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour {

    //effect
    public GameObject m_starEffect;

    Transform m_transform;
    AudioSource m_audio;

    //audioClip
    public AudioClip m_effectAduio;

    float m_speed = 0.2f;
    
    private void Awake()
    {
        m_transform = this.transform;
        m_audio = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_transform.localRotation *= Quaternion.Euler(new Vector3(0, 0, 3));

        if (DataManager.Instance.GameAct.Equals(false)) return;

        m_transform.position += Vector3.back * m_speed;

        if (m_transform.position.z <= -20)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (DataManager.Instance.GameAct.Equals(false)) return;

        if (other.CompareTag("Player"))
        {
            GameObject m_effect = Instantiate(m_starEffect, m_transform.position, Quaternion.identity);
            m_effect.GetComponent<ParticleSystem>().Emit(1);

            SoundManager.Instance.Sound2DFunc(m_effectAduio);

            Destroy(this.gameObject);
        }
    }
}
