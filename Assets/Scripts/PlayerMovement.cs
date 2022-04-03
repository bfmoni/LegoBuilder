using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 5;
    private Vector3 moveDirection;
    private CharacterController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        controller=GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        
        float xDir = Input.GetAxisRaw("Horizontal");
        float yDir = Input.GetAxisRaw("Vertical");
        if(Input.GetButton("Jump")) //back button is currently joystick button 3
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
}
