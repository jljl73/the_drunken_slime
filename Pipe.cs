using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    //public float down_speed = 2.0f;
    public bool b_tracing = true;
    public bool b_fixed = false;
    SpriteRenderer spriteRenderer;
    public Sprite m_blackSprite;

    AudioSource m_audioSource;
    AudioClip Fixed;
    AudioClip deploy;
    AudioClip InBlack;

    void Start()
    {
        spriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
        m_blackSprite = (Sprite)Resources.Load("Object/PipeBlack", typeof(Sprite));
        m_audioSource = this.GetComponent<AudioSource>();

        //Fixed = Resources.Load("Sound/FixedObject") as AudioClip;
        //deploy = Resources.Load("Sound/Button_Sound1") as AudioClip;
        InBlack = Resources.Load("Sound/PipeInSlime") as AudioClip;

        if (!GameManager.instance.SoundOnOff)
            transform.parent.GetComponent<AudioSource>().volume = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (b_tracing && !b_fixed)
        //{
        //    Trace();
        //}
    }

    //void OnMouseUp()
    //{
    //    if (!GameManager.instance.Starting)
    //    {
    //        if (b_fixed)
    //        {
    //            ActivateSound(Fixed);
    //        }
    //        else
    //        {
    //            b_tracing = !b_tracing;
    //        }
    //        if (!b_tracing)
    //        {
    //            ActivateSound(deploy);
    //        }
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BlackSlime")
        {
            ActivateSound(InBlack);
            other.gameObject.SetActive(false);
            spriteRenderer.sprite = m_blackSprite;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    //if(other.gameObject.tag == "BlackSlime" && Mathf.Abs(transform.position.x - other.transform.position.x) < 0.3f)
    //    //{
    //    //    ActivateSound(InBlack);
    //    //    other.gameObject.SetActive(false);
    //    //    spriteRenderer.sprite = m_blackSprite;
    //    //    GetComponent<Collider2D>().enabled = false;
    //    //}
    //}

    //void Trace()
    //{
    //    Vector3 mousePoint = new Vector3(
    //        Input.mousePosition.x,
    //        Input.mousePosition.y,
    //        10);

    //    Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePoint);
    //    transform.position = objPosition;

    //}

    void ActivateSound(AudioClip audioClip)
    {
        if (GameManager.instance.SoundOnOff)
        {
            m_audioSource.clip = audioClip;
            m_audioSource.volume = 0.6f;
            m_audioSource.Play();
        }
    }
}
