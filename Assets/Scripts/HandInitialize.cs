using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class HandInitialize : MonoBehaviourPun
{
    public int whichHand;
    public int whichColor;
    public GameObject hand;
    void Start()
    {
        if (this.photonView.IsMine)
        {
            InitializeHand();
        }
        
    }

    public void InitializeHand()
    {
        photonView.RPC("InitializeHandRPC", RpcTarget.AllBuffered, PlayerInfo.PI.avatar_piece_array[3], PlayerInfo.PI.avatar_color_array[3]);
    }

    [PunRPC]
    public void InitializeHandRPC(int h, int c)
    {
        whichHand = h;
        whichColor = c;
        if(whichHand < 3)
        {
            GameObject tempHand = Instantiate(PlayerInfo.PI.item_array[whichHand]) as GameObject;
            tempHand.transform.SetParent(hand.transform, false);
            tempHand.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = PlayerInfo.PI.avatar_colors[whichColor];
            //tempHand.GetComponent<Renderer>().material = PlayerInfo.PI.avatar_colors[whichColor];
        }
    }
}
