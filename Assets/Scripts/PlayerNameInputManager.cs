using Photon.Pun;
using UnityEngine;

public class PlayerNameInputManager : MonoBehaviour
{   
    // Handle player name assignment
    public void SetPlayerName(string playerName)
    {
        // Check if player name exists
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("Player name is empty");
            return;
        }
        // Set player name
        PhotonNetwork.NickName = playerName;
    }
}
