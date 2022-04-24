using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoController : MonoBehaviour
{
    // inspiration from https://www.youtube.com/watch?v=0jzc_uNdH40&t=647s
    // holds all the lego prefabs 0-5 is 1x 6-10 is 2x prefab 11 is L shape
    public Lego[] all_legos;
    public Lego current_lego;
    public bool PositionOk;




    public Kit[] kits;
    public bool kit_placed = false;
    public bool kit_position = false;
    public static bool kit_mode = false;
    public static int kit_selection;
    public static int bottom_level;
    public Kit current_kit;

   


    //Lego Colors
    UnityEngine.Color lego_purple = new Color32(150, 117, 180, 255);
    UnityEngine.Color lego_blue = new Color32(0, 163, 218, 225);
    UnityEngine.Color lego_green = new Color32(150, 199, 83, 225);
    UnityEngine.Color lego_yellow = new Color32(247, 209, 18, 255);
    UnityEngine.Color lego_red = new Color32(229, 30, 38, 255);
    UnityEngine.Color lego_brown = new Color32(166, 83, 34, 255);
    UnityEngine.Color lego_black = new Color32(21, 21, 21, 255);
    UnityEngine.Color lego_white = new Color32(244, 244, 244, 255);    


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
    
        if(!MenuController.menuMode && !kit_mode)
        {
            if(current_lego == null)
            {
                if(Input.GetButtonUp("B") && !MenuController.last_open)
                {
                    current_lego = Instantiate(all_legos[MenuController.selectedBlock]);
                    current_lego.Collider.enabled = false;
                    PlayerMovement.lego_selected = true;
                }
            }
            else
            {
                if(Input.GetButtonUp("B"))
                {
                    ConfirmLego();
                }
                if(Input.GetButtonUp("A"))
                {
                    GameObject.DestroyImmediate(current_lego.gameObject);
                    PlayerMovement.lego_selected = false;
                }
                if(Input.GetButtonUp("X"))
                {
                    ColorCycle();
                }
                if(Input.GetButtonUp("Y"))
                {
                    current_lego.transform.Rotate(0,90,0);
                }
            }
        }
        
        if (current_lego != null)
        {
            PlaceLego();
        }

        if(kit_mode)
        {
            if(!kit_placed)
            {
                if(current_kit == null)
                {
                    current_kit = Instantiate(kits[kit_selection]);

                    for(int i = 0; i < current_kit.kit_legos.Length; i++)
                    {
                        current_kit.kit_legos[i].Collider.enabled = false;
                    }
                    
                }
                if(current_kit != null)
                {
                    PlaceKit2();
                }
                
                if(Input.GetButtonUp("B") && !MenuController.last_open)
                {
                    ConfirmKit();
                }
                else if(Input.GetButtonUp("A") && !MenuController.last_open)
                {
                    //TODO Fix this
                    GameObject.DestroyImmediate(current_kit);
                    kit_mode = false;
                }
                else if(Input.GetButtonUp("Y") && !MenuController.last_open)
                {
                    current_kit.transform.Rotate(0,90,0);
                }

            }
        }

    }


    public void ConfirmLego()
    {
        if(current_lego != null && PositionOk)
        {
            PlayerMovement.placed_legos.Push(current_lego);
            current_lego.Collider.enabled = true;
            current_lego = null;
            PlayerMovement.lego_selected = false;
        }
    }

    public void ColorCycle()
    {
        int numChildren = current_lego.transform.childCount;
        for(int i=0; i<numChildren; i++)
        {
            GameObject child = current_lego.transform.GetChild(i).gameObject;
            if(child.GetComponent<Renderer>().material.color == lego_purple) {child.GetComponent<Renderer>().material.color = lego_blue;}
            else if(child.GetComponent<Renderer>().material.color == lego_blue) {child.GetComponent<Renderer>().material.color = lego_green;}
            else if(child.GetComponent<Renderer>().material.color == lego_green) {child.GetComponent<Renderer>().material.color = lego_yellow;}
            else if(child.GetComponent<Renderer>().material.color == lego_yellow) {child.GetComponent<Renderer>().material.color = lego_red;}
            else if(child.GetComponent<Renderer>().material.color == lego_red) {child.GetComponent<Renderer>().material.color = lego_brown;}
            else if(child.GetComponent<Renderer>().material.color == lego_brown) {child.GetComponent<Renderer>().material.color = lego_black;}
            else if(child.GetComponent<Renderer>().material.color == lego_black) {child.GetComponent<Renderer>().material.color = lego_white;}
            else if(child.GetComponent<Renderer>().material.color == lego_white) {child.GetComponent<Renderer>().material.color = lego_purple;}
        }
    }
    public void PlaceLego()
    {
        if (Physics.Raycast(Camera.main.transform.position - Vector3.up * 0.1f , Camera.main.transform.forward, out var hitInfo, 100, GridController.LegoLayer))
        {
            Vector3 p = GridController.SnapToGrid(hitInfo.point);
            
            var placePosition = p;
            PositionOk = false;
            for (int i = 0; i < 10; i++)
            {
                var collider = Physics.OverlapBox(placePosition + current_lego.transform.rotation * current_lego.Collider.center, current_lego.Collider.size / 2, current_lego.transform.rotation, GridController.LegoLayer);
                //Why does this version not work?
                //var collider = Physics.OverlapBox(placePosition + current_lego.Collider.center, current_lego.Collider.size / 2, current_lego.transform.rotation, GridController.LegoLayer);
                PositionOk = collider.Length == 0;
                if (PositionOk)
                {
                    break;
                }
                else
                    placePosition.y += GridController.Grid.y;
            }
            
            if (PositionOk)
            {
                current_lego.transform.position = placePosition;
            }
            else
                current_lego.transform.position = p;
            
        
        }
    }
    public void ConfirmKit()
    {
        if(current_kit != null && kit_position)
        {
            /*
            for(int i = 0; i < current_kit.kit_legos.Length; i++)
            {
                current_kit.kit_legos[i].Collider.enabled = true;
            }
            */
            current_kit = null;
            kit_placed = true;
        }
    }

    public void PlaceKit2()
    {
        kit_position = false;
        if (Physics.Raycast(Camera.main.transform.position - Vector3.up * 0.1f , Camera.main.transform.forward, out var hitInfo, 100, GridController.LegoLayer))
        {
            Vector3 p = GridController.SnapToGrid(hitInfo.point);
            var placePosition = p;
            int numCollisions = 0;
            int level = 0;
            while(level < 10)
            {
                numCollisions = 0;
                for(int i = 0; i < bottom_level; i++)
                {
                    Lego child = current_kit.kit_legos[i];
                    placePosition = p;
                    placePosition.y += (GridController.Grid.y * level);
                    //placePosition.y += level;
                    var collider = Physics.OverlapBox(placePosition + child.transform.rotation * child.Collider.center, child.Collider.size / 2, child.transform.rotation, GridController.LegoLayer);
                    if (!(collider.Length == 0))
                    {
                        numCollisions++;
                    }

                }
                Debug.Log(numCollisions);
                if(numCollisions == bottom_level)
                {
                    //all of the legos in the bottom level collided with something, go up a level
                    level++;
                }
                else if(numCollisions == 0)
                {
                    //none of the legos in the bottom level collided with anything, position is ok to place
                    kit_position = true;
                    current_kit.transform.position = placePosition;
                    break;
                }
                else
                {
                    //some legos collided, some didn't. no valid position in current location
                    current_kit.transform.position = p;
                    break;
                }
            }

        }

            
    }





    public bool PlaceKit()
    {
        int last_level = 0;
        kit_position = false;
        if (Physics.Raycast(Camera.main.transform.position - Vector3.up * 0.1f , Camera.main.transform.forward, out var hitInfo, 100, GridController.LegoLayer))
        {
            Vector3 p = GridController.SnapToGrid(hitInfo.point);
            //bottom layer check
            for(int i = 0; i< bottom_level; i++)
            {
                int level = 0;
                Lego child = current_kit.kit_legos[i];
                var placePosition = p;
                for (int j = 0; j < 10; i++)
                {
                    PositionOk = false;
                    var collider = Physics.OverlapBox( p + new Vector3(0,level,0) + child.transform.rotation *child.Collider.center, child.Collider.size / 2, child.transform.rotation, GridController.LegoLayer);
                    PositionOk = collider.Length == 0;
                    if (PositionOk)
                    {
                        if(i == 0)
                        {
                            last_level = level;
                        }

                        //TODO probably doesnt work
                        if(level != last_level)
                        {
                            current_kit.transform.position = p;
                            return false;
                        }
                        break;
                    }
                    else
                    {
                        level++;
                    }
                }
                
            }
             

            //rest of the blocks
            int numChildren = current_kit.kit_legos.Length;
            for(int i = bottom_level; i < numChildren; i++)
            {
                PositionOk = false;
                Lego child = current_kit.kit_legos[i];
                var collider = Physics.OverlapBox(new Vector3(0,last_level,0) +child.Collider.center, child.Collider.size / 2, child.transform.rotation, GridController.LegoLayer);
                PositionOk = collider.Length == 0;
                if (PositionOk)
                {
                    //if positionOk we dont need to do anything
                }
                else
                {
                    current_kit.transform.position = p;
                    return false;
                }
                
            }
            
            current_kit.transform.position = p + new Vector3(0,last_level,0);
            return true;
           
        }
        return false;
            
    }

}
