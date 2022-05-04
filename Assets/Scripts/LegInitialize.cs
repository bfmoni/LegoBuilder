using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LegInitialize : MonoBehaviourPun
{
    public int whichColor;
    public GameObject body;
    void Start()
    {
        if (this.photonView.IsMine)
        {
            InitializeLeg();
        }
        
    }

    public void InitializeLeg()
    {
        photonView.RPC("InitializeLegRPC", RpcTarget.AllBuffered, PlayerInfo.PI.avatar_color_array[5]);
    }

    [PunRPC]
    public void InitializeLegRPC(int c)
    {
        whichColor = c;
        body.GetComponent<Renderer>().material = PlayerInfo.PI.avatar_colors[whichColor];
    }
}
