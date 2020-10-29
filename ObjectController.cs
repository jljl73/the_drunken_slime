using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;

    AudioSource m_audioSource; // 사운드
    AudioClip m_Fixed;
    AudioClip Deploy;

    public bool b_tracing = false;
    public bool b_fixed = false;
    public bool m_Complete = false;


    public GameObject parent;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        m_audioSource = GetComponent<AudioSource>();
        m_Fixed = Resources.Load("Sound/FixedObject") as AudioClip;
        Deploy = Resources.Load("Sound/Button_Sound1") as AudioClip;

        if (!b_fixed)
        {
            ActivateSound(Deploy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (b_tracing)
            Trace();

        if (Input.GetMouseButtonDown(1))
        {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            
            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                OnClick();
            }
        }
    }

    void OnClick()
    {
        if (!GameManager.instance.Starting)
        {
            if (m_Complete && !b_fixed)
            {
                ActivateSound(Deploy);
                if (transform.tag == "Arrow")
                    GameManager.instance.Arrow--;
                else
                    GameManager.instance.Pipe--;
                Destroy(this.gameObject);
            }
            if (b_fixed)
            {
                ActivateSound(m_Fixed);
            }
        }

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
        m_audioSource.volume = 0.5f;
        m_audioSource.Play();
    }
}
