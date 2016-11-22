using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeBrickPrefabPanelScript : MonoBehaviour
{

    public GameObject panel;
    public GameObject panelParent;

    private GameObject moveablePanel;
    private List<GameObject> list = new List<GameObject>();

    private int rotateSpeed = 200;

    private bool stopRotate = false;

    void OnMouseOver()
    {
        GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
    }



    void OnMouseDown()
    {
        list = getList(0);
    }

    void OnMouseUp()
    {
        Debug.Log("cleaned");
        stopRotate = false;
        list = new List<GameObject>();
    }

    void OnMouseDrag()
    {

        if (!stopRotate)
        {
            Vector3 resetPosition = transform.position;

            if (Input.GetAxis("Mouse Y") > 0)
            {
                rotateList(list, 0);
            }

            else if (Input.GetAxis("Mouse Y") < 0)
            {
                rotateList(list, 1);
            }

            else if (Input.GetAxis("Mouse X") > 0)
            {
                //Debug.Log("Not yet implemented");
            }

            else if (Input.GetAxis("Mouse X") < 0)
            {
                //Debug.Log("Not yet implemented");
            }

        }

        //Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        //Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //panelParent.transform.rotation = Quaternion.Euler(objPosition);
        //panelParent.transform.position = objPosition;

    }


    private void rotateList(List<GameObject> list, int direction)
    {
        // direction 0 = x; up
        // direction 1 = x; down

        Vector3 startVector = panelParent.transform.position;


        if (list[4] == CameraTrigger.cameraObject)
        {
            Vector3 tmpV = CameraTrigger.cameraObject.transform.position;
            Camera.main.transform.LookAt(tmpV);
        }


        Vector3 rotateVector = list[4].GetComponent<Renderer>().bounds.center;

        foreach (GameObject cubes in list)
        {

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            if (direction == 0)
            {
                cubes.transform.RotateAround(rotateVector, Vector3.right, rotateSpeed * Time.deltaTime);
            }
            else if (direction == 1)
            {
                cubes.transform.RotateAround(rotateVector, Vector3.left, rotateSpeed * Time.deltaTime);
            }
            /*
            if (cubes == panelParent)
            {
                Debug.Log(cubes.transform.rotation.x);
                if(Mathf.Abs(cubes.transform.eulerAngles.x) < 90/2)
                {
                    stopRotate = true;
                    Debug.Log("asdf");
                }
                else
                {
                    Debug.Log("asdfkjklkj");
                }
              
                if (Mathf.Round(cubes.transform.eulerAngles.x) == 90 || Mathf.Round(cubes.transform.eulerAngles.x) == -90 ||
                    cubes.transform.rotation.x == 180 || cubes.transform.rotation.x == -180)
                {
                    Debug.Log("ajskfaskdfjlas");
                    stopRotate = true;

                }
              
            }
            */
            //cubes.transform.rotation = Quaternion.Euler(0,90,0);
            //cubes.transform.rotation = Quaternion.Euler(objPosition);
        }

    }


    private List<GameObject> getList(int direction)
    {

        // direction 0 = x
        // direction 1 = y

        //GameObject mainOb = panelParent;
        List<GameObject> tmp = new List<GameObject>();

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    GameObject tmpCube = RubiksCubePrefab.cubeBrickPrefabMatrix[x][y][z];

                    if (direction == 0)
                    {

                        if (tmpCube.transform.position.x == panelParent.transform.position.x)
                        {
                            tmp.Add(tmpCube);
                        }

                    }
                }
            }
        }


        return tmp;

    }



    private void drawArrows()
    {

        GetComponent<Renderer>().enabled = false;

        Vector3 v3Pos = Camera.main.WorldToViewportPoint(panel.transform.position);

        if (v3Pos.z < Camera.main.nearClipPlane)
            return;  // Object is behind the camera

        if (v3Pos.x >= 0.0f && v3Pos.x <= 1.0f && v3Pos.y >= 0.0f && v3Pos.y <= 1.0f)
            return; // Object center is visible

        GetComponent<Renderer>().enabled = true;
        v3Pos.x -= 0.5f;  // Translate to use center of viewport
        v3Pos.y -= 0.5f;
        v3Pos.z = 0;      // I think I can do this rather than do a 
                          //   a full projection onto the plane

        float fAngle = Mathf.Atan2(v3Pos.x, v3Pos.y);
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, -fAngle * Mathf.Rad2Deg);

        v3Pos.x = 0.5f * Mathf.Sin(fAngle) + 0.5f;  // Place on ellipse touching 
        v3Pos.y = 0.5f * Mathf.Cos(fAngle) + 0.5f;  //   side of viewport
        v3Pos.z = Camera.main.nearClipPlane + 0.01f;  // Looking from neg to pos Z;
        transform.position = Camera.main.ViewportToWorldPoint(v3Pos);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
