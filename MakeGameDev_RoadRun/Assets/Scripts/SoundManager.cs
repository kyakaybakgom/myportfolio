using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private static SoundManager _instance = null;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(SoundManager)) as SoundManager;

                if (_instance == null)
                {
                    Debug.LogError("soundmanager singleton error");
                }
            }

            return _instance;
        }
    }

    AudioSource m_audio;
    
	// Use this for initialization
	void Start ()
    {
        m_audio = GetComponent<AudioSource>();
	}
	
    public void Sound2DFunc(AudioClip m_clip)
    {
        m_audio.PlayOneShot(m_clip);
    }
}
