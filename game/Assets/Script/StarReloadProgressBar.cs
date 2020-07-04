using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarReloadProgressBar : MonoBehaviour {
	public Scrollbar bar;

	private float growSpeed;
	private GameObject player;
	private float fireRate;

	public void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		fireRate = player.GetComponent<PlayerController> ().fireRate;
		growSpeed = 1/fireRate;
	}

	public void Start(){
		StartCoroutine (barGrow());
	}

	public void Update(){
		if (Input.GetButton ("Fire2") && bar.size == 1) {
			bar.size = 0;
		}

	}

	IEnumerator barGrow(){
        yield return new WaitForSeconds(1);
		while (true) {
			yield return new WaitForSeconds (1);
			bar.size += growSpeed;
		}
	}
}
