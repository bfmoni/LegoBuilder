﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Canvas mainCanvas;
    //public GameObject UIpanel;
    public GameObject menuPanel;
    public GameObject legoPanel;
    public Button menuButton;
    public Button legoButton;
    public Button undoButton;
    public Button zoomInButton;
    public Button zoomOutButton;
    public Button onex1;
    public Button onex2;
    public Button onex3;
    public Button onex4;
    public Button onex6;
    public Button onex8;
    public Button twox2;
    public Button twox3;
    public Button twox4;
    public Button twox6;
    public Button twox8;
    public Button lblock;
    public Camera vision;

    UnityEngine.Color black = new Color32(39, 39, 39, 100);
    UnityEngine.Color clear = new Color32(39, 39, 39, 0);
    UnityEngine.Color purple = new Color32(180, 104, 236, 100);

    public static bool menuMode;
    float timer;
    public static int selectedBlock;

    void Start()
    {
        timer = 0;
        selectedBlock = 0;
        HideMainMenu();
        HideLegoMenu();

    }


    void Update()
    {
        timer += Time.deltaTime;

        if(!PlayerMovement.lego_selected)
        {
            if(Input.GetButtonUp("Y"))
            {
                if(!menuMode)
                {
                    EnterMenuMode();
                }
                else if(!menuPanel.activeInHierarchy & !legoPanel.activeInHierarchy)
                {
                    SwapMenu();
                }
            }
            else if(Input.GetButtonUp("A") & menuMode)
            {
                ExitMenuMode();
            }
            else if(Input.GetButtonUp("B") & menuMode)
            {
                if(menuPanel.activeInHierarchy)
                {
                    //TODO: MENU PANEL FUNCTION
                }
                else if(legoPanel.activeInHierarchy)
                {
                    SelectLego();
                }
                else
                {
                    SelectMenu();
                }
                
            }

            var temp1 = Input.GetAxis("Horizontal");
            var temp2 = Input.GetAxis("Vertical");

            if((temp1 != 0 | temp2 != 0) & timer > 0.5 & legoPanel.activeInHierarchy)
            {
                timer = 0;
                if(Mathf.Abs(temp1) > Mathf.Abs(temp2))
                {
                    if(temp1 > 0)
                    {
                        SwapLegoHorizontalR();
                    }
                    else
                    {
                        SwapLegoHorizontalL();
                    }
                }
                else
                {
                    SwapLegoVertical();
                }
            }

        }
    }

    public void SelectLego()
    {
        if(onex1.GetComponent<Image>().color != clear)
        {
            selectedBlock = 0;
        }
        else if(onex2.GetComponent<Image>().color != clear)
        {
            selectedBlock = 1;
        }
        else if(onex3.GetComponent<Image>().color != clear)
        {
            selectedBlock = 2;
        }
        else if(onex4.GetComponent<Image>().color != clear)
        {
            selectedBlock = 3;
        }
        else if(onex6.GetComponent<Image>().color != clear)
        {
            selectedBlock = 4;
        }
        else if(onex8.GetComponent<Image>().color != clear)
        {
            selectedBlock = 5;
        }
        else if(twox2.GetComponent<Image>().color != clear)
        {
            selectedBlock = 6;
        }
        else if(twox3.GetComponent<Image>().color != clear)
        {
            selectedBlock = 7;
        }
        else if(twox4.GetComponent<Image>().color != clear)
        {
            selectedBlock = 8;
        }
        else if(twox6.GetComponent<Image>().color != clear)
        {
            selectedBlock = 9;
        }
        else if(twox8.GetComponent<Image>().color != clear)
        {
            selectedBlock = 10;
        }
        else if(lblock.GetComponent<Image>().color != clear)
        {
            selectedBlock = 11;
        }
        ExitMenuMode();
    }

    public void SwapLegoHorizontalR()
    {
        if(onex1.GetComponent<Image>().color != clear)
        {
            onex1.GetComponent<Image>().color = clear;
            onex2.GetComponent<Image>().color = purple;
        }
        else if(onex2.GetComponent<Image>().color != clear)
        {
            onex2.GetComponent<Image>().color = clear;
            onex3.GetComponent<Image>().color = purple;
        }
        else if(onex3.GetComponent<Image>().color != clear)
        {
            onex3.GetComponent<Image>().color = clear;
            onex4.GetComponent<Image>().color = purple;
        }
        else if(onex4.GetComponent<Image>().color != clear)
        {
            onex4.GetComponent<Image>().color = clear;
            onex6.GetComponent<Image>().color = purple;
        }
        else if(onex6.GetComponent<Image>().color != clear)
        {
            onex6.GetComponent<Image>().color = clear;
            onex8.GetComponent<Image>().color = purple;
        }
        else if(onex8.GetComponent<Image>().color != clear)
        {
            onex8.GetComponent<Image>().color = clear;
            onex1.GetComponent<Image>().color = purple;
        }
        else if(twox2.GetComponent<Image>().color != clear)
        {
            twox2.GetComponent<Image>().color = clear;
            twox3.GetComponent<Image>().color = purple;
        }
        else if(twox3.GetComponent<Image>().color != clear)
        {
            twox3.GetComponent<Image>().color = clear;
            twox4.GetComponent<Image>().color = purple;
        }
        else if(twox4.GetComponent<Image>().color != clear)
        {
            twox4.GetComponent<Image>().color = clear;
            twox6.GetComponent<Image>().color = purple;
        }
        else if(twox6.GetComponent<Image>().color != clear)
        {
            twox6.GetComponent<Image>().color = clear;
            twox8.GetComponent<Image>().color = purple;
        }
        else if(twox8.GetComponent<Image>().color != clear)
        {
            twox8.GetComponent<Image>().color = clear;
            lblock.GetComponent<Image>().color = purple;
        }
        else if(lblock.GetComponent<Image>().color != clear)
        {
            lblock.GetComponent<Image>().color = clear;
            twox2.GetComponent<Image>().color = purple;
        }
    }

    public void SwapLegoHorizontalL()
    {
        if(onex1.GetComponent<Image>().color != clear)
        {
            onex1.GetComponent<Image>().color = clear;
            onex8.GetComponent<Image>().color = purple;
        }
        else if(onex2.GetComponent<Image>().color != clear)
        {
            onex2.GetComponent<Image>().color = clear;
            onex1.GetComponent<Image>().color = purple;
        }
        else if(onex3.GetComponent<Image>().color != clear)
        {
            onex3.GetComponent<Image>().color = clear;
            onex2.GetComponent<Image>().color = purple;
        }
        else if(onex4.GetComponent<Image>().color != clear)
        {
            onex4.GetComponent<Image>().color = clear;
            onex3.GetComponent<Image>().color = purple;
        }
        else if(onex6.GetComponent<Image>().color != clear)
        {
            onex6.GetComponent<Image>().color = clear;
            onex4.GetComponent<Image>().color = purple;
        }
        else if(onex8.GetComponent<Image>().color != clear)
        {
            onex8.GetComponent<Image>().color = clear;
            onex6.GetComponent<Image>().color = purple;
        }
        else if(twox2.GetComponent<Image>().color != clear)
        {
            twox2.GetComponent<Image>().color = clear;
            lblock.GetComponent<Image>().color = purple;
        }
        else if(twox3.GetComponent<Image>().color != clear)
        {
            twox3.GetComponent<Image>().color = clear;
            twox2.GetComponent<Image>().color = purple;
        }
        else if(twox4.GetComponent<Image>().color != clear)
        {
            twox4.GetComponent<Image>().color = clear;
            twox3.GetComponent<Image>().color = purple;
        }
        else if(twox6.GetComponent<Image>().color != clear)
        {
            twox6.GetComponent<Image>().color = clear;
            twox4.GetComponent<Image>().color = purple;
        }
        else if(twox8.GetComponent<Image>().color != clear)
        {
            twox8.GetComponent<Image>().color = clear;
            twox6.GetComponent<Image>().color = purple;
        }
        else if(lblock.GetComponent<Image>().color != clear)
        {
            lblock.GetComponent<Image>().color = clear;
            twox8.GetComponent<Image>().color = purple;
        }
    }

    public void SwapLegoVertical()
    {
        if(onex1.GetComponent<Image>().color != clear)
        {
            onex1.GetComponent<Image>().color = clear;
            twox2.GetComponent<Image>().color = purple;
        }
        else if(onex2.GetComponent<Image>().color != clear)
        {
            onex2.GetComponent<Image>().color = clear;
            twox3.GetComponent<Image>().color = purple;
        }
        else if(onex3.GetComponent<Image>().color != clear)
        {
            onex3.GetComponent<Image>().color = clear;
            twox4.GetComponent<Image>().color = purple;
        }
        else if(onex4.GetComponent<Image>().color != clear)
        {
            onex4.GetComponent<Image>().color = clear;
            twox6.GetComponent<Image>().color = purple;
        }
        else if(onex6.GetComponent<Image>().color != clear)
        {
            onex6.GetComponent<Image>().color = clear;
            twox8.GetComponent<Image>().color = purple;
        }
        else if(onex8.GetComponent<Image>().color != clear)
        {
            onex8.GetComponent<Image>().color = clear;
            lblock.GetComponent<Image>().color = purple;
        }
        else if(twox2.GetComponent<Image>().color != clear)
        {
            twox2.GetComponent<Image>().color = clear;
            onex1.GetComponent<Image>().color = purple;
        }
        else if(twox3.GetComponent<Image>().color != clear)
        {
            twox3.GetComponent<Image>().color = clear;
            onex2.GetComponent<Image>().color = purple;
        }
        else if(twox4.GetComponent<Image>().color != clear)
        {
            twox4.GetComponent<Image>().color = clear;
            onex3.GetComponent<Image>().color = purple;
        }
        else if(twox6.GetComponent<Image>().color != clear)
        {
            twox6.GetComponent<Image>().color = clear;
            onex4.GetComponent<Image>().color = purple;
        }
        else if(twox8.GetComponent<Image>().color != clear)
        {
            twox8.GetComponent<Image>().color = clear;
            onex6.GetComponent<Image>().color = purple;
        }
        else if(lblock.GetComponent<Image>().color != clear)
        {
            lblock.GetComponent<Image>().color = clear;
            onex8.GetComponent<Image>().color = purple;
        }
    }

    public void SelectMenu()
    {
        if(menuButton.GetComponent<Image>().color != black)
        {
            ShowMainMenu();
        }
        else if(legoButton.GetComponent<Image>().color != black)
        {
            ShowLegoMenu();
        }
        else if(undoButton.GetComponent<Image>().color != black)
        {
            //TODO: INSERT UNDO LEGO PLACEMENT CODE HERE
        }
        else if(zoomInButton.GetComponent<Image>().color != black)
        {
            //to close is 20
            if(vision.fieldOfView > 20)
            {
                vision.fieldOfView -=10;
            }
        }
        else
        {
            //To far is 100
            if(vision.fieldOfView < 100)
            {
                vision.fieldOfView +=10;
            }

        }
    }

    public void SwapMenu()
    {
        if(menuButton.GetComponent<Image>().color != black)
        {
            menuButton.GetComponent<Image>().color = black;
            legoButton.GetComponent<Image>().color = purple;
        }
        else if(legoButton.GetComponent<Image>().color != black)
        {
            legoButton.GetComponent<Image>().color = black;
            undoButton.GetComponent<Image>().color = purple;
        }
        else if(undoButton.GetComponent<Image>().color != black)
        {
            undoButton.GetComponent<Image>().color = black;
            zoomInButton.GetComponent<Image>().color = purple;
        }
        else if(zoomInButton.GetComponent<Image>().color != black)
        {
            zoomInButton.GetComponent<Image>().color = black;
            zoomOutButton.GetComponent<Image>().color = purple;
        }
        else if(zoomOutButton.GetComponent<Image>().color != black)
        {
            zoomOutButton.GetComponent<Image>().color = black;
            menuButton.GetComponent<Image>().color = purple;
        }
    }

    public void EnterMenuMode()
    {
        menuMode = true;
        menuButton.GetComponent<Image>().color = purple;
    }

    public void ExitMenuMode()
    {
        HideMainMenu();
        HideLegoMenu();
        menuButton.GetComponent<Image>().color = black;
        legoButton.GetComponent<Image>().color = black;
        undoButton.GetComponent<Image>().color = black;
        zoomInButton.GetComponent<Image>().color = black;
        zoomOutButton.GetComponent<Image>().color = black;
        menuMode = false;
    }

    public void HideMainMenu()
    {
        menuPanel.SetActive(false);
        menuButton.GetComponent<Image>().color = black;
        menuMode =false;
    }

    public void ShowMainMenu()
    {
        menuPanel.SetActive(true);
    }
    public void HideLegoMenu()
    {
        legoPanel.SetActive(false);
        legoButton.GetComponent<Image>().color = black;
        menuMode = false;
    }

    public void ShowLegoMenu()
    {
        legoPanel.SetActive(true);
        switch(selectedBlock)
        {
            case(0):
                onex1.GetComponent<Image>().color = purple;
                break;
            case(1):
                onex2.GetComponent<Image>().color = purple;
                break;
            case(2):
                onex3.GetComponent<Image>().color = purple;
                break;
            case(3):
                onex4.GetComponent<Image>().color = purple;
                break;
            case(4):
                onex6.GetComponent<Image>().color = purple;
                break;
            case(5):
                onex8.GetComponent<Image>().color = purple;
                break;
            case(6):
                twox2.GetComponent<Image>().color = purple;
                break;
            case(7):
                twox3.GetComponent<Image>().color = purple;
                break;
            case(8):
                twox4.GetComponent<Image>().color = purple;
                break;
            case(9):
                twox6.GetComponent<Image>().color = purple;
                break;
            case(10):
                twox8.GetComponent<Image>().color = purple;
                break;
            case(11):
                lblock.GetComponent<Image>().color = purple;
                break;
        }
    }
}