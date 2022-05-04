using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class Lego : MonoBehaviour
{
     [HideInInspector]
    public BoxCollider Collider;
    public PhotonView PV;
    
    public void Awake()
    {
        PV = GetComponent<PhotonView>();
        Collider = GetComponent<BoxCollider>();
    }

}
