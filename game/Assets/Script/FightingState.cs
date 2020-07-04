using UnityEngine;
using System.Collections;
using System;

public class FightingState : FSMState {

    public ShipShootingController ssc;

    public FightingState()
    {
        stateID = StateID.Fighting;
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        if (Vector3.Distance(npc.transform.position, player.transform.position) >= 300)
        {
            npc.GetComponent<MediumShipControllor>().SetTransition(Transition.LostPlayer);
        }
    }


    public override void Act(GameObject player, GameObject npc)
    {
        ssc = npc.GetComponent<ShipShootingController>();
        npc.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 250);
        npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, player.transform.rotation, Time.deltaTime / 1);
        Vector3 toPlayer = player.transform.position - npc.transform.position;

        if(Vector3.Angle(toPlayer, npc.transform.right) < 90.0f)
        {
            ssc.fireStarBorad();            
        }
        if(Vector3.Angle(toPlayer, -npc.transform.right) < 90.0f)
        {
            ssc.firePort();
        }
    }
}
