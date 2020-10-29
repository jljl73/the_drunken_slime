using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    Button btn;
    public string NextSceneName;

    bool Finish = false;
    public Image image;
    Color color;
    void Start()
    {
        color = image.color;
        color.a = 1f;
        image.color = color;
        Time.timeScale = 1;

        StopAllCoroutines();
        StartCoroutine(FadeIn());
        btn = GetComponent<Button>();
        btn.onClick.AddListener(NextScene);
    }
    
    void NextScene()
    {
        if(Finish)
            StartCoroutine(FadeOut());

        //SceneManager.LoadScene(NextSceneName);
    }

    IEnumerator FadeIn()
    {
        while (true)
        {
            color = image.color;
            color.a -= 0.1f;
            if (color.a <= 0f)
            {
                Finish = true;
                yield break;
            }
            image.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }
    
    IEnumerator FadeOut()
    {
        while(true)
        {
            color = image.color;
            color.a += 0.1f;
            if (color.a >= 1.0f)
            {
                SceneManager.LoadScene(NextSceneName);
            }
            image.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
