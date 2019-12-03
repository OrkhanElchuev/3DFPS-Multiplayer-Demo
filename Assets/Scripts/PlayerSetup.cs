using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject FPSCamera;
    [SerializeField] TextMeshProUGUI playerName;

    // Start is called before the first frame update
    void Start()
    {
        ControlOnlyMyPlayer();
        SetPlayerUI();
    }

    // Disable the movement controller and camera on other players
    // This is needed to test game on the same computer with multiple game windows 
    private void ControlOnlyMyPlayer()
    {
        if (photonView.IsMine)
        {
            transform.GetComponent<MovementController>().enabled = true;
            FPSCamera.GetComponent<Camera>().enabled = true;
        }
        else
        {
            transform.GetComponent<MovementController>().enabled = false;
            FPSCamera.GetComponent<Camera>().enabled = false;
        }
    }

    private void SetPlayerUI()
    {
        if (playerName != null)
        {
            // Set player's name 
            playerName.text = photonView.Owner.NickName;
        }
    }
}
