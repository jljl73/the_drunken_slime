using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeStage : MonoBehaviour
{
    // Start is called before the first frame update
    public string StageScene;
    public int StageNumber;
    public GameObject Fade;

    Button m_button;
    Image m_image;
    ColorBlock cb;

    void Start()
    {
        m_button = this.transform.GetComponent<Button>();
        m_image = this.transform.GetComponent<Image>();
        cb = m_button.colors;

        if(StageNumber <= GameManager.instance.Clear)
        {
            m_image.sprite = Resources.Load<Sprite>("StageNumber/G (" + System.Convert.ToString(StageNumber) + ")");
        }
        else if (StageNumber == GameManager.instance.Open)
        {
            m_image.sprite = Resources.Load<Sprite>("StageNumber/B(" + System.Convert.ToString(StageNumber) + ")");
        }
        else
        {
            m_image.sprite = Resources.Load<Sprite>("StageNumber/X (" + System.Convert.ToString(StageNumber) + ")");
        }

        m_button.colors = cb;
        m_button.onClick.AddListener(GotoStage);
    }

    void Update()
    {
    }

    public void GotoStage()
    {
        if (GameManager.instance.Open >= StageNumber)
        {
            Fade.GetComponent<FadeInOut>().FadeOutFunc(StageScene);
        }
    }

    void OnMouseDown()
    {
        //Debug.Log("clicked");
        if(GameManager.instance.Open >= StageNumber)
        {
            GotoStage();
        }
    }

}
