using UnityEngine;
using System.Collections;

public class Wander : MonoBehaviour {

    public float wanderRange;
    public float wanderTimer;
    public float wanderSpeed;

    private Transform target;
    private NavMeshAgent navAgent;
    private float timer;
    private Rigidbody rig;

    void OnEnable()
    {
        rig = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }
	
	void Update () {
        rig.AddRelativeForce(Vector3.forward * wanderSpeed);
        timer += Time.deltaTime;

        if(timer >= wanderTimer)
        {
            Vector3 newWayPoint = RandomNavSphere(transform.position, wanderRange, -1);
            navAgent.SetDestination(newWayPoint);
            timer = 0;
        }
	}

    private Vector3 RandomNavSphere(Vector3 targetPos, float dist, int layermask) 
    {
        Vector3 randomDir = Random.insideUnitSphere * dist;
        randomDir += targetPos;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDir, out navHit, dist, layermask);
        return navHit.position;
    }
}
