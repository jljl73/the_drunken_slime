using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BottomMenu : MonoBehaviour
{
    public int m_ArrowNumber;
    public ObjectController m_Arrow;
    public int m_PipeNumber;
    public ObjectController m_Pipe;

    public StageStart StartPoint;
    public GameObject SlimeMenu;
    public GameObject FoldedMenu;

    private Button btn_Reset;
    private Button btn_Pipe;
    private Button btn_Arrow;
    private Button btn_Start;
    private Button btn_Fold;

    public int cur_pipe = 0;
    public int cur_arrow = 0;

    void Start()
    {
        btn_Reset = transform.Find("Reset").GetComponent<Button>();
        btn_Pipe = transform.Find("Pipe").GetComponent<Button>();
        btn_Arrow = transform.Find("Arrow").GetComponent<Button>();
        btn_Start = transform.Find("Start").GetComponent<Button>();
        btn_Fold = transform.Find("Fold").GetComponent<Button>();


        btn_Reset.onClick.AddListener(ResetScene);
        btn_Arrow.onClick.AddListener(GenerateArrow);
        btn_Pipe.onClick.AddListener(GeneratePipe);
        btn_Start.onClick.AddListener(PressStart);
        btn_Fold.onClick.AddListener(Fold);

    }
    void ResetScene()  // 현재씬 다시 불러오기
    {
        GameManager.instance.Starting = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GenerateArrow() // 이정표 생성
    {
        if (GameManager.instance.Arrow < m_ArrowNumber && !GameManager.instance.Starting)
        {
            //arrows.GetComponent<ObjectController>().b_tracing = true;
            //Instantiate(arrows);
            GameManager.instance.m_state = 1;
            //GameManager.instance.Arrow++;
            //cur_arrow++;
        }
    }

    void GeneratePipe() // 파이프 생성
    {
        if (GameManager.instance.Pipe < m_PipeNumber && !GameManager.instance.Starting)
        {
            //pipes.GetComponent<ObjectController>().b_tracing = true;
            //Instantiate(pipes);
            GameManager.instance.m_state = 2;
            //GameManager.instance.Pipe++;
            //cur_pipe++;
        }
    }
    
    void PressStart()
    {
        GameManager.instance.m_state = 0;
        if (StartPoint.CanStart() && !GameManager.instance.Starting)
        {
            GameManager.instance.Starting = true;
            StartPoint.PressStart();
            Time.timeScale = 2.0f;
            //SlimeMenu.SetActive(false);
            //this.gameObject.SetActive(false);
            //FoldedMenu.SetActive(true);
        }
        else
        {
            if(GameManager.instance.SoundOnOff)
                GetComponent<AudioSource>().Play();
        }
    }

    void Fold()
    {
        FoldedMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
