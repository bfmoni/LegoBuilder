using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class HatInitialize : MonoBehaviourPun
{
    public int whichHat;
    public int whichColor;
    public GameObject hat;
    void Start()
    {
        if (this.photonView.IsMine)
        {
            InitializeHat();
        }
        
    }

    public void InitializeHat()
    {
        photonView.RPC("InitializeHatRPC", RpcTarget.AllBuffered, PlayerInfo.PI.avatar_piece_array[0], PlayerInfo.PI.avatar_color_array[0]);
    }

    [PunRPC]
    public void InitializeHatRPC(int h, int c)
    {
        whichHat = h;
        whichColor = c;
        if(whichHat < 3)
        {
            GameObject tempHat = Instantiate(PlayerInfo.PI.hat_array[whichHat]) as GameObject;
            tempHat.transform.SetParent(hat.transform, false);
            tempHat.GetComponent<Renderer>().material = PlayerInfo.PI.avatar_colors[whichColor];
        }
    }
}
