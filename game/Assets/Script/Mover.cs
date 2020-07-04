using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        Rigidbody rig = GetComponent<Rigidbody>();
        rig.AddForce(transform.up * speed);
	}
	
}
