using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public static float speed = 8;
    private Vector3 moveDirection;
    private CharacterController controller;
    public static bool lego_selected;
    public static Stack<Lego> placed_legos;

   

    

    void Start()
    {
        placed_legos = new Stack<Lego>();
        controller=GetComponent<CharacterController>();
        lego_selected = false;
       
    }

    void Update()
    {
        
        float xDir = Input.GetAxisRaw("Horizontal");
        float yDir = Input.GetAxisRaw("Vertical");
        if(!MenuController.menuMode)
        {
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
   
}
