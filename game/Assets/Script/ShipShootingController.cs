using UnityEngine;
using System.Collections;

public class ShipShootingController : MonoBehaviour {

    public GameObject cannonBall;
    private Transform[] guns;

    private float portNextFire;
    private float starNextFire;

    void Awake()
    {
        guns = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update () {
        if (Time.time > portNextFire)
        {
            portNextFire = Time.time + 3.0f;
            foreach (Transform go in guns)
            {
                if (go.gameObject.tag == "PortGuns")
                {
                    Instantiate(cannonBall, go.transform.position, go.transform.rotation);
                }
            }
        }
        if (Time.time > starNextFire)
        {
            starNextFire = Time.time + 3.0f;
            foreach (Transform go in guns)
            {
                if (go.gameObject.tag == "StarBoradGuns")
                {
                    Instantiate(cannonBall, go.transform.position, go.transform.rotation);
                }
            }
        }
    }

    public void firePort()
    {
        if (Time.time > portNextFire)
        {
            portNextFire = Time.time + 3.0f;
            foreach (Transform go in guns)
            {
                if (go.gameObject.tag == "PortGuns")
                {
                    Instantiate(cannonBall, go.transform.position, go.transform.rotation);
                }
            }
        }
    }

    public void fireStarBorad()
    {
        if (Time.time > starNextFire)
        {
            starNextFire = Time.time + 3.0f;
            foreach (Transform go in guns)
            {
                if (go.gameObject.tag == "StarBoradGuns")
                {
                    Instantiate(cannonBall, go.transform.position, go.transform.rotation);
                }
            }
        }
    }
}
