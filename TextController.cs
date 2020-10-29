using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public GameObject text;

    void Start()
    {
        text.SetActive(false);
        StartCoroutine(ShowReady());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowReady()
    {
        while (true)
        {
            text.SetActive(true);
            yield return new WaitForSeconds(0.8f);
            text.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
