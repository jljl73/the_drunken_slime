using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{

    Color color;

    void Start()
    {
        color = GetComponent<Image>().color;
        color.a = 1f;
        GetComponent<Image>().color = color;
        Time.timeScale = 1;

        StartCoroutine(FadeInImage());
    }

    public void FadeOutFunc(string NextSceneName)
    {
        StartCoroutine(FadeOut(NextSceneName));
    }


    IEnumerator FadeInImage()
    {
        while (true)
        {
            color = GetComponent<Image>().color;
            color.a -= 0.1f;
            if (color.a <= 0f)
            {
                yield break;
            }
            GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeOut(string NextSceneName)
    {
        while (true)
        {
            color = GetComponent<Image>().color;
            color.a += 0.1f;
            if (color.a > 1.0f)
            {
                SceneManager.LoadScene(NextSceneName);
            }
            GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
