﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeData : MonoBehaviour
{
    // Start is called before the first frame update
    public int inSlot;
    private int days, health, waterStorage, foodStorage, hunger, thirst;

    void Start()
    {
        init(PlayerPrefs.GetInt("currentGame"));
    }

    public void init(int loadSlot)
    {
        inSlot = loadSlot;
        days = PlayerPrefs.GetInt("sl" + loadSlot + "d");
        health = PlayerPrefs.GetInt("sl" + loadSlot + "p");
        waterStorage = PlayerPrefs.GetInt("sl" + loadSlot + "a");
        foodStorage = PlayerPrefs.GetInt("sl" + loadSlot + "o");
        hunger = PlayerPrefs.GetInt("sl" + loadSlot + "u");
        thirst = PlayerPrefs.GetInt("sl" + loadSlot + "h");
    }

    public int getVal(string valueName)
    {
        if (valueName == "d")
        {
            return days;
        }
        else if (valueName == "p")
        {
            return health;
        }
        else if (valueName == "a")
        {
            return waterStorage;
        }
        else if (valueName == "o")
        {
            return foodStorage;
        }
        else if (valueName == "u")
        {
            return hunger;
        }
        else if (valueName == "h")
        {
            return thirst;
        }
        else
        {
            return 0;
        }
    }

    public void setVal(string valueName, int value)
    {
        if (valueName == "d")
        {
            days = value;
        }
        else if (valueName == "p")
        {
            health = value;
        }
        else if (valueName == "a")
        {
            waterStorage = value;
        }
        else if (valueName == "o")
        {
            foodStorage = value;
        }
        else if (valueName == "u")
        {
            hunger = value;
        }
        else if (valueName == "h")
        {
            thirst = value;
        }
    }

    public void saveData()
    {
        PlayerPrefs.SetInt("sl" + inSlot + "d", days);
        PlayerPrefs.SetInt("sl" + inSlot + "p", health);
        PlayerPrefs.SetInt("sl" + inSlot + "a", waterStorage);
        PlayerPrefs.SetInt("sl" + inSlot + "o", foodStorage);
        PlayerPrefs.SetInt("sl" + inSlot + "u", hunger);
        PlayerPrefs.SetInt("sl" + inSlot + "h", thirst);
    }
}