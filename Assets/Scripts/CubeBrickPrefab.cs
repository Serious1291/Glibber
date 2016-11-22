﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class CubeBrickPrefab : MonoBehaviour
{

    public List<GameObject> panels = new List<GameObject>();

    public void refreshPanels(CubeBrick c)
    {
        for (int i = 0; i < 6; i++)
        {
            Renderer rend = panels[i].GetComponent<Renderer>();
            rend.enabled = true;
            rend.material.color = c.getColors()[i];
        }
    }

    void OnMouseDown()
    {
        //Debug.Log("Hallo");
    }

    void update()
    {

    }


}

