using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    public GameObject EnterGamePanel;
    public GameObject ConnectionStatusPanel;

    private void Start()
    {
        EnterGamePanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
    }

    #region Photon Callbacks

    // This method is called on connection to the master server (Photon Server)
    public override void OnConnectedToMaster()
    {
        // Display the name of connected player
        Debug.Log(PhotonNetwork.NickName + " connected to the photon server.");
    }

    // This method is called on connection to the Internet
    public override void OnConnected()
    {
        Debug.Log("Connected to the Internet");
    }

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
    #endregion
}
