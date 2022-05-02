using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    void Awake()
    {
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public static void JoinRoom(string room)
    {
        // check if connected to server
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("trying to create or join room");
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 2;
            roomOptions.IsVisible = false;
            PhotonNetwork.JoinOrCreateRoom(room, roomOptions, TypedLobby.Default);
        }
        else
        {
            Debug.Log("Not connected");
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Successfully connected to server");
        
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("OnDisconnected() {0}", cause);
        
    }


    public override void OnJoinedRoom()
    {
        Debug.Log("Successfully joined the room");
    }

    public static void LeaveRoom()
    {
        Debug.Log("Leaving the room");
        PhotonNetwork.LeaveRoom();
    }
    /*
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("LegoScene");
    }
    */
    public override void OnLeftRoom()
    {
        Debug.Log("Left the room");
    }
    /*
    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.Log("Player entered.");
        /*
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);
            //Debug.Log("loading room");
            //PhotonNetwork.LoadLevel("LegoScene");
        }
        
    }

    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.Log("Player left.");
        /*
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);
            //Debug.Log("loading room");
            //PhotonNetwork.LoadLevel("LegoScene");
        }
        
    }
    */
}
