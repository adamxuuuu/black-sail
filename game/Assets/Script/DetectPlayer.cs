using UnityEngine;
using System.Collections;

public class DetectPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter()
    {
        Debug.Log("Player entered");
    }

    void OnTriggerExit()
    {
        Debug.Log("Player Left");
    }
}
