using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {

    public Transform target;
    public GameObject cannonBall;
    public float aimSpeed;
    public float fireRate;

    private float nextFire;

    void Update()
    {
        Quaternion newRotation = Quaternion.LookRotation(transform.position - target.position, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * aimSpeed);

        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(cannonBall, transform.position, transform.rotation);
        }
    }
}
