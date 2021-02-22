using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class connectServer : MonoBehaviourPunCallbacks,IInRoomCallbacks
{

    private string gameVersion;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        gameVersion = "0.001";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


  

    public void connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        /*
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }*/
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log(gameObject.name);
        Debug.Log("Connected to Master");
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room");
        PhotonNetwork.LoadLevel("Sin Scene");
    }
}
