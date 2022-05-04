using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Kit : MonoBehaviour
{
    public Lego [] kit_legos;
    public PhotonView PV;

    public void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
}
