using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    public GameObject ClearPanel;
    public GameObject StartPoint;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "RedSlime")
        {
            if (GameManager.instance != null && GameManager.instance.Clear < SceneManager.GetActiveScene().buildIndex)
            {
                GameManager.instance.StageClear();
            }
            other.gameObject.SetActive(false);
            ClearPanel.SetActive(true);
            StartPoint.SetActive(false);
        }
        else
        {
            other.gameObject.SetActive(false);
        }
    }
}
