using UnityEngine;
using System.Collections;

public class DestoryByTime : MonoBehaviour {
	public float timeToDestory;

	void Start () {
		Destroy (gameObject, timeToDestory);
	}
}
