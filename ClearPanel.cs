using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ClearPanel : MonoBehaviour
{
    Button Back;
    Button Next;
    Button Retry;

    public GameObject PauseButton;

    void Awake()
    {
        GameManager.instance.Starting = false;
    }
    void Start()
    {
        Back = transform.Find("Back").GetComponent<Button>();
        Next = transform.Find("Next").GetComponent<Button>();
        Retry = transform.Find("Retry").GetComponent<Button>();

        Back.onClick.AddListener(BackScene);
        Next.onClick.AddListener(NextScene);
        Retry.onClick.AddListener(ResetScene);
        PauseButton.SetActive(false);

        if (!GameManager.instance.SoundOnOff)
            GetComponent<AudioSource>().volume = 0.0f;
    }

    void BackScene()
    {
        SceneManager.LoadScene("StageScene");
    }
    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
