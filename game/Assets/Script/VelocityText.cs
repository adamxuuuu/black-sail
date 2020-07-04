using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VelocityText : MonoBehaviour {

	public GameObject player;
    public GameObject wind;

	private Text txt;
	private Rigidbody rig;


	void Awake(){
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(wind == null)
        {
            wind = GameObject.FindGameObjectWithTag("Wind");
        }
		txt = gameObject.GetComponent<Text> ();
		rig = player.GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){

	}

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            txt.text = "Force: " + rig.velocity.magnitude + "\n"
                + "Direction: " + player.transform.rotation.eulerAngles.y + "\n"
                + "Wind: " + wind.GetComponent<Transform>().rotation.eulerAngles;
        }
    }
}
