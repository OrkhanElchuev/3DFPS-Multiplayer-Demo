using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject FPSCamera;

    // Start is called before the first frame update
    void Start()
    {
        ControlOnlyMyPlayer();
    }

    // Update is called once per frame
    void Update()
    {

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
            transform.GetComponent<Camera>().enabled = false;
        }
    }
}
