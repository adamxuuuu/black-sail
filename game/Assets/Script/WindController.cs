using UnityEngine;
using System.Collections;

public class WindController : MonoBehaviour {

    void Start()
    {
        StartCoroutine(changeWind(3.0f));
    }

    public IEnumerator changeWind(float wait)
    {
        while (true)
        {
            GetComponent<WindZone>().windMain = Random.Range(-50.0f, 50.0f);
            GetComponent<WindZone>().transform.rotation = Random.rotation;
            yield return new WaitForSeconds(wait);
        }
    }
}
