using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public Material boxMaterial;
    UnityEngine.Color gold = new Color32(233, 194, 26, 255);
    UnityEngine.Color blue = new Color32(75, 197, 214, 255);
    UnityEngine.Color red = new Color32(185, 14, 40, 255);
    bool rotate; bool move;
    float speed; float rotateSpeed;
    bool selected; bool rotateSelected; bool colorSelected; bool moveSelected;


    void Start () 
    {
        boxMaterial = GetComponent<Renderer>().material;
        rotate = false;
        move = false;
        selected = false;
        rotateSelected = false;
        colorSelected = false;
        moveSelected = false;
        speed = 0.8f; rotateSpeed = 30.0f;
    }

    void Update () 
    {
        if(selected && Input.GetButton("Fire1") && rotateSelected)
        {
            rotate = true;
        }
        else
        {
            rotate = false;
        }

        if(selected && Input.GetButton("Fire1") && moveSelected)
        {
            move = true;
        }
        else
        {
            move = false;
        }

        if(selected && Input.GetButtonDown("Fire1") && colorSelected)
        {
            if(boxMaterial.color == gold)
            {
                boxMaterial.color = blue;
            }
            else if(boxMaterial.color == blue)
            {
                boxMaterial.color = red;
            }
            else
            {
                boxMaterial.color = gold;
            }
        }

        if(rotate)
        {
            transform.Rotate(0, rotateSpeed*Time.deltaTime, 0);
        }
        if(move)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z + transform.position.z * speed * Time.deltaTime));
        }
    }


    public void Unselected()
    {
        rotate = false;
        move = false;
        selected = false;
    }

    public void Select()
    {
        if(!selected)
        {
            selected = true;
        }
    }
    public void SelectMove()
    {
        if(!moveSelected)
        {
            moveSelected = true;
        }
    }
    public void SelectRotate()
    {
        if(!rotateSelected)
        {
            rotateSelected = true;
        }
    }
    public void SelectColor()
    {
        if(!colorSelected)
        {
            colorSelected = true;
        }
    }

}
