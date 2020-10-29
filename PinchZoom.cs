using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    // Update is called once per frame
    public float perspectiveZoomSpeed = 0.5f;
    public float orthoZoomSpeed = 0.5f;

    Vector2 nowpos, touchPrevPosition;
    Vector3 movepos;

    Vector3 Temp;
    void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                touchPrevPosition = touch.position - touch.deltaPosition;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                nowpos = touch.position - touch.deltaPosition;
                movepos = (Vector3)(touchPrevPosition - nowpos) * 0.01f;
                Temp = GetComponent<Camera>().transform.position + (movepos);
                Temp.x = Mathf.Clamp(movepos.x, -11.1f, 11.1f);
                Temp.y = Mathf.Clamp(movepos.y, -3.65f, 3.65f);
                GetComponent<Camera>().transform.position = Temp;
                touchPrevPosition = touch.position - touch.deltaPosition;
            }

        }

        else if(Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            Vector2 touch1PrevPosition = touch1.position - touch1.deltaPosition;
            Vector2 touch2PrevPosition = touch2.position - touch2.deltaPosition;

            float prevTouchDeltaMag = (touch1PrevPosition - touch2PrevPosition).magnitude;
            float touchDeltaMag = (touch1.position - touch2.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            if(GetComponent<Camera>().orthographic)
            {
                Camera.main.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
                Camera.main.orthographicSize = Mathf.Max(GetComponent<Camera>().orthographicSize, 4f);
                Camera.main.orthographicSize = Mathf.Min(GetComponent<Camera>().orthographicSize, 8f);
            }
        }
    }
}
