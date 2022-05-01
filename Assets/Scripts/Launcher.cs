using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private byte maxPlayersPerRoom = 2;

    string gameVersion = "1";
    bool isConnecting;

    void Awake()
    {
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void ConnectToPhoton()
    {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
    }
    public void CreateRoom()
    {
        
    }
    public void Connect()
    {
        // check if connected to server
        if (PhotonNetwork.IsConnected)
        {

        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster()");
        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
            isConnecting = false;
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("OnDisconnected() {0}", cause);
        isConnecting = false;
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed() No random room available, so we create one");
        //either none exist or they are all full, create a room
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom() this client is in a room");
        /*
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("load the scene");
            PhotonNetwork.LoadLevel("LegoScene");
        }
        */
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("LegoScene");
    }

    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.Log("Player entered.");

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

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);
            //Debug.Log("loading room");
            //PhotonNetwork.LoadLevel("LegoScene");
        }
    }

}
