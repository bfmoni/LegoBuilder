using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float speed = 5;
    private Vector3 moveDirection;
    private CharacterController controller;
    public static bool lego_selected;

    // holds all the lego prefabs 0-5 is 1x 6-10 is 2x prefab 11 is L shape
    public GameObject[] lego_blocks;
    public GameObject current_lego;
    public static GameObject last_lego;

    //Lego Colors
    UnityEngine.Color lego_purple = new Color32(150, 117, 180, 255);
    UnityEngine.Color lego_blue = new Color32(0, 163, 218, 225);
    UnityEngine.Color lego_green = new Color32(150, 199, 83, 225);
    UnityEngine.Color lego_yellow = new Color32(247, 209, 18, 255);
    UnityEngine.Color lego_red = new Color32(229, 30, 38, 255);
    UnityEngine.Color lego_brown = new Color32(166, 83, 34, 255);
    UnityEngine.Color lego_black = new Color32(21, 21, 21, 255);
    UnityEngine.Color lego_white = new Color32(244, 244, 244, 255);


    void Start()
    {
        controller=GetComponent<CharacterController>();
        lego_selected = false;
    }

    void Update()
    {
        
        float xDir = Input.GetAxisRaw("Horizontal");
        float yDir = Input.GetAxisRaw("Vertical");
        if(!MenuController.menuMode & !MenuController.starting)
        {
            if(lego_selected)
            {
                if(Input.GetButtonUp("B"))
                {
                    //place lego
                    //set last_lego to the placed lego
                }
                if(Input.GetButtonUp("A"))
                {
                    Destroy(current_lego);
                    lego_selected = false;
                }
                if(Input.GetButtonUp("X"))
                {
                    ColorCycle();
                }
                if(Input.GetButtonUp("Y"))
                {
                    //ONLY DEALING WITH 90 DEGREE ROTATION
                    //NOT COMPLETE NEEDS TO DEAL WITH NEW PLACEMENT BASED ON ROTATION
                    current_lego.transform.Rotate(0,90,0);
                }
            }
            else
            {
                // NOT FULL IMPLEMENTED
                if(Input.GetButtonUp("B"))
                {
                    lego_selected = true;
                    current_lego = Instantiate(lego_blocks[MenuController.selectedBlock], this.transform.position + Vector3.forward*4, this.transform.rotation);
                    //set current lego value
                }
            }
            // controls player movement
            if(Input.GetButton("OK"))
            {
                
                moveDirection=new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
                moveDirection = Camera.main.transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                moveDirection.z = 0.0f;
                controller.Move(moveDirection * Time.deltaTime);
            }
            else
            {
                moveDirection=new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
                moveDirection = Camera.main.transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                moveDirection.y = 0.0f;
                controller.Move(moveDirection * Time.deltaTime);
            }
        }


    }

    /*
    void OnTriggerEnter(Collider e)
    {
        if(e.transform.position.x > transform.position.x)
        {
            transform.position = new Vector3(transform.position.x - 0.3f,1.5f,transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + 0.3f,1.5f,transform.position.z);
        }
        if(e.transform.position.z > transform.position.z)
        {
            transform.position = new Vector3(transform.position.x,1.5f,transform.position.z- 0.3f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x,1.5f,transform.position.z + 0.3f);
        }
        
    }
    */
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
