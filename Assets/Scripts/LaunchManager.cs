using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    public GameObject EnterGamePanel;
    public GameObject ConnectionStatusPanel;
    public GameObject LobbyPanel;

    #region Unity Methods

    private void Awake()
    {
        // Load the same level as the master client for other clients
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        EnterGamePanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(false);
    }

    #endregion

    #region Private Methods

    private void CreateAndJoinRoom()
    {
        // Generate a random name for a room
        string randomRoomName = "Room " + Random.Range(0, 10000);
        // Create and set room configurations
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 20;
        // Create a room with generated name and defined configurations
        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }

    #endregion

    #region Public Methods

    // Connect to photon server
    public void ConnectToPhotonServer()
    {
        // Check the connection with photon server
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            ConnectionStatusPanel.SetActive(true);
            EnterGamePanel.SetActive(false);
        }
    }

    // Join an existing random room in server 
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    #endregion

    #region Photon Callbacks

    // In case of failing to join random room in server
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log(message);
        CreateAndJoinRoom();
    }

    // This method is called on connection to the master server (Photon Server)
    public override void OnConnectedToMaster()
    {
        // Display the name of connected player
        Debug.Log(PhotonNetwork.NickName + " connected to the photon server.");
        LobbyPanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
    }

    // This method is called on connection to the Internet
    public override void OnConnected()
    {
        Debug.Log("Connected to the Internet");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name);
        // Load Game play scene
        PhotonNetwork.LoadLevel("GamePlay");
    }

    // This method is called when remote player enters an existing room 
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name
        + " Player Count: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    #endregion
}
