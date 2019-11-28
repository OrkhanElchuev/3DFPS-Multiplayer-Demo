using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

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
        }
    }
}
