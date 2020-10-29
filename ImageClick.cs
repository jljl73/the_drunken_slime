using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageClick : MonoBehaviour
{
    public GameObject points;
    public GameObject Slimes;
    public GameObject[] obj_slimes;
    public int[] SlimeNumbers;

    public GameObject StartPoint;

    public int m_Sum;

    public int order = 0;

    Text text1;
    Text text2;
    Text text3;
    Text text4;

    void Start()
    {
        transform.GetChild(0).transform.localPosition = new Vector3(-1035.0f + m_Sum * 230f, 395f, 0);

        obj_slimes[0].transform.position = StartPoint.transform.position;
        obj_slimes[0].GetComponent<PlayerMove>().m_order = m_Sum-1;
        obj_slimes[0].SetActive(false);
        var newObject = Instantiate(obj_slimes[0]);
        newObject.transform.parent = Slimes.transform;

        if (StartPoint.GetComponent<SpriteRenderer>().flipX)
            newObject.GetComponent<PlayerMove>().speed *= -1;

        if (SlimeNumbers[1] > 0) // 노랑이
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(() => SetOrder(1));
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }

        if (SlimeNumbers[2] > 0) // 보랑이
        {
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.GetComponent<Button>().onClick.AddListener(() => SetOrder(2));
        }
        else
        {
            transform.GetChild(2).gameObject.SetActive(false);
        }

        if (SlimeNumbers[3] > 0) // 깜장이
        {
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.GetComponent<Button>().onClick.AddListener(() => SetOrder(3));
        }
        else
        {
            transform.GetChild(3).gameObject.SetActive(false);
        }


        if (SlimeNumbers[4] > 0) // 초록이
        {
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.GetComponent<Button>().onClick.AddListener(() => SetOrder(4));
        }
        else
        {
            transform.GetChild(4).gameObject.SetActive(false);
        }

        text1 = transform.GetChild(1).Find("Text").GetComponent<Text>();
        text2 = transform.GetChild(2).Find("Text").GetComponent<Text>();
        text3 = transform.GetChild(3).Find("Text").GetComponent<Text>();
        text4 = transform.GetChild(4).Find("Text").GetComponent<Text>();
    }

    void Update()
    {
        for(int i = 0; i < m_Sum; i++)
        {
            if (!points.transform.GetChild(i).GetComponent<Point>().m_active)
            {
                order = i;
                break;
            }
        }
        text1.text = "X " + System.Convert.ToInt32(SlimeNumbers[1]);
        text2.text = "X " + System.Convert.ToInt32(SlimeNumbers[2]);
        text3.text = "X " + System.Convert.ToInt32(SlimeNumbers[3]);
        text4.text = "X " + System.Convert.ToInt32(SlimeNumbers[4]);
    }

    void SetOrder(int idx)
    {
        if (SlimeNumbers[idx] > 0 && order < m_Sum - 1)
        {
            obj_slimes[idx].GetComponent<PlayerMove>().m_order = order;
            obj_slimes[idx].transform.position = StartPoint.transform.position;
            obj_slimes[idx].SetActive(false);
            var newObject = Instantiate(obj_slimes[idx]);
            newObject.transform.parent = Slimes.transform;

            if (StartPoint.GetComponent<SpriteRenderer>().flipX)
                newObject.GetComponent<PlayerMove>().speed *= -1;

            SlimeNumbers[idx]--;


            var Deploy = Instantiate(transform.GetChild(idx));
            Deploy.transform.SetParent(this.transform);
            Deploy.GetComponent<SlimeIcon>().Deployed = true;
            Deploy.GetComponent<SlimeIcon>().point = points.transform.GetChild(order).gameObject;
            Deploy.GetComponent<SlimeIcon>().idx = idx;
            Deploy.GetComponent<SlimeIcon>().slime = newObject;
            Deploy.GetChild(0).GetComponent<Text>().text = "";
            points.transform.GetChild(order).GetComponent<Point>().m_active = true;

            Deploy.GetComponent<Button>().onClick.AddListener(Deploy.GetComponent<SlimeIcon>().DestroyObject);
            Deploy.localScale = transform.GetChild(idx).transform.localScale;


            Deploy.transform.position = points.transform.GetChild(order).position;

            order++;
        }
    }
}
