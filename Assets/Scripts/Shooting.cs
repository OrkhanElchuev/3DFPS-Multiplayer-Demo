using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Shooting : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;

    public float fireRate = 0.1f;
    float firePeriod;

    // Update is called once per frame
    void Update()
    {
        if (firePeriod < fireRate)
        {
            firePeriod += Time.deltaTime;
        }
        HandleShootingWithRays();
    }

    private void HandleShootingWithRays()
    {
        // If left mouse button is clicked and shooting is allowed
        if (Input.GetButton("Fire1") && firePeriod > fireRate)
        {
            // Reset fire period
            firePeriod = 0.0f;
            RaycastHit hit;
            // Send a ray from the center of camera view
            Ray ray = FPSCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            // Send a ray with the limited maximum distance
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.collider.gameObject.name);
                // Check if ray is colliding with other player and not with himself 
                if (hit.collider.gameObject.CompareTag("Player") 
                && !hit.collider.gameObject.GetComponent<PhotonView>().IsMine)
                {
                    hit.collider.gameObject.GetComponent<PhotonView>().RPC("ReceiveDamage",
                    RpcTarget.AllBuffered, 10f);
                }
            }
        }
    }
}
