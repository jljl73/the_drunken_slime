using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnArrow : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject parent;
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    void FixedUpdate()
    {
        if (GameManager.instance.Starting || parent.GetComponent<ObjectController>().b_fixed)
            this.gameObject.SetActive(false);
    }


    void OnMouseUp()
    {
        parent.transform.GetChild(0).GetComponent<Arrow>().TurnArrow();
    }
}
