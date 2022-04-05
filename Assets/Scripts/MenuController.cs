using System.Collections;
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

    UnityEngine.Color black = new Color32(39, 39, 39, 100);
    UnityEngine.Color purple = new Color32(180, 104, 236, 100);

    public bool menuMode;
    float timer = 0;
    public static char selectedBlock = 'a';

    void Start()
    {
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
                    //TODO: SET ACTIVE LEGO FUNCTION
                }
                else
                {
                    SelectMenu();
                }
                
            }
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
        else if(zoomInButton.GetComponent<Image>().color != purple)
        {
            //TODO: INSERT ZOOM IN CODE HERE
        }
        else
        {
            //TODO: INSERT ZOOM OUT CODE HERE

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
    }
}
