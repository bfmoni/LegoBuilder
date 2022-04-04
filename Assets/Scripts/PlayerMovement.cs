using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 5;
    private Vector3 moveDirection;
    private CharacterController controller;
    
    bool menu_open;
    bool lego_selected;

    // Start is called before the first frame update
    void Start()
    {
        controller=GetComponent<CharacterController>();
        menu_open = false;
        lego_selected = false;
        //last_lego
        //current_lego  
    }

    // Update is called once per frame
    void Update()
    {
        
        float xDir = Input.GetAxisRaw("Horizontal");
        float yDir = Input.GetAxisRaw("Vertical");
        if(menu_open)
        {
            if(Input.GetButtonUp("A"))
            {
                menu_open = false;
                //close memus
            }
        }
        else
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
                    lego_selected = false;
                    //clear spawn lego
                }
                if(Input.GetButtonUp("X"))
                {
                    //color change selected lego
                }
                if(Input.GetButtonUp("Y"))
                {
                    //rotate lego
                }
            }
            else
            {
                if(Input.GetButtonUp("B"))
                {
                    lego_selected = true;
                    //spawn lego
                    //set current lego value
                }
                if(Input.GetButtonUp("Y"))
                {
                    menu_open = true;
                    //open menus
                }
            }
           
            // controls player movement
            if(Input.GetButton("Y"))
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
}
