using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OverPanel : MonoBehaviour
{
    Button Back;
    Button Retry;

    public GameObject PauseButton;
    void Awake()
    {
        GameManager.instance.Starting = false;
    }
    void Start()
    {
        Back = transform.Find("Back").GetComponent<Button>();
        Retry = transform.Find("Retry").GetComponent<Button>();

        Back.onClick.AddListener(BackScene);
        Retry.onClick.AddListener(ResetScene);
        PauseButton.SetActive(false);

        if (!GameManager.instance.SoundOnOff)
            GetComponent<AudioSource>().volume = 0.0f;
    }

    void BackScene()
    {
        SceneManager.LoadScene("StageScene");
    }

    void ResetScene()
    {
        GameManager.instance.Starting = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
