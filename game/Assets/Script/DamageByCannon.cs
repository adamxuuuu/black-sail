using UnityEngine;
using System.Collections;

public class DamageByCannon : MonoBehaviour
{

    private EnemyHealth enemyHealth;

    void Awake()
    {
        enemyHealth = transform.parent.transform.parent.gameObject.GetComponent<EnemyHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "CannonBall")
        {
            Debug.Log("hit");
            enemyHealth.TakeDamage(10);
        }
    }
}

