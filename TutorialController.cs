using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    int child = 0;
    public GameObject NextObject = null;

    void Start()
    {
        if (GameManager.instance.ReadTutorial >= SceneManager.GetActiveScene().buildIndex)
        {
            this.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.anyKeyDown && child < transform.childCount)
        {
            if (child == transform.childCount - 2)
            {
                this.gameObject.SetActive(false);
                GameManager.instance.ReadTutorial = SceneManager.GetActiveScene().buildIndex;
            }
            else
            {
                transform.GetChild(child++).gameObject.SetActive(false);
                transform.GetChild(child).gameObject.SetActive(true);
            }
        }

    }
}
