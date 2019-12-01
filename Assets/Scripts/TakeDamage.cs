using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TakeDamage : MonoBehaviour
{
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Remote procedure call to apply this method for all clients
    [PunRPC] public void ReceiveDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
    }
}
