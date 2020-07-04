using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour {
    public GameObject optionPanel;
    public void StartGame()
    {
        StartCoroutine(ChangeLevel(1));
    }

    public void Tutorial()
    {
        StartCoroutine(ChangeLevel(2));
    }
    public void ExitGame() {
        Time.timeScale = 1.0f;
        Application.Quit();
    }

    public void BackToMenu()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(ChangeLevel(0));
    }

    public void Setting()
    {
        optionPanel.SetActive(true);
    }

    IEnumerator ChangeLevel(int level)
    {
        FaderScript fader = GameObject.Find("MenuScriptsHolder").GetComponent<FaderScript>();
        float wait = fader.BeginFade(1);
        yield return new WaitForSeconds(wait);
        Application.LoadLevel(level);
    }
}
