using UnityEngine;
using System.Collections;


public class CameraTrigger : MonoBehaviour
{

    // used for look around
    private float horizontalSpeed = 2.0f;
    private float verticalSpeed = 2.0f;
    private float y = 0.0f;
    private float x = 0.0f;

    void Start()
    {
        // important that the camera is not reseted 
        x = 26;
        y= -24.6f;
        Camera.main.transform.rotation = Quaternion.Euler(x, y, 0.0f);
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


        // move left and right and top and bot
        // this is not smooth if the camera is moved around 30-40°
        
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 tmpVector = Camera.main.transform.position;
            tmpVector.x -= 0.4f;
            Camera.main.transform.position = tmpVector;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 tmpVector = Camera.main.transform.position;
            tmpVector.x += 0.4f;
            Camera.main.transform.position = tmpVector;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 tmpVector = Camera.main.transform.position;
            tmpVector.z += 0.4f;
            Camera.main.transform.position = tmpVector;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 tmpVector = Camera.main.transform.position;
            tmpVector.z -= 0.4f;
            Camera.main.transform.position = tmpVector;
        }

    }

}

