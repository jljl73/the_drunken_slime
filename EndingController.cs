using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour
{
    public Button btn;
    public GameObject Credit;
    int order = -1;

    Color t;
    Color tn;

    void Start()
    {
        btn.onClick.AddListener(NextText);
        StartCoroutine(FadeInOut());
    }

    void NextText()
    {
        if (order < transform.childCount - 2)
        {
            StopCoroutine(FadeInOut());
            order++;
            StartCoroutine(FadeInOut());
        }
        else if (order == transform.childCount - 2)
        {
            StartCoroutine(FadeInOutCredit());
        }
    }

    IEnumerator FadeInOut()
    {
        if (order == -1)
            yield return null;

        while (true)
        {
            t = transform.GetChild(order).GetComponent<Text>().color;
            tn = transform.GetChild(order + 1).GetComponent<Text>().color;
            if (t.a > 0.0f)
            {
                t.a -= 0.1f;
                transform.GetChild(order).GetComponent<Text>().color = t;
                yield return new WaitForSeconds(0.1f);
            }
            else if (tn.a < 1.0f)
            {
                tn.a += 0.1f;
                transform.GetChild(order + 1).GetComponent<Text>().color = tn;
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator FadeInOutCredit()
    {
        while (true)
        {
            t = Credit.GetComponent<Image>().color;
            if (t.a < 1.0f)
            {
                t.a += 0.1f;
                Credit.GetComponent<Image>().color = t;
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                yield return new WaitForSeconds(5.0f);
                SceneManager.LoadScene("StartScene");
                //yield return null;
            }
        }
    }
}
