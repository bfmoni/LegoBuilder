using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SkinInitialize : MonoBehaviourPun
{
    public int whichColor;
    public GameObject body;
    void Start()
    {
        if (this.photonView.IsMine)
        {
            InitializeSkin();
        }
        
    }

    public void InitializeSkin()
    {
        photonView.RPC("InitializeSkinRPC", RpcTarget.AllBuffered, PlayerInfo.PI.avatar_color_array[1]);
    }

    [PunRPC]
    public void InitializeSkinRPC(int c)
    {
        whichColor = c;
        body.GetComponent<Renderer>().material = PlayerInfo.PI.avatar_colors[whichColor];
    }
}
