﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class datacontrol : MonoBehaviour
{

    public GameObject sl1ti, sl1de, sl2ti, sl2de, sl3ti, sl3de;  //SLot1Title, SLot1DEscription
    Text s1titxt, s1detxt, s2titxt, s2detxt, s3titxt, s3detxt;   //Slot1TItleTeXT
    public bool clearGamePrefs;
    private bool inDeleteMode;

    void Awake()
    {
        if (clearGamePrefs)
        { PlayerPrefs.DeleteAll(); }
        inDeleteMode = false;
        //createGame(1, "hi");
    }

    public void setslotvals()
    {
        s1titxt = sl1ti.GetComponent<Text>();
        s2titxt = sl2ti.GetComponent<Text>();
        s3titxt = sl3ti.GetComponent<Text>();
        s1detxt = sl1de.GetComponent<Text>();
        s2detxt = sl2de.GetComponent<Text>();
        s3detxt = sl3de.GetComponent<Text>();

        s1titxt.text = "存檔一 " + PlayerPrefs.GetString("pps1ttln"); //playerprefsslot1titlename
        s2titxt.text = "存檔二 " + PlayerPrefs.GetString("pps2ttln");
        s3titxt.text = "存檔三 " + PlayerPrefs.GetString("pps3ttln");
        if (PlayerPrefs.GetString("pps1ttln") == "") { s1detxt.text = "展開一場新的生存冒險!"; }
        else { s1detxt.text = "第" + PlayerPrefs.GetInt("sl1d") + "天 " + "生命值剩餘: " + PlayerPrefs.GetInt("sl1h"); }
        if (PlayerPrefs.GetString("pps2ttln") == "") { s2detxt.text = "展開一場新的生存冒險!"; }
        else { s2detxt.text = "第" + PlayerPrefs.GetInt("sl2d") + "天 " + "生命值剩餘: " + PlayerPrefs.GetInt("sl2h"); }
        if (PlayerPrefs.GetString("pps3ttln") == "") { s3detxt.text = "展開一場新的生存冒險!"; }
        else { s3detxt.text = "第" + PlayerPrefs.GetInt("sl3d") + "天 " + "生命值剩餘: " + PlayerPrefs.GetInt("sl3h"); }
    }

    public void swapToDeleteTitles()
    {
        s1titxt.text = "刪除存檔一";
        s2titxt.text = "刪除存檔二";
        s3titxt.text = "刪除存檔三";
    }

    public void clickedSlot1()
    {
        if (inDeleteMode)
        {
            wipeSlot(1);
            GetComponent<menuController>().trashbinClicked();
        }
        else
        {
            if (PlayerPrefs.GetString("pps1ttln") == "")
            {
                GetComponent<menuController>().createNewSlot(1);
            }
            else
            {
                startGame(1);
            }
        }
    }

    public void clickedSlot2()
    {
        if (inDeleteMode)
        {
            wipeSlot(2);
            GetComponent<menuController>().trashbinClicked();
        }
        else
        {
            if (PlayerPrefs.GetString("pps2ttln") == "")
            {
                GetComponent<menuController>().createNewSlot(2);
            }
            else
            {
                startGame(2);
            }
        }
    }

    public void clickedSlot3()
    {
        if (inDeleteMode)
        {
            wipeSlot(3);
            GetComponent<menuController>().trashbinClicked();
        }
        else
        {
            if (PlayerPrefs.GetString("pps3ttln") == "")
            {
                GetComponent<menuController>().createNewSlot(3);
            }
            else
            {
                startGame(3);
            }
        }
    }

    public void wipeSlot(int saveslot)
    {
        PlayerPrefs.DeleteKey("pps" + saveslot + "ttln");
        PlayerPrefs.DeleteKey("sl" + saveslot + "d");
        PlayerPrefs.DeleteKey("sl" + saveslot + "h");
        PlayerPrefs.DeleteKey("sl" + saveslot + "f");
        PlayerPrefs.DeleteKey("sl" + saveslot + "w");
    }

    public void createGame(int saveslot, string nameselected)
    {
        PlayerPrefs.SetString("pps" + saveslot + "ttln", nameselected);
        PlayerPrefs.SetInt("sl" + saveslot + "d", 1);
        PlayerPrefs.SetInt("sl" + saveslot + "h", 100);
        PlayerPrefs.SetInt("sl" + saveslot + "f", 100);
        PlayerPrefs.SetInt("sl" + saveslot + "w", 100);
        startGame(saveslot);
    }

    public void startGame(int saveslot)
    {
        Debug.Log("called");
        PlayerPrefs.SetInt("currentGame", saveslot);
        SceneManager.LoadScene(sceneName: "maincave");
        /*Debug.Log("StartGame info");
        Debug.Log(PlayerPrefs.GetString("pps" + saveslot + "ttln"));
        Debug.Log(PlayerPrefs.GetInt("sl" + saveslot + "d"));
        Debug.Log(PlayerPrefs.GetInt("sl" + saveslot + "h"));
        Debug.Log(PlayerPrefs.GetInt("sl" + saveslot + "f"));
        Debug.Log(PlayerPrefs.GetInt("sl" + saveslot + "w"));*/
    }

    public void trashBinOpen()
    {
        inDeleteMode = true;
        swapToDeleteTitles();
    }

    public void trashBinClose()
    {
        inDeleteMode = false;
        setslotvals();
    }

}