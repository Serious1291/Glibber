using UnityEngine;
using System.Collections;


public class EventTriggerDelegate : MonoBehaviour
{

    // used for look around
    private float horizontalSpeed = 2.0f;
    private float verticalSpeed = 2.0f;
    private float y = 0.0f;
    private float x = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        int zoomChange = 0;

        if (Input.GetButton("Fire2")) { 
            y += horizontalSpeed * Input.GetAxis("Mouse X");
            x -= verticalSpeed * Input.GetAxis("Mouse Y");

            Camera.main.transform.rotation = Quaternion.Euler(x, y, 0.0f);
        }

        // zoom 
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            zoomChange += 1;
            transform.Translate(Vector3.forward * zoomChange);
        } else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            zoomChange -= 1;
            transform.Translate(Vector3.forward * zoomChange);
        }


        // move left and right
        /*
        if (Input.GetKey(KeyCode.Q))
        {
            y = horizontalSpeed - 1;
            Camera.main.transform.rotation = Quaternion.Euler(verticalSpeed, y, 0.0f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            y = horizontalSpeed + 1;
            Camera.main.transform.rotation = Quaternion.Euler(verticalSpeed, y, 0.0f);
        }
        */
    }

}

