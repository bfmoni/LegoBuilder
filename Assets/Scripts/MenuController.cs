using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Canvas mainCanvas;
    //panels
    public GameObject UIpanel, menuPanel, legoPanel, helpPanel, avatarPanel;

    //top menu buttons
    public Button menuButton, legoButton, undoButton, zoomInButton, zoomOutButton;
    //Lego  buttons
    public Button onex1, onex2, onex3, onex4, onex6, onex8, twox2, twox3, twox4, twox6, twox8;
    //Main menu buttons
    public Button kit, multiplayer, avatar, help, quit, sandbox;
    //Avatar buttons
    public Button hatButton, backButton, handButton, faceButton, bodyButton, legButton, saveButton, avatarBackButton;
    //Avatar pieces
    public GameObject hat, face, back, hand, chest, leg, skin, demoAvatar;

    public GameObject a_hat,a_face,a_back,a_hand,a_chest,a_leg,a_skin;

    public int [] color_array = new int [6];
    public int [] piece_array = new int [4];

    public int [] a_color_array = new int [6];
    public int [] a_piece_array = new int [4];
    public  Material[] face_array;
    public Material[] avatar_colors;
    public  GameObject[] item_array;
    public  GameObject[] back_array;
    public  GameObject[] hat_array;
    
    UnityEngine.Color black = new Color32(39, 39, 39, 100);
    UnityEngine.Color blackDark = new Color32(54, 54, 54, 255);
    UnityEngine.Color blackLight = new Color32(100, 100, 100, 255);
    UnityEngine.Color clear = new Color32(39, 39, 39, 0);
    UnityEngine.Color purple = new Color32(180, 104, 236, 100);
    UnityEngine.Color purple2 = new Color32(187, 134, 252, 114);

    public static bool menuMode;
    public static int selectedBlock;
    float timer;
    public static int scale = 4;
    public static bool last_open = false;

    void Start()
    {
        timer = 0;
        selectedBlock = 0;
        HideMainMenu();
        HideLegoMenu();
        helpPanel.SetActive(false);
        avatarPanel.SetActive(false);
    }


    void Update()
    {
        last_open = false;
        timer += Time.deltaTime;
        
        if(!PlayerMovement.lego_selected)
        {
            if(Input.GetButtonUp("Y"))
            {
                if(!menuMode)
                {
                    EnterMenuMode();
                }
                else if(!menuPanel.activeInHierarchy & !legoPanel.activeInHierarchy & !helpPanel.activeInHierarchy & !avatarPanel.activeInHierarchy)
                {
                    SwapMenu();
                }
                else if(avatarPanel.activeInHierarchy)
                {
                    demoAvatar.transform.Rotate(0, 0, 45);
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
                else if(avatarPanel.activeInHierarchy)
                {
                    SelectAvatar();
                }
                else
                {
                    SelectMenu();
                }
                
            }
            else if(Input.GetButtonUp("X") & menuMode)
            {
                SelectAvatarColor();
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
            else if((temp1 != 0 | temp2 != 0) & timer > 0.3 & avatarPanel.activeInHierarchy)
            {
                timer = 0;
                if(Mathf.Abs(temp1) > Mathf.Abs(temp2))
                {
                   
                    SwapAvatarHorizontal();
                   
                }
                else
                {
                    if(temp2 >0)
                    {
                        SwapAvatarVerticalU();
                    }
                    else
                    {
                        SwapAvatarVerticalD();
                    }
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
            twox8.GetComponent<Image>().color = purple;
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
            twox8.GetComponent<Image>().color = purple;
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
            
            if(PlayerMovement.placed_legos.Count != 0)
            {
                
                GameObject.DestroyImmediate(PlayerMovement.placed_legos.Pop().gameObject);

            }
        }
        else if(zoomInButton.GetComponent<Image>().color != black)
        {
            //TODO fix zoomin

            // 4 = max zoomin, 1 = max zoomout
            if(scale < 4)
            {
                scale += 1;
                //Camera.main.transform.position = minifig.transform.position + new Vector3(0, -4 * scale, 2 * scale);
                /*
                if(scale == 4)
                {
                    Camera.main.transform.Rotate(0, 0, 0);
                }


                moveDirection=new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
                moveDirection = Camera.main.transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                moveDirection.y = 0.0f;
                controller.Move(moveDirection * Time.deltaTime);
                */

            }
        }
        else if(zoomOutButton.GetComponent<Image>().color != black)
        {
            //TODO fix zoomout
            if(scale > 1)
            {
                scale -= 1;
                //Camera.main.transform.position = minifig.transform.position + new Vector3(0, 4 * scale, -2 * scale);
                /*
                if(scale == 3)
                {
                    Camera.main.transform.Rotate(0, -30, 0);
                    //minifig.transform.Rotate(0, 0, 0);
                }
                */
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
            ShowAvatarMenu();
        }
        else if(help.GetComponent<Image>().color != blackDark)
        {
            ShowHelpMenu();
        }
        else if(sandbox.GetComponent<Image>().color != purple2)
        {
            ExitMenuMode();
        }
        else if(quit.GetComponent<Image>().color != blackDark)
        {
            Application.Quit();
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
        avatarPanel.SetActive(false);
        menuButton.GetComponent<Image>().color = black;
        legoButton.GetComponent<Image>().color = black;
        undoButton.GetComponent<Image>().color = black;
        zoomInButton.GetComponent<Image>().color = black;
        zoomOutButton.GetComponent<Image>().color = black;
        last_open = true;
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
    }

    public void ShowMainMenu()
    {
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

    public void ShowAvatarMenu()
    {
        Array.Copy(a_color_array,color_array,color_array.Length);
        Array.Copy(a_piece_array,piece_array,piece_array.Length);
        Menu_Minifig_Setup(0);
        Menu_Minifig_Setup(1);
        Menu_Minifig_Setup(2);
        Menu_Minifig_Setup(3);
        Menu_Minifig_Setup(4);
        Menu_Minifig_Setup(5);
        avatarPanel.SetActive(true);
        hatButton.GetComponent<Image>().color = blackLight;
        menuPanel.SetActive(false);
    }
    public void HideAvatarMenu()
    {

        avatarBackButton.GetComponent<Image>().color = blackDark;
        handButton.GetComponent<Image>().color = blackDark;
        faceButton.GetComponent<Image>().color = blackDark;
        backButton.GetComponent<Image>().color = blackDark;
        bodyButton.GetComponent<Image>().color = blackDark;
        legButton.GetComponent<Image>().color = blackDark;
        saveButton.GetComponent<Image>().color = purple2;
    }

    public void SwapAvatarHorizontal()
    {
        if(hatButton.GetComponent<Image>().color != blackDark)
        {
            hatButton.GetComponent<Image>().color = blackDark;
            faceButton.GetComponent<Image>().color = blackLight;
        }
        else if(backButton.GetComponent<Image>().color != blackDark)
        {
            backButton.GetComponent<Image>().color = blackDark;
            bodyButton.GetComponent<Image>().color = blackLight;
        }
        else if(handButton.GetComponent<Image>().color != blackDark)
        {
            handButton.GetComponent<Image>().color = blackDark;
            legButton.GetComponent<Image>().color = blackLight;
        }
        else if(faceButton.GetComponent<Image>().color != blackDark)
        {
            faceButton.GetComponent<Image>().color = blackDark;
            hatButton.GetComponent<Image>().color = blackLight;
        }
        else if(bodyButton.GetComponent<Image>().color != blackDark)
        {
            bodyButton.GetComponent<Image>().color = blackDark;
            backButton.GetComponent<Image>().color = blackLight;
        }
        else if(legButton.GetComponent<Image>().color != blackDark)
        {
            legButton.GetComponent<Image>().color = blackDark;
            handButton.GetComponent<Image>().color = blackLight;
        }
        else if(saveButton.GetComponent<Image>().color != purple2)
        {
            saveButton.GetComponent<Image>().color = purple2;
            avatarBackButton.GetComponent<Image>().color = blackLight;
        }
        else if(avatarBackButton.GetComponent<Image>().color != blackDark)
        {
            avatarBackButton.GetComponent<Image>().color = blackDark;
            saveButton.GetComponent<Image>().color = blackLight;
        }

    }
    public void SwapAvatarVerticalU()
    {
        if(hatButton.GetComponent<Image>().color != blackDark)
        {
            hatButton.GetComponent<Image>().color = blackDark;
            avatarBackButton.GetComponent<Image>().color = blackLight;
        }
        else if(backButton.GetComponent<Image>().color != blackDark)
        {
            backButton.GetComponent<Image>().color = blackDark;
            hatButton.GetComponent<Image>().color = blackLight;
        }
        else if(handButton.GetComponent<Image>().color != blackDark)
        {
            handButton.GetComponent<Image>().color = blackDark;
            backButton.GetComponent<Image>().color = blackLight;
        }
        else if(faceButton.GetComponent<Image>().color != blackDark)
        {
            faceButton.GetComponent<Image>().color = blackDark;
            saveButton.GetComponent<Image>().color = blackLight;
        }
        else if(bodyButton.GetComponent<Image>().color != blackDark)
        {
            bodyButton.GetComponent<Image>().color = blackDark;
            faceButton.GetComponent<Image>().color = blackLight;
        }
        else if(legButton.GetComponent<Image>().color != blackDark)
        {
            legButton.GetComponent<Image>().color = blackDark;
            bodyButton.GetComponent<Image>().color = blackLight;
        }
        else if(saveButton.GetComponent<Image>().color != purple2)
        {
            saveButton.GetComponent<Image>().color = purple2;
            legButton.GetComponent<Image>().color = blackLight;
        }
        else if(avatarBackButton.GetComponent<Image>().color != blackDark)
        {
            avatarBackButton.GetComponent<Image>().color = blackDark;
            handButton.GetComponent<Image>().color = blackLight;
        }
    }
    public void SwapAvatarVerticalD()
    {
        if(hatButton.GetComponent<Image>().color != blackDark)
        {
            hatButton.GetComponent<Image>().color = blackDark;
            backButton.GetComponent<Image>().color = blackLight;
        }
        else if(backButton.GetComponent<Image>().color != blackDark)
        {
            backButton.GetComponent<Image>().color = blackDark;
            handButton.GetComponent<Image>().color = blackLight;
        }
        else if(handButton.GetComponent<Image>().color != blackDark)
        {
            handButton.GetComponent<Image>().color = blackDark;
            avatarBackButton.GetComponent<Image>().color = blackLight;
        }
        else if(faceButton.GetComponent<Image>().color != blackDark)
        {
            faceButton.GetComponent<Image>().color = blackDark;
            bodyButton.GetComponent<Image>().color = blackLight;
        }
        else if(bodyButton.GetComponent<Image>().color != blackDark)
        {
            bodyButton.GetComponent<Image>().color = blackDark;
            legButton.GetComponent<Image>().color = blackLight;
        }
        else if(legButton.GetComponent<Image>().color != blackDark)
        {
            legButton.GetComponent<Image>().color = blackDark;
            saveButton.GetComponent<Image>().color = blackLight;
        }
        else if(saveButton.GetComponent<Image>().color != purple2)
        {
            saveButton.GetComponent<Image>().color = purple2;
            faceButton.GetComponent<Image>().color = blackLight;
        }
        else if(avatarBackButton.GetComponent<Image>().color != blackDark)
        {
            avatarBackButton.GetComponent<Image>().color = blackDark;
            hatButton.GetComponent<Image>().color = blackLight;
        }
    }
    // 0 = hat 1 = face and skin 2 = back 3 = item 4 = chest 5 = legs
    // 0 = hat 1 = face 2 = back 3 = item
    //hat,face,back,hand,chest,leg,skin
    public void SelectAvatar()
    {
        //spot 0
        if(hatButton.GetComponent<Image>().color != blackDark)
        {
            if(piece_array[0] < 3)
                piece_array[0]++;
            else
                piece_array[0] = 0;
            Menu_Minifig_Setup(0);
        }
        //spot 1
        else if(faceButton.GetComponent<Image>().color != blackDark)
        {
            if(piece_array[1] < 2)
                piece_array[1]++;
            else
                piece_array[1] = 0;
            Menu_Minifig_Setup(1);
        }
        //spot 2
        else if(backButton.GetComponent<Image>().color != blackDark)
        {
            if(piece_array[2] < 3)
                piece_array[2]++;
            else
                piece_array[2] = 0;
            Menu_Minifig_Setup(2);
        }
        //spot 3
        else if(handButton.GetComponent<Image>().color != blackDark)
        {
            if(piece_array[3] < 3)
                piece_array[3]++;
            else
                piece_array[3] = 0;
            Menu_Minifig_Setup(3);
        }
        else if(saveButton.GetComponent<Image>().color != purple2)
        {
            Array.Copy(color_array,a_color_array,color_array.Length);
            Array.Copy(piece_array,a_piece_array,piece_array.Length);
            SwapAvatarModel();
            HideAvatarMenu();
            ExitMenuMode();
        }
        else if(avatarBackButton.GetComponent<Image>().color != blackDark)
        {
            HideAvatarMenu();
            avatarPanel.SetActive(false);
            menuPanel.SetActive(true);
        }
    }
    public void SelectAvatarColor()
    {
        //spot 0
        if(hatButton.GetComponent<Image>().color != blackDark)
        {
            if(color_array[0] < avatar_colors.Length - 1)
                color_array[0]++;
            else
                color_array[0] = 0;
            Menu_Minifig_Setup(0);
        }
        //spot 1
        else if(faceButton.GetComponent<Image>().color != blackDark)
        {
             if(color_array[1] < avatar_colors.Length - 1)
                color_array[1]++;
            else
                color_array[1] = 0;
            Menu_Minifig_Setup(1);
        }
        //spot 2
        else if(backButton.GetComponent<Image>().color != blackDark)
        {
             if(color_array[2] < avatar_colors.Length - 1)
                color_array[2]++;
            else
                color_array[2] = 0;
            Menu_Minifig_Setup(2);
        }
        //spot 3
        else if(handButton.GetComponent<Image>().color != blackDark)
        {
             if(color_array[3] < avatar_colors.Length - 1)
                color_array[3]++;
            else
                color_array[3] = 0;
            Menu_Minifig_Setup(3);
        }
        //spot 4
        else if(bodyButton.GetComponent<Image>().color != blackDark)
        {
             if(color_array[4] < avatar_colors.Length - 1)
                color_array[4]++;
            else
                color_array[4] = 0;
            Menu_Minifig_Setup(4);
        }
        //spot 5
        else if(legButton.GetComponent<Image>().color != blackDark)
        {
             if(color_array[5] < avatar_colors.Length - 1)
                color_array[5]++;
            else
                color_array[5] = 0;
            Menu_Minifig_Setup(5);
        }
        
    }
    public void Menu_Minifig_Setup(int piece)
    {
        switch(piece)
        {
            case 0:
                if(hat.transform.childCount > 0)
                {
                    DestroyImmediate(hat.transform.GetChild(0).gameObject);
                }
                if(piece_array[0] < 3)
                {
                    GameObject tempHat = Instantiate (hat_array[piece_array[0]]) as GameObject;
                    tempHat.transform.SetParent(hat.transform, false);
                    tempHat.GetComponent<Renderer>().material = avatar_colors[color_array[0]];
                }
                break;
            case 1:
                face.GetComponent<Renderer>().material = face_array[piece_array[1]];
                skin.GetComponent<Renderer>().material = avatar_colors[color_array[1]];
                break;
            case 2:
                if(back.transform.childCount > 0)
                {
                    DestroyImmediate(back.transform.GetChild(0).gameObject);
                }

                if(piece_array[2] < 3)
                {
                    GameObject tempBack = Instantiate (back_array[piece_array[2]]) as GameObject;
                    tempBack.transform.SetParent(back.transform, false);
                    if(piece_array[2] == 1)
                        tempBack.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = avatar_colors[color_array[2]];
                    else
                        tempBack.GetComponent<Renderer>().material = avatar_colors[color_array[2]];
                }
                break;
            case 3:
                if(hand.transform.childCount > 0)
                {
                    DestroyImmediate(hand.transform.GetChild(0).gameObject);
                }
                if(piece_array[3] < 3)
                {
                    GameObject tempHand = Instantiate (item_array[piece_array[3]]) as GameObject;
                    tempHand.transform.SetParent(hand.transform, false);
                    tempHand.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = avatar_colors[color_array[3]];
                }
                break;
            case 4:
                chest.GetComponent<Renderer>().material = avatar_colors[color_array[4]];
                break;
            case 5:
                leg.GetComponent<Renderer>().material = avatar_colors[color_array[5]];
                break;
        }
    }
    public void SwapAvatarModel()
    {
        
        if(a_hat.transform.childCount > 0)
        {
            DestroyImmediate(a_hat.transform.GetChild(0).gameObject);
        }
        if(piece_array[0] < 3)
        {
            GameObject tempHat = Instantiate (hat_array[piece_array[0]]) as GameObject;
            tempHat.transform.SetParent(a_hat.transform, false);
            tempHat.GetComponent<Renderer>().material = avatar_colors[color_array[0]];
        }
        
    
        a_face.GetComponent<Renderer>().material = face_array[piece_array[1]];
        a_skin.GetComponent<Renderer>().material = avatar_colors[color_array[1]];
        
    
        if(a_back.transform.childCount > 0)
        {
            DestroyImmediate(a_back.transform.GetChild(0).gameObject);
        }

        if(piece_array[2] < 3)
        {
            GameObject tempBack = Instantiate (back_array[piece_array[2]]) as GameObject;
            tempBack.transform.SetParent(a_back.transform, false);
            if(piece_array[2] == 1)
                tempBack.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = avatar_colors[color_array[2]];
            else
                tempBack.GetComponent<Renderer>().material = avatar_colors[color_array[2]];
        }
        
        if(a_hand.transform.childCount > 0)
        {
            DestroyImmediate(a_hand.transform.GetChild(0).gameObject);
        }
        if(piece_array[3] < 3)
        {
            GameObject tempHand = Instantiate (item_array[piece_array[3]]) as GameObject;
            tempHand.transform.SetParent(a_hand.transform, false);
            tempHand.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = avatar_colors[color_array[3]];
        }
        
        a_chest.GetComponent<Renderer>().material = avatar_colors[color_array[4]];
        
    
        a_leg.GetComponent<Renderer>().material = avatar_colors[color_array[5]];
                
    }
}
