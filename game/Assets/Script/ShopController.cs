using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopController : MonoBehaviour {

    public Button healthUp;

    private GameObject player;
    private PlayerHealth playerHealth;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(player + " entered shop");
        if (other.tag == "PlayerCollider")
        {
            healthUp.interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerCollider")
        {
            healthUp.interactable = false;
        }
    }

    public void BuyHealth()
    {
        playerHealth.Repair(10);
    }
}
