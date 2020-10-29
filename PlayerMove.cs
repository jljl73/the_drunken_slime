using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    public float speed = 1.0f;

    public bool b_tracing;
    public bool deployed;

    bool b_moving;
    bool b_count;
    bool b_OnGround;
    //float m_FallingTime = 0.55f;

    Vector3 m_FallingPosition;
    //private float f_count;
    public int m_order = -1;

    Collider2D m_Collider;
    SpriteRenderer m_spriteRenderer;

    AudioClip m_Inpipe;
    AudioClip Attacked;
    AudioSource m_audioSource;

    void Start()
    {
        b_tracing = false;
        Time.timeScale = 1;

        b_moving = true; // 슬라임이 움직일떄
        b_count = false; // 떨어지는 시간 체크
        m_Collider = GetComponent<Collider2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_audioSource = GetComponent<AudioSource>();

        m_Inpipe = Resources.Load("Sound/SlimeInpipe2") as AudioClip;
        Attacked = Resources.Load("Sound/AttackedfromMouse") as AudioClip;
    }

    // Update is called once per frame
    void Update()
    {
        //일정한 속도로 왼쪽으로 이동
        if (b_moving && b_OnGround)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * 2.0f); ;
        }
        if (speed > 0)
        {
            m_spriteRenderer.flipX = true;
        }
        else
        {
            m_spriteRenderer.flipX = false;
        }

        if(m_FallingPosition.y - transform.position.y > 2.0f && b_count)// 떨어지기 시작한 1초 후에 원상복귀
        {
            m_Collider.enabled = true;
            //f_count = 0f;
            b_count = false;
            //transform.Translate(Vector3.down * 2.7f);
        }

        if (GameManager.instance.SoundOnOff)
        {
            GetComponent<AudioSource>().volume = 1;
        }
        else
        {
            GetComponent<AudioSource>().volume = 0;
        }

    }

    void OnCollisionEnter2D(Collision2D other) // 벽을 만나면 방향전환
    {
        if (other.gameObject.tag == "Wall")
        {
            ChangeDirection();
        }
        if (other.gameObject.tag == "Ground")
        {
            b_OnGround = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pipe" && this.gameObject.tag != "BlackSlime")
        {
            m_Collider.enabled = false;
            b_OnGround = false;
            b_count = true;
            transform.position = new Vector3(other.transform.position.x, transform.position.y);
            m_FallingPosition = transform.position;
            ActivateSound(m_Inpipe);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        ////Pipe에 도달 했을때 밑으로 멈추고 Collider를 제거해 밑으로 내려감
        //if (other.gameObject.tag == "Pipe" && Mathf.Abs(transform.position.x - other.transform.position.x) < 0.13f && this.gameObject.tag != "BlackSlime")
        //{
        //    m_Collider.enabled = false;
        //    b_OnGround = false;
        //    b_count = true;
        //    ActivateSound(m_Inpipe);
        //}
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            b_OnGround = false;
        }
    }

    void OnMouseDown()
    {
        b_tracing = true;
    }

    void ChangeDirection() //  방향 전환
    {
        speed *= -1.0f;
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

    void ActivateSound(AudioClip audioClip)
    {
        m_audioSource.clip = audioClip;
        m_audioSource.Play();
    }

}
