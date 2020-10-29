using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public GameObject OverPanel;
    AudioClip Attacked;
    AudioSource m_audioSource;
    // Start is called before the first frame update

        void Start()
    {
        m_audioSource = this.GetComponent<AudioSource>();
        Attacked = Resources.Load("Sound/AttackedfromMouse") as AudioClip;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ActivateSound(Attacked);
        if (other.gameObject.tag == "RedSlime")
        {
            OverPanel.SetActive(true);
            other.gameObject.SetActive(false);
        }
        else
        {
            other.gameObject.SetActive(false);
        }

    }

    void ActivateSound(AudioClip audioClip)
    {
        if (GameManager.instance.SoundOnOff)
        {
            m_audioSource.clip = audioClip;
            m_audioSource.Play();
        }
    }
}
