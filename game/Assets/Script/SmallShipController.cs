using UnityEngine;
using System.Collections;

public class SmallShipController : MonoBehaviour {

    private GameObject player;
    //public Transform[] path;
    private FSMSystem fsm;

    public void SetTransition(Transition t)
    {
        Debug.Log(t + " firesd");
        fsm.PerformTransition(t);
    }

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
        wander.AddTransition(Transition.SawPlayer, StateID.Flee);

        FleeState flee = new FleeState();
        flee.AddTransition(Transition.NoPlayer, StateID.Wander);

        fsm = new FSMSystem();

        fsm.AddState(wander);
        fsm.AddState(flee);

    }
}
