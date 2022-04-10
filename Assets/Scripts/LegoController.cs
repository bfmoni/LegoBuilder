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

    public Vector3 gp;

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
    
        if(!MenuController.menuMode)
        {
            if(current_lego == null)
            {
                if(Input.GetButtonUp("B"))
                {
                    current_lego = Instantiate(all_legos[MenuController.selectedBlock]);
                    PlayerMovement.lego_selected = true;
                }
            }
            else
            {
                if(Input.GetButtonUp("B"))
                {
                    PlaceLego();
                }
                if(Input.GetButtonUp("A"))
                {
                    DestroyImmediate(current_lego);
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
            
            
                if (Physics.Raycast(Camera.main.transform.position + Vector3.up * .02f , Camera.main.transform.forward, out var hitInfo, 100, GridController.LegoLayer))
                {
                    Vector3 p = GridController.SnapToGrid(hitInfo.point);

                    if(PositionOk)
                    {
                        if( Mathf.Abs(( (p.x*p.x - gp.x*gp.x) + ( p.y*p.y - gp.y*gp.y) + ( p.z*p.z - gp.z * gp.z) )) > 1.1)
                        {
                            PositionOk = false;
                        }
                    }
                    else
                    {
                    
                        var placePosition = p;
                        PositionOk = false;
                        for (int i = 0; i < 10; i++)
                        {
                            var collider = Physics.OverlapBox(placePosition + current_lego.transform.rotation * current_lego.Collider.center, current_lego.Collider.size / 2, current_lego.transform.rotation, GridController.LegoLayer);
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
                            gp = placePosition;
                        }
                        else
                            current_lego.transform.position = p;
                    }
                
                }
            
            
            
        }

    }


    public void PlaceLego()
    {
        if(current_lego != null && PositionOk)
        {
            PlayerMovement.placed_legos.Push(current_lego);
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

}
