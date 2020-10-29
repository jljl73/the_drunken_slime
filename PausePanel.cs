using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    Button BackButton;
    Button OnOffButton;
    Button RetryButton;
    Button PauseButton;
    Button ReturnButton;

    Sprite OnImg;
    Sprite OffImg;
    public GameObject m_StartPoint;

    void Start()
    {
        BackButton = transform.Find("Pause Panel").Find("Back").GetComponent<Button>();
        OnOffButton = transform.Find("Pause Panel").Find("Sound").GetComponent<Button>();
        RetryButton = transform.Find("Pause Panel").Find("Retry").GetComponent<Button>();
        ReturnButton = transform.Find("Pause Panel").Find("Return").GetComponent<Button>();
        PauseButton = this.GetComponent<Button>();
        

        BackButton.onClick.AddListener(BackScene);
        OnOffButton.onClick.AddListener(SoundOnOff);
        RetryButton.onClick.AddListener(ResetScene);
        PauseButton.onClick.AddListener(ShowHide);
        ReturnButton.onClick.AddListener(ShowHide);

        OnImg = (Sprite)Resources.Load("Menu/SoundOn", typeof(Sprite));
        OffImg = (Sprite)Resources.Load("Menu/SoundOff", typeof(Sprite));

        SoundOnOff();
        SoundOnOff();
    }

    void BackScene()
    {
        SceneManager.LoadScene("StageScene");
    }
    void SoundOnOff()
    {
        if (GameManager.instance.SoundOnOff)
        {
            m_StartPoint.transform.Find("Ready").GetComponent<AudioSource>().volume = 0;
            m_StartPoint.transform.Find("Start").GetComponent<AudioSource>().volume = 0; ;
            GameManager.instance.SoundOnOff = !GameManager.instance.SoundOnOff;
            transform.Find("Pause Panel").Find("Sound").GetComponent<Image>().sprite = OffImg;
        }
        else
        {
            m_StartPoint.transform.Find("Ready").GetComponent<AudioSource>().volume = 1;
            m_StartPoint.transform.Find("Start").GetComponent<AudioSource>().volume = 1;
            GameManager.instance.SoundOnOff = !GameManager.instance.SoundOnOff;
            transform.Find("Pause Panel").Find("Sound").GetComponent<Image>().sprite = OnImg;
        }
    }
    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ShowHide()
    {
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
