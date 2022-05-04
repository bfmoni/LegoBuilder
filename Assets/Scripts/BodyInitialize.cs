using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BodyInitialize : MonoBehaviourPun
{
    public int whichColor;
    public GameObject body;
    void Start()
    {
        if (this.photonView.IsMine)
        {
            InitializeBody();
        }
        
    }

    public void InitializeBody()
    {
        photonView.RPC("InitializeBodyRPC", RpcTarget.AllBuffered, PlayerInfo.PI.avatar_color_array[4]);
    }

    [PunRPC]
    public void InitializeBodyRPC(int c)
    {
        whichColor = c;
        body.GetComponent<Renderer>().material = PlayerInfo.PI.avatar_colors[whichColor];
    }
}
