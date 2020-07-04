using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WanderState : FSMState
{
    private NavMeshAgent navAgent;
    private float timer;
    private float wanderTimer = 5.0f;


    public WanderState()
    {
        stateID = StateID.Wander;
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        if (Vector3.Distance(npc.transform.position, player.transform.position) < 300)
        {
            if (npc.GetComponent<MediumShipControllor>() != null)
            {
                npc.GetComponent<MediumShipControllor>().SetTransition(Transition.SawPlayer);

            }
            if (npc.GetComponent<SmallShipController>() != null){
                npc.GetComponent<SmallShipController>().SetTransition(Transition.SawPlayer);
            }
        }

    }

    public override void Act(GameObject player, GameObject npc)
    {
        //Debug.Log("Wandering" + Vector3.Distance(npc.transform.position, player.transform.position));
        navAgent = npc.GetComponent<NavMeshAgent>();
        npc.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 500);
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newWayPoint = RandomNavSphere(npc.transform.position, 100000, -1);
            navAgent.SetDestination(newWayPoint);
            timer = 0;
        }
    }

    private Vector3 RandomNavSphere(Vector3 targetPos, float dist, int layermask)
    {
        Vector3 randomDir = UnityEngine.Random.insideUnitSphere * dist;
        randomDir += targetPos;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDir, out navHit, dist, layermask);
        return navHit.position;
    }
}
