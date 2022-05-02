using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;
using Photon.Realtime;


//TODO LEGO BLOCKS BEING SHARED!
//AVATARS BEING SHARED PROPERLY
//LEAVING ROOM PROPERLY
public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    // Start is called before the first frame update
    public static PhotonRoom room;
    private PhotonView PV;

    private void Awake()
    {
        if(PhotonRoom.room == null)
        {
            PhotonRoom.room = this;
        }
        else
        {
            if(PhotonRoom.room != this)
            {
                Destroy(PhotonRoom.room.gameObject);
                PhotonRoom.room = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        PV = GetComponent<PhotonView>();
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
    public static void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        while(PhotonNetwork.InRoom)
        {

        }
        SceneManager.LoadScene("LegoScene");
        

    }
    public IEnumerator ActualLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        while(PhotonNetwork.InRoom)
            yield return null;
        SceneManager.LoadScene("LegoScene");
    }
    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        //MAYBE FIX THIS
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        //MAYBE FIX THIS
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;

    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Server");
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("entered a room");
        StartGame();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGame()
    {
        if(!PhotonNetwork.IsMasterClient)
            return;
        PhotonNetwork.LoadLevel("LegoSceneMulti");
    }
    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name.Equals("LegoSceneMulti"))
        {
            CreatePlayer();
        }
    }
    private void CreatePlayer()
    {
        PhotonNetwork.Instantiate("Character", new Vector3(0,3,0), Quaternion.identity, 0);
    }
}
