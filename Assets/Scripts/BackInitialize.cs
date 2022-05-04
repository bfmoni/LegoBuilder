using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BackInitialize : MonoBehaviourPun
{
    public int whichBack;
    public int whichColor;
    public GameObject back;
    void Start()
    {
        if (this.photonView.IsMine)
        {
            InitializeBack();
        }
        
    }

    public void InitializeBack()
    {
        photonView.RPC("InitializeBackRPC", RpcTarget.AllBuffered, PlayerInfo.PI.avatar_piece_array[2], PlayerInfo.PI.avatar_color_array[2]);
    }

    [PunRPC]
    public void InitializeBackRPC(int h, int c)
    {
        whichBack = h;
        whichColor = c;
        if(whichBack < 3)
        {
            GameObject temp = Instantiate(PlayerInfo.PI.back_array[whichBack]) as GameObject;
            temp.transform.SetParent(back.transform, false);
            if(whichBack == 1)
                temp.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = PlayerInfo.PI.avatar_colors[whichColor];
            else
                temp.GetComponent<Renderer>().material = PlayerInfo.PI.avatar_colors[whichColor];
        }
    }
}
