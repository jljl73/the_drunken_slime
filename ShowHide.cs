using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHide : MonoBehaviour
{
    private Button btn1;
    private Button btn2;
    private GameObject m_show;
    private GameObject m_hide;
    public bool b_hide = false;
    void Start()
    {
        m_show = transform.GetChild(0).transform.gameObject;
        m_hide = transform.GetChild(1).transform.gameObject;

        btn1 = transform.GetChild(0).Find("Button").GetComponent<Button>();
        btn2 = transform.GetChild(1).Find("Button").GetComponent<Button>();
        btn1.onClick.AddListener(btn_showhide);
        btn2.onClick.AddListener(btn_showhide);
    }

    void btn_showhide()
    {
        if (b_hide)
        {
            m_show.SetActive(true);
            m_hide.SetActive(false);
            b_hide = false;
        }
        else
        {
            m_show.SetActive(false);
            m_hide.SetActive(true);
            b_hide = true;
        }
    }
}
