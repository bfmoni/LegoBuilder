using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo PI;
    public int [] avatar_color_array = new int [6];
    public int [] avatar_piece_array = new int [4];
    public Material[] avatar_colors;
    public GameObject[] hat_array;
    public Material[] face_array;
    public GameObject[] item_array;
    public GameObject[] back_array;
    //private ExitGames.Client.Photon.Hashtable playerProperties;

    private void OnEnable()
    {
        if(PlayerInfo.PI == null)
        {
            PlayerInfo.PI = this;
        }
        else
        {
            if(PlayerInfo.PI != this)
            {
                Destroy(PlayerInfo.PI.gameObject);
                PlayerInfo.PI = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
    

    void Start()
    {
        if(PlayerPrefs.HasKey("color0"))
        {
            for(int i = 0; i < avatar_color_array.Length; i++)
            {
                avatar_color_array[i] = PlayerPrefs.GetInt("color" + i);
            }
            for(int i = 0; i < avatar_piece_array.Length; i++)
            {
                avatar_piece_array[i] = PlayerPrefs.GetInt("piece" + i);
            }
        }

    }

}
