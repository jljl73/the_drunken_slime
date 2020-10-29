using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    private bool Direction_Right = false;
    public bool active = false;
    public bool b_tracing = false;
    public bool b_fixed = false;

    //활성화 스프라이트 렌더링
    #region
    SpriteRenderer spriteRenderer;
    private Sprite m_yelloSprite;
    private Sprite m_greenSprite;
    private Animator m_purpleSprite;
    #endregion

    //사운드
    #region
    AudioSource m_audioSource;
    AudioClip InSlime;
    AudioClip DirectionChange;
    AudioClip ArrowTurn;
    #endregion

    // Object가 마우스 따라다니게

    void Start()
    {
        //if(!b_fixed)
        //    transform.position = new Vector3(-5555, -5555, 0);
        spriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
        m_yelloSprite = (Sprite) Resources.Load("Object/ArrowYellow", typeof(Sprite));
        m_greenSprite = (Sprite) Resources.Load("Object/ArrowGreen", typeof(Sprite));

        m_purpleSprite = transform.parent.GetComponent<Animator>();
        m_audioSource = transform.parent.GetComponent<AudioSource>();

        //m_Fixed = Resources.Load("Sound/FixedObject") as AudioClip;
        //Deploy = Resources.Load("Sound/Button_Sound1") as AudioClip;
        //Attacked = Resources.Load("Sound/AttackedMouse") as AudioClip;
        InSlime = Resources.Load("Sound/SlimeInArrow") as AudioClip;
        DirectionChange = Resources.Load("Sound/DirectionChange") as AudioClip;
        ArrowTurn = Resources.Load("Sound/ArrowChange") as AudioClip;

        if (!GameManager.instance.SoundOnOff)
            transform.parent.GetComponent<AudioSource>().volume = 0.0f;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        #region 슬라임 충돌
        if ((other.gameObject.tag == "RedSlime" || other.gameObject.tag == "BlackSlime") && active)
        {
            if ((Direction_Right == true && other.GetComponent<PlayerMove>().speed > 0) || (!Direction_Right && other.GetComponent<PlayerMove>().speed < 0))
            {
                other.GetComponent<PlayerMove>().speed *= -1.0f;
                ActivateSound(DirectionChange, 1f);
            }
        }
        if (other.gameObject.tag == "GreenSlime")
        {
            if (active)
            {
                if ((Direction_Right == true && other.GetComponent<PlayerMove>().speed > 0) || (!Direction_Right && other.GetComponent<PlayerMove>().speed < 0))
                {
                    other.GetComponent<PlayerMove>().speed *= -1f;
                    ActivateSound(DirectionChange, 1f);
                }
            }
            else
            {
                spriteRenderer.sprite = m_greenSprite;
                //Destroy(other.gameObject);
                other.gameObject.SetActive(false);
                active = true;
                Direction_Right = spriteRenderer.flipX;
                ActivateSound(InSlime, 0.5f);
            }
        }
        if (other.gameObject.tag == "YellowSlime") 
        {
            if (active)
            {
                if ((Direction_Right == true && other.GetComponent<PlayerMove>().speed > 0) || (!Direction_Right && other.GetComponent<PlayerMove>().speed < 0))
                {
                    other.GetComponent<PlayerMove>().speed *= -1.0f;
                    ActivateSound(DirectionChange, 1f);
                }
            }
            else
            {
                spriteRenderer.sprite = m_yelloSprite;
                //Destroy(other.gameObject);
                other.gameObject.SetActive(false);
                active = true;
                Direction_Right = !spriteRenderer.flipX;
                ActivateSound(InSlime, 0.5f);
            }
        }
        if (other.gameObject.tag == "PurpleSlime")
        {
            if (active)
            {
                if ((Direction_Right == true && other.GetComponent<PlayerMove>().speed > 0) || (!Direction_Right && other.GetComponent<PlayerMove>().speed < 0))
                {
                    other.GetComponent<PlayerMove>().speed *= -1f;
                    ActivateSound(DirectionChange, 1f);
                }
            }
            else
            {
                m_purpleSprite.runtimeAnimatorController = Resources.Load("ArrowFull") as RuntimeAnimatorController;
                m_purpleSprite.Play("Purple_Arrow");
                other.gameObject.SetActive(false);
                active = true;
                GetComponent<Collider2D>().enabled = false;
                ActivateSound(InSlime, 0.5f);
            }
        }
        #endregion


    }

    void Trace()
    {
        Vector3 mousePoint = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            10);

        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePoint);
        transform.position = objPosition;

    }

    void ActivateSound(AudioClip audioClip, float volume)
    {
        if (GameManager.instance.SoundOnOff)
        {
            m_audioSource.clip = audioClip;
            m_audioSource.volume = volume;
            m_audioSource.Play();
        }
    }

    public void TurnArrow()
    {
        transform.parent.GetComponent<SpriteRenderer>().flipX = !transform.parent.GetComponent<SpriteRenderer>().flipX;
        ActivateSound(ArrowTurn, 0.3f);
    }
    
}
