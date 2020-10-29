using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CurrentStage : MonoBehaviour
{
    public int CurrentNumber;
    public Button m_BackBtn;
    public Button m_NextBtn;
    public Button m_BackBtn1;

    void Start()
    {
        m_BackBtn.onClick.AddListener(BackToStage);
        m_NextBtn.onClick.AddListener(GoToNext);
        m_BackBtn1.onClick.AddListener(BackToStage);
    }

    // Update is called once per frame

    void BackToStage()
    {
        SceneManager.LoadScene("StageScene");
    }

    void GoToNext()
    {
        SceneManager.LoadScene(CurrentNumber + 1);
    }
}
