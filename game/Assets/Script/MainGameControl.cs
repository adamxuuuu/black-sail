using UnityEngine;
using System.Collections;

public class MainGameControl : MonoBehaviour
{
    public GameObject smallShip;
    public GameObject mediumShip;
    public Transform[] smallSpawnPoints;
    public Transform[] mediumSpawnPoints;

    private GameObject[] enemies;

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Instantiate(smallShip, smallSpawnPoints[0].position, smallSpawnPoints[0].rotation);
        Instantiate(smallShip, smallSpawnPoints[1].position, smallSpawnPoints[1].rotation);
        Instantiate(smallShip, smallSpawnPoints[2].position, smallSpawnPoints[2].rotation);
        Instantiate(smallShip, smallSpawnPoints[3].position, smallSpawnPoints[3].rotation);
        
        Instantiate(mediumShip, mediumSpawnPoints[0].position, mediumSpawnPoints[0].rotation);
        Instantiate(mediumShip, mediumSpawnPoints[1].position, mediumSpawnPoints[1].rotation);
        Instantiate(mediumShip, mediumSpawnPoints[2].position, mediumSpawnPoints[2].rotation);
        Instantiate(mediumShip, mediumSpawnPoints[3].position, mediumSpawnPoints[3].rotation);
        Instantiate(mediumShip, mediumSpawnPoints[4].position, mediumSpawnPoints[4].rotation);
        Instantiate(mediumShip, mediumSpawnPoints[5].position, mediumSpawnPoints[5].rotation);

    }
}