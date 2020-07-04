using UnityEngine;
using System.Collections;

public class Float : MonoBehaviour {

    public float waterLevel = 4;
    public float floatHeight = 2;
    public float bounceDamp = 0.05f;

    private float forceFactor;
    private Vector3 actionPoint;
    private Vector3 upLift;
    private Rigidbody rig;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        actionPoint = transform.position;
        forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);

        if(forceFactor > 0f)
        {
            upLift = -Physics.gravity * (forceFactor - rig.velocity.y * bounceDamp);
            rig.AddForce(upLift, ForceMode.Impulse);
        }
    }
}
