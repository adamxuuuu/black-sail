using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MediumShipControllor : MonoBehaviour
{
    private GameObject player;
    //public Transform[] path;
    private FSMSystem fsm;

    public void SetTransition(Transition t) {
        Debug.Log(t + " fired");
        fsm.PerformTransition(t); }

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Start()
    {
        MakeFSM();
    }

    public void FixedUpdate()
    {
        fsm.CurrentState.Reason(player, gameObject);
        fsm.CurrentState.Act(player, gameObject);
    }


    private void MakeFSM()
    {
        WanderState wander = new WanderState();
        wander.AddTransition(Transition.SawPlayer, StateID.Fighting);

        FightingState fight = new FightingState();
        fight.AddTransition(Transition.LostPlayer, StateID.Wander);

        fsm = new FSMSystem();
       
        fsm.AddState(wander);
        fsm.AddState(fight);

    }
}




