using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CubeBrickPrefabPanelScript : MonoBehaviour
{

    public GameObject panel;
    public GameObject panelParent;

    private GameObject moveablePanel;
    private List<GameObject> list = new List<GameObject>();
    private static List<Vector3> startPositionList = new List<Vector3>();
    private static List<Quaternion> startRotationList = new List<Quaternion>();

    private int rotateSpeed = 200;

    private bool stopRotate = false;
    private bool rotationEnded = false;

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
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;

    }

    void OnMouseUp()
    {

        if (!rotationEnded)
        {
            resetRotation();
        }

        Debug.Log("cleaned");
        stopRotate = false;
        firstDrag = true;
        rotationEnded = false;
        rotateInt = 0; 
        list = new List<GameObject>();
        startPositionList = new List<Vector3>();
        startRotationList= new List<Quaternion>();

    }


    float x = 0;
    float y = 0;

    int getDirection()
    {

        if (x < Input.mousePosition.x)
        {
            // rotate down
            Debug.Log("Moved Right");
            return 0;
        }
        else if (x > Input.mousePosition.x)
        {
            // rotate up
            Debug.Log("Moved Left");
            return 1;
        }
        else if (y < Input.mousePosition.y)
        {
            // rotate left: 
            Debug.Log("Moved Up");
            return 2;
        }
        else if (y > Input.mousePosition.y)
        {
            // rotate right: 
            Debug.Log("Moved Down");
            return 3;
        }
        return -1;

    }

    bool firstDrag = true;
    private static int directionWay;

    void OnMouseDrag()
    {
        if (firstDrag)
        {
            int counter = getDirection();
            if (counter != -1)
            {
                Debug.Log(counter);
                if (counter == 0 || counter == 1)
                {
                    list = getList(1);
                }
                else
                {
                    list = getList(0);
                }
                
                // get start positions: 
                foreach(GameObject ob in list)
                {
                    startPositionList.Add(ob.transform.position);
                    startRotationList.Add(ob.transform.rotation);
                }

                directionWay = counter;
                firstDrag = false;
            }
            /*
            foreach(GameObject ob in list)
            {
                Debug.Log(ob.GetInstanceID());
            }
            */
        }

        if (!stopRotate && !firstDrag)
        {
            Vector3 resetPosition = transform.position;

            if(directionWay == 2 || directionWay == 3)
            {
                if (Input.GetAxis("Mouse X") > 0)
                {
                    rotateList(list, 0);
                }

                else if (Input.GetAxis("Mouse X") < 0)
                {
                    rotateList(list, 1);
                }
            }


            else 
            {
                if (Input.GetAxis("Mouse Y") > 0)
                {
                    rotateList(list, 2);
                }
                else if (Input.GetAxis("Mouse Y") < 0)
                {
                    rotateList(list, 3);
                }

            }

        }

    }

    private static int rotateInt = 0; 

    private void rotateList(List<GameObject> list, int direction)
    {
        // direction 0 = x; up
        // direction 1 = x; down




        if (list[4] == CameraTrigger.cameraObject)
        {
            Vector3 tmpV = CameraTrigger.cameraObject.transform.position;
            Camera.main.transform.LookAt(tmpV);
        }


        Vector3 rotateVector = list[4].GetComponent<Renderer>().bounds.center;


        bool isPositiv = true;
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
                isPositiv = false;
            }
            else if (direction == 2)
            {
                cubes.transform.RotateAround(rotateVector, Vector3.up, rotateSpeed * Time.deltaTime);
            }
            else if (direction == 3)
            {
                cubes.transform.RotateAround(rotateVector, Vector3.down, rotateSpeed * Time.deltaTime);
                isPositiv = false;
            }

            // set them to a good position:
            float tmpX = (float)Math.Round(cubes.transform.position.x, 2);
            float tmpY = (float)Math.Round(cubes.transform.position.y, 2);
            float tmpZ = (float)Math.Round(cubes.transform.position.z, 2);
            cubes.transform.position = new Vector3(tmpX, tmpY, tmpZ);

        }
        if (isPositiv)
        {
            rotateInt++;
        } else
        {
            rotateInt--;
        }
        Debug.Log(rotateInt);

        if (Mathf.Abs(rotateInt) == 25)
        {
            Debug.Log("90Grad");
            if (directionWay == 0 || directionWay == 1)
            {
                Debug.Log("Rotate Y");
                if(rotateInt < 0)
                {
                    endRotationY(-45);
                }
                else
                {
                    endRotationY(45);
                }
                
            }
            else
            {
                if (rotateInt < 0)
                {
                    endRotationX(-45);
                }
                else
                {
                    endRotationX(45);
                }
            }
            rotationEnded = true;
            stopRotate = true;
        }

    }



    static int directedYa = 0;
    static int directedYb = 0;
    private void endRotationY(int direction)
    {
        direction *= 2;


        if (direction <= 0)
        {
            if (directedYa == 1)
            {
                direction = direction * 2;
            }
            else if (directedYa == 2)
            {
                direction = direction * 3;
            }
            else if (directedYa == 3)
            {
                direction = 0;
            }
            directedYa++;
            if (directedYa == 4)
            {
                directedYa = 0;
            }
            direction = direction + (90 * directedYb);
            // move right
            Vector3 tasdf = startPositionList[6];
            list[0].transform.position = tasdf;
            list[0].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[3];
            list[1].transform.position = tasdf;
            list[1].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[0];
            list[2].transform.position = tasdf;
            list[2].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[7];
            list[3].transform.position = tasdf;
            list[3].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[4];
            list[4].transform.position = tasdf;
            list[4].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[1];
            list[5].transform.position = tasdf;
            list[5].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[8];
            list[6].transform.position = tasdf;
            list[6].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[5];
            list[7].transform.position = tasdf;
            list[7].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[2];
            list[8].transform.position = tasdf;
            list[8].transform.rotation = Quaternion.Euler(0, direction, 0);
        }
        else
        {
            if (directedYb == 1)
            {
                direction = direction * 2;
            }
            else if (directedYb == 2)
            {
                direction = direction * 3;
            }
            else if (directedYb == 3)
            {
                direction = 0;
            }
            directedYb++;
            if (directedYb == 4)
            {
                directedYb = 0;
            }
            direction = direction + (90 * -directedYa);
            Debug.Log(direction);
            // move left
            Vector3 tasdf = startPositionList[2];
            list[0].transform.position = tasdf;
            list[0].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[5];
            list[1].transform.position = tasdf;
            list[1].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[8];
            list[2].transform.position = tasdf;
            list[2].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[1];
            list[3].transform.position = tasdf;
            list[3].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[4];
            list[4].transform.position = tasdf;
            list[4].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[7];
            list[5].transform.position = tasdf;
            list[5].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[0];
            list[6].transform.position = tasdf;
            list[6].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[3];
            list[7].transform.position = tasdf;
            list[7].transform.rotation = Quaternion.Euler(0, direction, 0);
            tasdf = startPositionList[6];
            list[8].transform.position = tasdf;
            list[8].transform.rotation = Quaternion.Euler(0, direction, 0);

        }
    }



    static int directedXa = 0;
    static int directedXb = 0;
    private void endRotationX(int direction)
    {
        direction *= 2;

        if (direction <= 0)
        {
            if (directedXa == 1)
            {
                direction = direction * 2;
            }
            else if (directedXa == 2)
            {
                direction = direction * 3;
            }
            else if (directedXa == 3)
            {
                direction = 0;
            }
            directedXa++;
            if (directedXa == 4)
            {
                directedXa = 0;
            }
            direction = direction + (90 * directedXb);
            // move up
            Vector3 tasdf = startPositionList[2];
            list[0].transform.position = tasdf;
            list[0].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[5];
            list[1].transform.position = tasdf;
            list[1].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[8];
            list[2].transform.position = tasdf;
            list[2].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[1];
            list[3].transform.position = tasdf;
            list[3].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[4];
            list[4].transform.position = tasdf;
            list[4].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[7];
            list[5].transform.position = tasdf;
            list[5].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[0];
            list[6].transform.position = tasdf;
            list[6].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[3];
            list[7].transform.position = tasdf;
            list[7].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[6];
            list[8].transform.position = tasdf;
            list[8].transform.rotation = Quaternion.Euler(direction, 0, 0);
        }
        else
        {
            if (directedXb == 1)
            {
                direction = direction * 2;
            }
            else if (directedXb == 2)
            {
                direction = direction * 3;
            }
            else if (directedXb == 3)
            {
                direction = 0;
            }
            directedXb++;
            if (directedXb == 4)
            {
                directedXb = 0;
            }
            direction = direction + (90 * -directedXa);
            // move down
            Vector3 tasdf = startPositionList[6];
            list[0].transform.position = tasdf;
            list[0].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[3];
            list[1].transform.position = tasdf;
            list[1].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[0];
            list[2].transform.position = tasdf;
            list[2].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[7];
            list[3].transform.position = tasdf;
            list[3].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[4];
            list[4].transform.position = tasdf;
            list[4].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[1];
            list[5].transform.position = tasdf;
            list[5].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[8];
            list[6].transform.position = tasdf;
            list[6].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[5];
            list[7].transform.position = tasdf;
            list[7].transform.rotation = Quaternion.Euler(direction, 0, 0);
            tasdf = startPositionList[2];
            list[8].transform.position = tasdf;
            list[8].transform.rotation = Quaternion.Euler(direction, 0, 0);

        }
    }

    private void resetRotation()
    {
        int i = 0;
        foreach(GameObject ob in list)
        {
            Debug.Log(startPositionList[i]);
            ob.transform.position = startPositionList[i];
            ob.transform.rotation = startRotationList[i];
            i++;
        }
        Debug.Log("reseted");
    }



    private List<GameObject> getList(int direction)
    {
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
                    else if (direction == 1)
                    {
                        if (tmpCube.transform.position.y == panelParent.transform.position.y)
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

}
