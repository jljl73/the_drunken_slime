using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIcon : MonoBehaviour
{
    public bool Deployed;
    public int idx = -1;
    public GameObject point;
    public GameObject slime;

    public void DestroyObject()
    {
        if (Deployed)
        {
            point.GetComponent<Point>().m_active = false;
            transform.parent.GetComponent<ImageClick>().SlimeNumbers[idx]++;
            Destroy(this.gameObject);
            Destroy(slime);
        }
    }
}
