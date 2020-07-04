using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public PlayerHealth playerhealth;
    public GameObject enemyShip;
    public Transform[] spawnPoints;

    private GameObject[] dummies;

    void Update()
    {
        dummies = GameObject.FindGameObjectsWithTag("Dummy");
        if(dummies.Length == 0)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        if (playerhealth.currentHealth <= 0f)
        {
            return;
        }

        Instantiate(enemyShip, spawnPoints[0].position, spawnPoints[0].rotation);
        Instantiate(enemyShip, spawnPoints[1].position, spawnPoints[1].rotation);
    }
}
