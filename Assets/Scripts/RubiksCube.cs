using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RubiksCube
{

    public List<List<List<CubeBrick>>> cubeMatrix;

    // Use this for initialization

    public RubiksCube(List<List<List<CubeBrick>>> cubeBrickMatrix)
    {
        this.cubeMatrix = cubeBrickMatrix;

        initColors();

    }

  
    private void initColors()
    {

    }
    
    /*
    for (int i = 0; i< 3; i++)
        {
            for (int j = 0; j< 3; j++)
            {
                cubeMatrix[i][j][0].setSideColor(CubeBrick.sides.FRONT, CubeBrick.REDCOLOR);
    cubeMatrix[2][i][j].setSideColor(CubeBrick.sides.RIGHT, CubeBrick.BLUECOLOR);
    cubeMatrix[0][i][j].setSideColor(CubeBrick.sides.LEFT, CubeBrick.GREENCOLOR);
    cubeMatrix[i][j][2].setSideColor(CubeBrick.sides.BACK, CubeBrick.ORANGECOLOR);
    cubeMatrix[i][2][j].setSideColor(CubeBrick.sides.TOP, CubeBrick.WHITECOLOR);
    cubeMatrix[i][0][j].setSideColor(CubeBrick.sides.BOTTOM, CubeBrick.YELLOWCOLOR);
}
        }
        cubeMatrix[1][1][1].setAllSideColors(CubeBrick.BLACKCOLOR);
*/

    /*

    public RubiksCube()
    {

        cubeMatrix = new List<List<List<CubeBrick>>>();

        for (int x = 0; x < 3; x++)
        {
            List<List<CubeBrick>> CubeRow = new List<List<CubeBrick>>();
            for (int y = 0; y < 3; y++)
            {
                List<CubeBrick> CubeColumn = new List<CubeBrick>();
                for (int z = 0; z < 3; z++)
                {
                    CubeBrick tempcube = new CubeBrick();
                    tempcube.setAllSideColors(CubeBrick.BLACKCOLOR);
                    CubeColumn.Add(tempcube);
                }
                CubeRow.Add(CubeColumn);
            }
            cubeMatrix.Add(CubeRow);
        }

        cubeMatrix[0][0][0].setSideColor(CubeBrick.sides.FRONT, CubeBrick.BLUECOLOR);

        //transform.rotation = Quaternion.Euler(new Vector3(45,0,45));
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                cubeMatrix[i][j][0].setSideColor(CubeBrick.sides.FRONT, CubeBrick.REDCOLOR);
                cubeMatrix[2][i][j].setSideColor(CubeBrick.sides.RIGHT, CubeBrick.BLUECOLOR);
                cubeMatrix[0][i][j].setSideColor(CubeBrick.sides.LEFT, CubeBrick.GREENCOLOR);
                cubeMatrix[i][j][2].setSideColor(CubeBrick.sides.BACK, CubeBrick.ORANGECOLOR);
                cubeMatrix[i][2][j].setSideColor(CubeBrick.sides.TOP, CubeBrick.WHITECOLOR);
                cubeMatrix[i][0][j].setSideColor(CubeBrick.sides.BOTTOM, CubeBrick.YELLOWCOLOR);
            }
        }
        cubeMatrix[1][1][1].setAllSideColors(CubeBrick.BLACKCOLOR);
    }

    */

}

