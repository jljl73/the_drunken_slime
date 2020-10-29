using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRemainObject : MonoBehaviour
{
    BottomMenu menu;

    private Text arrow;
    private Text pipe;

    void Start()
    {
        menu = GetComponent<BottomMenu>();
        arrow = transform.Find("Arrow").Find("Text").GetComponent<Text>();
        pipe = transform.Find("Pipe").Find("Text").GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        arrow.text = "X " + System.Convert.ToInt32(menu.m_ArrowNumber - GameManager.instance.Arrow);
        pipe.text = "X " + System.Convert.ToInt32(menu.m_PipeNumber - GameManager.instance.Pipe);
    }
}
