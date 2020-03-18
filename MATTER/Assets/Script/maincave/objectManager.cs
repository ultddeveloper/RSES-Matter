﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectManager : MonoBehaviour
{
    public List<GameObject> allObjs;
    public List<int> caveObjects;
    int counter;

    void Start()
    {
        caveObjects.Add(1); //amulet id:1
        caveObjects.Add(1); //axe id:2
        caveObjects.Add(1); //book id:3
        caveObjects.Add(1); //cabinet id:4
        caveObjects.Add(1); //energyDrink id:5
        caveObjects.Add(1); //firstAid id:6
        caveObjects.Add(1); //flashLight id:7
        caveObjects.Add(1); //food id:8
        caveObjects.Add(1); //hypePills id:9
        caveObjects.Add(1); //mushroom id:10
        caveObjects.Add(1); //rifle id:11
        caveObjects.Add(1); //solveFlower id:12
        caveObjects.Add(1); //wallPic id:13
        caveObjects.Add(1); //water id:14
    }

    void Update()
    {
        counter += 1;
        if (counter == 60)
        {
            for (int i = 0; i < allObjs.Count; i++)
            {
                if (caveObjects[i] == 0)
                {
                    allObjs[i].SetActive(false);
                }
                else
                {
                    allObjs[i].SetActive(true);
                }
            }
            counter = 0;
        }
    }

    public int returnObjsVal(int objectID)
    {
        return caveObjects[objectID - 1];
    }

    public void setObjsVal(int objectID, int newValue)
    {
        caveObjects[objectID - 1] = newValue;
    }
}