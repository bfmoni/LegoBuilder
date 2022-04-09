using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Canvas mainCanvas;
    public GameObject UIpanel;
    public GameObject menuPanel;
    public GameObject legoPanel;
    public GameObject helpPanel;
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
    public Button kit;
    public Button multiplayer;
    public Button avatar;
    public Button help;
    public Button quit;
    public Button sandbox;
    public Camera vision;
    public GameObject reticle;
    

    UnityEngine.Color black = new Color32(39, 39, 39, 100);
    UnityEngine.Color blackDark = new Color32(54, 54, 54, 225);
    UnityEngine.Color blackLight = new Color32(100, 100, 100, 225);
    UnityEngine.Color clear = new Color32(39, 39, 39, 0);
    UnityEngine.Color purple = new Color32(180, 104, 236, 100);
    UnityEngine.Color purple2 = new Color32(187, 134, 252, 114);

    public static bool menuMode;
    float timer;
    public static int selectedBlock;
    public float scale = 1f;

    void Start()
    {
        timer = 0;
        selectedBlock = 0;
        HideMainMenu();
        HideLegoMenu();
        helpPanel.SetActive(false);
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
                else if(!menuPanel.activeInHierarchy & !legoPanel.activeInHierarchy & !helpPanel.activeInHierarchy)
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
                    SelectMainMenu();
                }
                else if(legoPanel.activeInHierarchy)
                {
                    SelectLego();
                }
                else if (helpPanel.activeInHierarchy)
                {
                    HideHelpMenu();
                }
                else
                {
                    SelectMenu();
                }
                
            }

            var temp1 = Input.GetAxis("Horizontal");
            var temp2 = Input.GetAxis("Vertical");

            if((temp1 != 0 | temp2 != 0) & timer > 0.3 & legoPanel.activeInHierarchy)
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

            else if((temp1 != 0 | temp2 != 0) & timer > 0.3 & menuPanel.activeInHierarchy)
            {
                timer = 0;
                if(Mathf.Abs(temp1) > Mathf.Abs(temp2))
                {
                    if(temp1 > 0)
                    {
                        SwapMainMenuR();
                    }
                    else
                    {
                        SwapMainMenuL();
                    }
                }
                else
                {
                    if(temp2 > 0)
                    {
                        SwapMainMenuUp();
                    }
                    else
                    {
                        SwapMainMenuDown();
                    }
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
            scale -= 1f;
            scale = Mathf.Clamp(scale, 1f, 10f);
            transform.localScale = new Vector3(scale, scale, scale);

        }
        else
        {
            scale += 1f;
            scale = Mathf.Clamp(scale, 1f, 10f);
            transform.localScale = new Vector3(scale, scale, scale);

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

    public void SwapMainMenuR()
    {
        if(kit.GetComponent<Image>().color != blackDark)
        {
            kit.GetComponent<Image>().color = blackDark;
            multiplayer.GetComponent<Image>().color = blackLight;
        }
        else if(multiplayer.GetComponent<Image>().color != blackDark)
        {
            multiplayer.GetComponent<Image>().color = blackDark;
            avatar.GetComponent<Image>().color = blackLight;
        }
        else if(avatar.GetComponent<Image>().color != blackDark)
        {
            avatar.GetComponent<Image>().color = blackDark;
            kit.GetComponent<Image>().color = blackLight;
        }
        else if(help.GetComponent<Image>().color != blackDark)
        {
            help.GetComponent<Image>().color = blackDark;
            quit.GetComponent<Image>().color = blackLight;
        }
        else if(quit.GetComponent<Image>().color != blackDark)
        {
            quit.GetComponent<Image>().color = blackDark;
            help.GetComponent<Image>().color = blackLight;
        }
    }

    public void SwapMainMenuL()
    {
        if(kit.GetComponent<Image>().color != blackDark)
        {
            kit.GetComponent<Image>().color = blackDark;
            avatar.GetComponent<Image>().color = blackLight;
        }
        else if(multiplayer.GetComponent<Image>().color != blackDark)
        {
            multiplayer.GetComponent<Image>().color = blackDark;
            kit.GetComponent<Image>().color = blackLight;
        }
        else if(avatar.GetComponent<Image>().color != blackDark)
        {
            avatar.GetComponent<Image>().color = blackDark;
            multiplayer.GetComponent<Image>().color = blackLight;
        }
        else if(help.GetComponent<Image>().color != blackDark)
        {
            help.GetComponent<Image>().color = blackDark;
            quit.GetComponent<Image>().color = blackLight;
        }
        else if(quit.GetComponent<Image>().color != blackDark)
        {
            quit.GetComponent<Image>().color = blackDark;
            help.GetComponent<Image>().color = blackLight;
        }
    }

    public void SwapMainMenuUp()
    {
        if(kit.GetComponent<Image>().color != blackDark)
        {
            kit.GetComponent<Image>().color = blackDark;
            help.GetComponent<Image>().color = blackLight;
        }
        else if(multiplayer.GetComponent<Image>().color != blackDark)
        {
            multiplayer.GetComponent<Image>().color = blackDark;
            help.GetComponent<Image>().color = blackLight;
        }
        else if(avatar.GetComponent<Image>().color != blackDark)
        {
            avatar.GetComponent<Image>().color = blackDark;
            help.GetComponent<Image>().color = blackLight;
        }
        else if(help.GetComponent<Image>().color != blackDark)
        {
            help.GetComponent<Image>().color = blackDark;
            sandbox.GetComponent<Image>().color = blackLight;
        }
        else if(quit.GetComponent<Image>().color != blackDark)
        {
            quit.GetComponent<Image>().color = blackDark;
            sandbox.GetComponent<Image>().color = blackLight;
        }
        else if(sandbox.GetComponent<Image>().color != purple2)
        {
            sandbox.GetComponent<Image>().color = purple2;
            kit.GetComponent<Image>().color = blackLight;
        }
    }

    public void SwapMainMenuDown()
    {
        if(kit.GetComponent<Image>().color != blackDark)
        {
            kit.GetComponent<Image>().color = blackDark;
            sandbox.GetComponent<Image>().color = blackLight;
        }
        else if(multiplayer.GetComponent<Image>().color != blackDark)
        {
            multiplayer.GetComponent<Image>().color = blackDark;
            sandbox.GetComponent<Image>().color = blackLight;
        }
        else if(avatar.GetComponent<Image>().color != blackDark)
        {
            avatar.GetComponent<Image>().color = blackDark;
            sandbox.GetComponent<Image>().color = blackLight;
        }
        else if(help.GetComponent<Image>().color != blackDark)
        {
            help.GetComponent<Image>().color = blackDark;
            kit.GetComponent<Image>().color = blackLight;
        }
        else if(quit.GetComponent<Image>().color != blackDark)
        {
            quit.GetComponent<Image>().color = blackDark;
            kit.GetComponent<Image>().color = blackLight;
        }
        else if(sandbox.GetComponent<Image>().color != purple2)
        {
            sandbox.GetComponent<Image>().color = purple2;
            help.GetComponent<Image>().color = blackLight;
        }
    }

    public void SelectMainMenu()
    {
        if(kit.GetComponent<Image>().color != blackDark)
        {
            //TODO
        }
        else if(multiplayer.GetComponent<Image>().color != blackDark)
        {
            //TODO
        }
        else if(avatar.GetComponent<Image>().color != blackDark)
        {
            //TODO
        }
        else if(help.GetComponent<Image>().color != blackDark)
        {
            ShowHelpMenu();
        }
        else if(quit.GetComponent<Image>().color != blackDark)
        {
            Application.Quit();
        }
        else if(sandbox.GetComponent<Image>().color != purple2)
        {
            HideMainMenu();
        }
    }

    public void EnterMenuMode()
    {
        menuMode = true;
        legoButton.GetComponent<Image>().color = purple;
    }

    public void ExitMenuMode()
    {
        HideMainMenu();
        HideLegoMenu();
        helpPanel.SetActive(false);
        menuButton.GetComponent<Image>().color = black;
        legoButton.GetComponent<Image>().color = black;
        undoButton.GetComponent<Image>().color = black;
        zoomInButton.GetComponent<Image>().color = black;
        zoomOutButton.GetComponent<Image>().color = black;
        menuMode = false;
    }

    public void HideMainMenu()
    {
        kit.GetComponent<Image>().color = blackDark;
        multiplayer.GetComponent<Image>().color = blackDark;
        avatar.GetComponent<Image>().color = blackDark;
        help.GetComponent<Image>().color = blackDark;
        sandbox.GetComponent<Image>().color = purple2;

        menuPanel.SetActive(false);
        UIpanel.SetActive(true);
        menuButton.GetComponent<Image>().color = black;
        menuMode = false;

        reticle.SetActive(true);
    }

    public void ShowMainMenu()
    {
        reticle.SetActive(false);
        UIpanel.SetActive(false);
        menuPanel.SetActive(true);
        kit.GetComponent<Image>().color = blackLight;
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

    public void ShowHelpMenu()
    {
        menuPanel.SetActive(false);
        helpPanel.SetActive(true);
    }
    
    public void HideHelpMenu()
    {
        help.GetComponent<Image>().color = blackDark;
        helpPanel.SetActive(false);
        ShowMainMenu();
    }

}
