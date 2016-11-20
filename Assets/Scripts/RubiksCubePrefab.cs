using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RubiksCubePrefab : MonoBehaviour {

    private List<List<List<GameObject>>> cubeBrickPrefabMatrix;

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
        //RefreshPanels();
    }

    private void initCube()
    {
        //RC = new RubiksCube();

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

                    //Debug.Log(cubeBrickPrefab.GetComponent<Renderer>());
                    GameObject childOne = cubeBrickPrefab.transform.GetChild(0).gameObject;
                    Renderer rend = childOne.GetComponent<Renderer>();

                    rend.enabled = true;
                    rend.material.color = CubeBrick.GREENCOLOR;
                    PrefabColumn.Add(cubeBrickPrefab);
                    
                }
                PrefabRow.Add(PrefabColumn);
            }
            cubeBrickPrefabMatrix.Add(PrefabRow);
        
        }

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
