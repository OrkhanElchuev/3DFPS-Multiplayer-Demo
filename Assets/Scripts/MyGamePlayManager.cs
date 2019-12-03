using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class MyGamePlayManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject playerPrefab;
    public static MyGamePlayManager instance;

    #region Unity Methods
    // On awake make sure there is only one MyGamePlayManager object in the scene
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (playerPrefab != null)
            {
                // Hide cursor for player in game play scene
                Cursor.visible = false;
                int randomSpawnPoint = Random.Range(-18, 18);
                // Instantiate player object on a random point in a specified range
                PhotonNetwork.Instantiate(playerPrefab.name,
                new Vector3(randomSpawnPoint, 0, randomSpawnPoint), Quaternion.identity);
                // To avoid multiple audio listener in one scene warning
                FindObjectOfType<Camera>().GetComponent<AudioListener>().enabled = false;
            }
        }
    }

    #endregion

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    #region Photon Callbacks

    public override void OnLeftRoom()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("GameLauncherScene");
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

    #endregion
}
