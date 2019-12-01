using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GamePlayManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject playerPrefab;

    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (playerPrefab != null)
            {
                int randomSpawnPoint = Random.Range(-18, 18);
                // Instantiate player object on a random point in a specified range
                PhotonNetwork.Instantiate(playerPrefab.name,
                new Vector3(randomSpawnPoint, 0, randomSpawnPoint), Quaternion.identity);
            }
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name);
    }

    // This method is called when remote player enters an existing room 
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name
        + " Player Count: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }
}
