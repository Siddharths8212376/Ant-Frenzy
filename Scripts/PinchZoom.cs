using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    public float perspectiveZoomSpeed = 0.5f;
    public float orthoZoomSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Touch touchZero = Input.GetTouch(0);
        //Touch touchOne = Input.GetTouch(1);

        //Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
       // Vector2 touchOnePrevPos = touchOne.position - touchZero.deltaPosition;

       // float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
       // float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

       // float deltaMagnitudediff = prevTouchDeltaMag - touchDeltaMag;

       // if (GetComponent<Camera>().orthographic)
       // {
        //    GetComponent<Camera>().orthographicSize += deltaMagnitudediff * orthoZoomSpeed;
        //    GetComponent<Camera>().orthographicSize = Mathf.Max(GetComponent<Camera>().orthographicSize, 0.1f);
       // }
       // else
       // {
        //    GetComponent<Camera>().fieldOfView += deltaMagnitudediff * perspectiveZoomSpeed;
       //     GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, 0.1f, 179.9f);
       // }
    }
}
