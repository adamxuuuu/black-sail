using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class SettingMenu : MonoBehaviour {

    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Slider musicVolumeSlider;
    public AudioSource music;
    public Button applyButton;

    public Resolution[] resolutions;


    private GameSetting gameSettings;
    void OnEnable()
    {
        gameSettings = new GameSetting();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenTogle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });

        resolutions = Screen.resolutions;
        foreach (Resolution res in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(res.ToString()));
        }

        if(File.Exists(Application.persistentDataPath + "/setting.json")){
            Load();
        }
        
    }

    public void OnApplyButtonClick()
    {
        Save();
        GameObject.Find("Option_panel").SetActive(false);
    }

    public void OnFullscreenTogle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
    }

    public void OnTextureQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
    }

    public void OnMusicVolumeChange()
    {
        music.volume = gameSettings.musicVolume = musicVolumeSlider.value;
    }

    public void Save()
    {
        string jsData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/setting.json", jsData);
    }

    public void Load()
    {
        GameSetting gameSettings = JsonUtility.FromJson<GameSetting>(File.ReadAllText(Application.persistentDataPath + "/setting.json"));

        musicVolumeSlider.value = gameSettings.musicVolume;
        textureQualityDropdown.value = gameSettings.textureQuality;
        fullscreenToggle.isOn = gameSettings.fullscreen;
        resolutionDropdown.value = gameSettings.resolutionIndex;

        resolutionDropdown.RefreshShownValue();
    }
}

[System.Serializable]
class GameSetting
{

    public bool fullscreen;
    public int textureQuality;
    public int resolutionIndex;
    public float musicVolume;
}
