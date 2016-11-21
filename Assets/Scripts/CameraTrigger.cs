using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraTrigger : MonoBehaviour
{

    public static Transform cameraObject;

    // used for look around with mouse2
    private float y = 0.0f;
    private float x = 0.0f;

    private static float maxX = 4.5f;
    private static float minX = -4.5f;
    private static float maxY = 5f;
    private static float minY = -4.5f;

    private static float maxZ = 5f;
    private static float minZ = -5f;


    // change fieldOfView with mouse Wheel
    private int zoomSpeed = 10;
    private float minFOV = 35f;
    private float maxFOV = 80f;

    // speed for camera movements at keybindings
    private int cameraSpeed = 100;

    void Start()
    {
        // important that the camera is not reseted 
        x = 26;
        y = -24.6f;
        Camera.main.transform.rotation = Quaternion.Euler(x, y, 0.0f);
    }


    private Vector3 setX(Vector3 tmpVector, float value)
    {

        tmpVector.x += value;
        if (tmpVector.x < minX)
        {
            tmpVector.x = minX;
        }
        else if (tmpVector.x > maxX)
        {
            tmpVector.x = maxX;
        }
        return tmpVector;

    }

    private Vector3 setY(Vector3 tmpVector, float value)
    {

        tmpVector.y += value;
        if (tmpVector.y < minY)
        {
            tmpVector.y = minY;
        }
        else if (tmpVector.y > maxY)
        {
            tmpVector.y = maxY;
        }
        return tmpVector;
    }

    private Vector3 setZ(Vector3 tmpVector, float value)
    {

        tmpVector.z += value;
        if (tmpVector.z < minZ)
        {
            tmpVector.z = minZ;
        }
        else if (tmpVector.z > maxZ)
        {
            tmpVector.z = maxZ;
        }
        return tmpVector;
    }

    void Update()
    {

        // esc for calling the menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(2);
        }

        if (Input.GetButton("Fire2"))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 tmpVector = Camera.main.transform.position;
            tmpVector = setX(tmpVector, mouseX);
            tmpVector = setY(tmpVector, mouseY);

            Camera.main.transform.position = tmpVector;
        }

        if (Input.GetButton("Fire2"))
        {
            y += 2.0f * Input.GetAxis("Mouse X");
            x -= 2.0f * Input.GetAxis("Mouse Y");

            Camera.main.transform.rotation = Quaternion.Euler(x, y, 0.0f);

        }

        // fov

        // zoom in
        float delta = Input.GetAxis("Mouse ScrollWheel") * -zoomSpeed;
        if (delta < 0)
        {
            // make sure the current FOV is within min values
            if (Camera.main.fieldOfView + delta > minFOV-1)
            {
                Camera.main.fieldOfView = Camera.main.fieldOfView + delta;
            }
        }
        // zoom out
        else if (delta > 0)
        {
            // make sure the current FOV is within max values
            if (Camera.main.fieldOfView + delta < maxFOV+1)
            {
                Camera.main.fieldOfView = Camera.main.fieldOfView + delta;
            }
        }


        // define way around cube:
        

        // move left and right and top and bot
        // this is not smooth if the camera is moved around 30-40°

        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(cameraObject.transform.position, Vector3.up, cameraSpeed * Time.deltaTime);
            //transform.Translate(Vector3.right * -Time.deltaTime * zoomSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(cameraObject.transform.position, Vector3.down, cameraSpeed * Time.deltaTime);
            //transform.Translate(Vector3.right * Time.deltaTime * zoomSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.RotateAround(cameraObject.transform.position, Vector3.right, cameraSpeed * Time.deltaTime);
            //transform.Translate(Vector3.up * Time.deltaTime * zoomSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.RotateAround(cameraObject.transform.position, Vector3.left, cameraSpeed * Time.deltaTime);
            //transform.Translate(Vector3.down * Time.deltaTime * zoomSpeed);
        }

        Camera.main.transform.LookAt(cameraObject);

    }

}

