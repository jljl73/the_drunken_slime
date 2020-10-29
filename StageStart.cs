using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageStart : MonoBehaviour
{
    //public Button btn_start;
    public GameObject slimes;
    public bool start;

    GameObject prevObject;
    private int order = 0;
    public int m_SlimeNumber;

    void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    void Start()
    {
        GameManager.instance.Arrow = 0;
        GameManager.instance.Pipe = 0;
        GameManager.instance.m_state = 0;

        prevObject = null;
        start = false;

        transform.Find("Ready").GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if (start)
        {
            if (prevObject == null || !prevObject.activeSelf) // 슬라임이 순서대로 나감
            {
                for (int i = 0; i < slimes.transform.childCount; i++)
                {
                    if (order == slimes.transform.GetChild(i).GetComponent<PlayerMove>().m_order &&
                        !slimes.transform.GetChild(i).gameObject.activeSelf)
                    {
                        order++;
                        slimes.transform.GetChild(i).gameObject.SetActive(true);
                        prevObject = slimes.transform.GetChild(i).gameObject;
                        break;
                    }
                }
            }

        }
    }
    
    public void PressStart()
    {
        //btn_start.gameObject.SetActive(false);
        if (CanStart())
        {
            start = true;
            transform.Find("Ready").GetComponent<AudioSource>().Stop();
            transform.Find("Start").GetComponent<AudioSource>().Play();
        }
        else
        {
            Debug.Log("게임을 시작할 수 없습니다.");
        }
    }

    public bool CanStart()
    {
        if (slimes.transform.childCount == m_SlimeNumber)
            return true;
        else
            return false;
        //bool check = true;
        //for(int i = 0; i < slimes.transform.childCount; i++)
        //{
        //    if(slimes.transform.GetChild(i).GetComponent<PlayerMove>().m_order == -1)
        //    {
        //        check = false;
        //    }
        //}
        //return check;
    }
    
}
