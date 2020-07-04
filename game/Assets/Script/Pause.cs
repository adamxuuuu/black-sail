using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public GameObject menu;

    private bool pause;

    void Awake()
    {
        menu.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if(pause == true)
            {
                Time.timeScale = 1.0f;
                menu.gameObject.SetActive(false);
                pause = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                menu.gameObject.SetActive(true);
                pause = true;
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        menu.gameObject.SetActive(false);
    }
}
