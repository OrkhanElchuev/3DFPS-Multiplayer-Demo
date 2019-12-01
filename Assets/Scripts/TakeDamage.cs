using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviourPunCallbacks
{
    [SerializeField] Image healthBar;
    private float health;
    public float initialHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        health = initialHealth;
        // We need to get a ratio of health for Image filling
        healthBar.fillAmount = health / initialHealth;
    }

    // Remote procedure call to apply this method for all clients
    [PunRPC]
    public void ReceiveDamage(float damage)
    {
        health -= damage;
        //Debug.Log(health);
        healthBar.fillAmount = health / initialHealth;
        if (health <= 0f)
        {
            Die();
        }
    }
    
    // Handle player death
    void Die()
    {
        if (photonView.IsMine)
        {
            MyGamePlayManager.instance.LeaveRoom();
        }
    }
}
