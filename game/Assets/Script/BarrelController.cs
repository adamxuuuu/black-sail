using UnityEngine;
using System.Collections;

public class BarrelController : MonoBehaviour {

    private GameObject player;
    private PlayerHealth playerHealth;
    private PlayerController pc;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        pc = player.GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerCollider" && this.tag == "BadBarrel")
        {
            playerHealth.TakeDamage(20);
            pc.AddCoins(5);  
            Destroy(gameObject);
        }

        if(other.tag == "PlayerCollider" && this.tag == "GoodBarrel")
        {
            pc.AddCoins(10);
            Destroy(gameObject);
        }
    }
}
