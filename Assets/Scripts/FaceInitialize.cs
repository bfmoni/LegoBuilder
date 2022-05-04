using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class FaceInitialize : MonoBehaviourPun
{
    public int whichColor;
    public GameObject body;
    void Start()
    {
        if (this.photonView.IsMine)
        {
            InitializeFace();
        }
        
    }

    public void InitializeFace()
    {
        photonView.RPC("InitializeFaceRPC", RpcTarget.AllBuffered, PlayerInfo.PI.avatar_piece_array[1]);
    }

    [PunRPC]
    public void InitializeFaceRPC(int c)
    {
        whichColor = c;
        body.GetComponent<Renderer>().material = PlayerInfo.PI.face_array[whichColor];
    }
}