using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RubiksCubePrefab : MonoBehaviour {


    public enum sides { FRONT = 0, LEFT = 1, BACK = 2, RIGHT = 3, TOP = 4, BOTTOM = 5 };
    public static Color REDCOLOR { get { return Color.red; } }
    public static Color BLUECOLOR { get { return Color.blue; } }
    public static Color GREENCOLOR { get { return Color.green; } }
    public static Color ORANGECOLOR { get { return new Color(1.0f, 0.5f, 0.0f); } }
    public static Color YELLOWCOLOR { get { return Color.yellow; } }
    public static Color WHITECOLOR { get { return Color.white; } }
    public static Color BLACKCOLOR { get { return Color.black; } }
    List<Color> colors = new List<Color>();
    List<Color> staticColorList = new List<Color>(new Color[] { REDCOLOR, BLUECOLOR, GREENCOLOR, ORANGECOLOR, YELLOWCOLOR, WHITECOLOR });


    public static List<List<List<GameObject>>> cubeBrickPrefabMatrix;

    public RubiksCube RC;
    public GameObject CubeBrickPrefab;
    public float spacing = 1.05f;

    Vector3 cameraResetPos = new Vector3(4.4f, 3.6f, -4.1f);

    // Use this for initialization
    void Start () {

        Camera.main.transform.position = cameraResetPos;
        Camera.main.transform.rotation = Quaternion.Euler(26, -24.6f, 0);
        //Camera.main.transform.LookAt(this.transform.position);

        initCube();

	}

    void Update()
    {
        RefreshPanels();
    }

    private void initCube()
    {
        RC = new RubiksCube();
        int actualCubeNumber = 0;

        cubeBrickPrefabMatrix = new List<List<List<GameObject>>>();
        for (int x = 0; x < 3; x++)
        {
            List<List<GameObject>> PrefabRow = new List<List<GameObject>>();
            for (int y = 0; y < 3; y++)
            {
                List<GameObject> PrefabColumn = new List<GameObject>();
                for (int z = 0; z < 3; z++)
                {
                    //Instantiate(CubeBrickPrefab, new Vector3(x + 0.5f,y + 0.5f,z +0.5f), Quaternion.identity);

                    GameObject cubeBrickPrefab = Instantiate(CubeBrickPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                    
                    cubeBrickPrefab.transform.SetParent(transform.parent);
                    cubeBrickPrefab.transform.position = new Vector3(x, y, z) * spacing;

                    // used for set the main Object, the camera will lookAt
                    if (actualCubeNumber == 14)
                    {
                        CameraTrigger.cameraObject= cubeBrickPrefab;
                    }
                    //Debug.Log(cubeBrickPrefab.GetInstanceID());

                    //setColorForBrickPrefab(cubeBrickPrefab);

                    PrefabColumn.Add(cubeBrickPrefab);
                    actualCubeNumber++;


                }
                PrefabRow.Add(PrefabColumn);
            }
            cubeBrickPrefabMatrix.Add(PrefabRow);
        
        }

    }

    // sets initialise the colors for the cube!
    private void setColorForBrickPrefab(GameObject cubeBrickPrefab)
    {

        int listCounter = 0;
        foreach (Transform ts in cubeBrickPrefab.transform)
        {
            Renderer rend = ts.GetComponent<Renderer>();
            rend.enabled = true;
            rend.material.color = staticColorList[listCounter];
            listCounter++;
        }
    }



    public void setSideColors(List<Color> colors)
    {
        for (int i = 0; i < 6; i++)
        {
            setSideColor((sides)i, colors[i]);
        }
    }

    public void setSideColor(sides side, Color c)
    {
        colors[(int)side] = c;
    }


    public void RefreshPanels()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    cubeBrickPrefabMatrix[x][y][z].GetComponent<CubeBrickPrefab>().refreshPanels(RC.cubeMatrix[x][y][z]);
                }
            }
        }
    }


}
