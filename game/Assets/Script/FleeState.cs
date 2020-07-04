using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class FleeState : FSMState
{
    private NavMeshAgent navAgent;
    private EnemyHealth eh;
    public GameObject barrel;

    public FleeState()
    {
        stateID = StateID.Flee;
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        
        if (Vector3.Distance(npc.transform.position, player.transform.position) > 300)
        {

            if (npc.GetComponent<MediumShipControllor>() != null)
            {
                npc.GetComponent<MediumShipControllor>().SetTransition(Transition.NoPlayer);
            }
            if (npc.GetComponent<SmallShipController>() != null)
            {
                npc.GetComponent<SmallShipController>().SetTransition(Transition.NoPlayer);
            }
        }
    }

    public override void Act(GameObject player, GameObject npc)
    {
        eh = npc.GetComponent<EnemyHealth>();
        //Debug.Log("Fleeing" + Vector3.Distance(npc.transform.position, player.transform.position));
        navAgent = npc.GetComponent<NavMeshAgent>();
        npc.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 700);
        Vector3 runToPos = Escape(player, npc, 300, -1);
        navAgent.SetDestination(runToPos);
        eh.SpawnBarrel();
    }


    private Vector3 Escape(GameObject player, GameObject npc, float dist, int layermask)
    {
        npc.transform.rotation = Quaternion.LookRotation(npc.transform.position - player.transform.position);
        Vector3 runTo = npc.transform.position + npc.transform.forward * 10;
        NavMeshHit navHit;
        NavMesh.SamplePosition(runTo, out navHit, dist, layermask);
        return navHit.position;
    }

    
}
