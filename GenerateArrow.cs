using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateArrow : MonoBehaviour
{
    public Arrow[] arrows;
    private int active_idx = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < arrows.Length; i++)
        {
            arrows[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        arrows[active_idx].gameObject.SetActive(true);
        arrows[active_idx].b_tracing = true;
        active_idx++;
    }
}
