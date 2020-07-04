using UnityEngine;
using System.Collections;

public class DestoryOnImpact : MonoBehaviour {

	public ParticleSystem parti;

    private GameObject player;
    private GameObject enemy;
    private PlayerHealth playerHealth;
    private PlayerController pc;
    private EnemyHealth enemyHealth;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        pc = player.GetComponent<PlayerController>();
        
    }

	void OnTriggerEnter(Collider other){
        if (other.gameObject.name == "Terrain"){
			Instantiate (parti, transform.position, transform.rotation);
			Destroy (gameObject);
		}
        if (other.tag == "DummyCollider") {
            Instantiate(parti, transform.position, transform.rotation);
            enemy = other.transform.parent.transform.parent.gameObject;
            enemyHealth = enemy.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(10);
            pc.AddCoins(1);
            Destroy(gameObject);
        }
        if(other.tag == "Tower")
        {
            Instantiate(parti, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if(other.tag == "PlayerCollider")
        {
            Debug.Log("Hit");
            Instantiate(parti, transform.position, transform.rotation);
            Destroy(gameObject);
            playerHealth.TakeDamage(10);
        }
		
	}
}
