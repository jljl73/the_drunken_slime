using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageChange : MonoBehaviour
{
    public int m_CurrentPage;
    private Button Next;
    private Button Back;

    void Start()
    {
        Next = transform.Find("Next").GetComponent<Button>();
        Back = transform.Find("Back").GetComponent<Button>();
        Next.onClick.AddListener(NextPage);
        Back.onClick.AddListener(BackPage);

        if (!GameManager.instance.SoundOnOff)
            GetComponent<AudioSource>().volume = 0.0f;
    }

    void NextPage()
    {
        for(int i = 0; i < 4; i++)
        {
            transform.GetChild(4 * m_CurrentPage + i).gameObject.SetActive(false);
        }
        m_CurrentPage++;
        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(4 * m_CurrentPage + i).gameObject.SetActive(true);
        }
        NextBackBtn();
    }

    void BackPage()
    {
        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(4 * m_CurrentPage + i).gameObject.SetActive(false);
        }
        m_CurrentPage--;
        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(4 * m_CurrentPage + i).gameObject.SetActive(true);
        }
        NextBackBtn();
    }

    void NextBackBtn()
    {
        if (m_CurrentPage == 4)
        {
            Next.gameObject.SetActive(false);
        }
        else
        {
            Next.gameObject.SetActive(true);
        }
        if (m_CurrentPage == 0)
        {
            Back.gameObject.SetActive(false);
        }
        else
        {
            Back.gameObject.SetActive(true);
        }
    }
}
