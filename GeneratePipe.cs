using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePipe : MonoBehaviour
{
    public Pipe[] pipes;
    private int active_idx = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame

    void OnMouseDown()
    {
        pipes[active_idx].gameObject.SetActive(true);
        pipes[active_idx].b_tracing = true;
        active_idx++;
    }
}
