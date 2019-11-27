using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // This method is called on connection to the master server (Photon Server)
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to the photon server.");
    }

    // This method is called on connection to the Internet
    public override void OnConnected()
    {
        Debug.Log("Connected to the Internet");
    }
}
