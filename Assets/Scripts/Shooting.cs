using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;

    public float fireRate = 0.1f;
    float firePeriod;

    // Start is called before the first frame update
    void Start()
    {

    }

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
            }
        }
    }
}
