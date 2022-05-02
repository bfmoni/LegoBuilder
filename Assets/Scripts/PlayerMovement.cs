using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerMovement : MonoBehaviourPun//, IPunObservable
{
    private PhotonView PV;
    public static float speed = 8;
    private Vector3 moveDirection;
    private CharacterController controller;
    public static bool lego_selected;
    public static Stack<Lego> placed_legos;
    public GameObject avatar;
    public GameObject cameraParent;

   
    // void Awake()
    // {
    //     if (!this.photonView.IsMine)
    //     {
    //         this.gameObject.SetActive(false);
    //     }
    // }
    

    void Start()
    {
        PV = GetComponent<PhotonView>();
        placed_legos = new Stack<Lego>();
        controller=GetComponent<CharacterController>();
        lego_selected = false;
        if(PV.IsMine)
        {
            cameraParent.SetActive(true);
        }
        else
        {
            cameraParent.SetActive(false);
        }
       
    }

    void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }
        
        float y = Camera.main.transform.eulerAngles.y;
        avatar.transform.eulerAngles = new Vector3(avatar.transform.eulerAngles.x, y, avatar.transform.eulerAngles.z);

        if(MenuController.scale != 0)
        {
            //3rd person pov
            y = (y > 180) ? y - 360 : y;
            float cameraHeight = cameraParent.transform.position.y;
            cameraParent.transform.position = avatar.transform.position + new Vector3(Mathf.Sin(Mathf.PI * y / 180) * MenuController.scale * -4, cameraHeight, Mathf.Cos(Mathf.PI * y / 180) * MenuController.scale * -4) + new Vector3(0, 0, 1.03f);
            cameraParent.transform.position = new Vector3(cameraParent.transform.position.x, cameraHeight, cameraParent.transform.position.z);
        }
        else if (MenuController.scale == 0)
        {
            //1st person pov
            float avatary = avatar.transform.position.y;
            avatar.transform.position = cameraParent.transform.position + Camera.main.transform.forward * - 2f;
            avatar.transform.position = new Vector3(avatar.transform.position.x, avatary, avatar.transform.position.z);
        }
        
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


    // void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    // {
    //     // currently there is no strategy to improve on bandwidth, just passing the current distance and speed is enough, 
    //     // Input could be passed and then used to better control speed value
    //     //  Data could be wrapped as a vector2 or vector3 to save a couple of bytes
    //     if (stream.IsWriting)
    //     {
    //         stream.SendNext(this.CurrentDistance);
    //         stream.SendNext(this.CurrentSpeed);
    //         stream.SendNext(this.m_input);
    //     }
    //     else
    //     {
    //         if (this.m_firstTake)
    //         {
    //             this.m_firstTake = false;
    //         }

    //         this.CurrentDistance = (float) stream.ReceiveNext();
    //         this.CurrentSpeed = (float) stream.ReceiveNext();
    //         this.m_input = (float) stream.ReceiveNext();
    //     }
    // }
   
}
