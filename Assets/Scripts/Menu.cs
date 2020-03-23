using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Toggle rainToggle;
    [SerializeField] Toggle easyMode;

    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject settingsCanvas;

    [SerializeField] GameObject rain;

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        if (PlayerPrefsController.GetRainToggle() == 1) { rainToggle.isOn = true; } else { rainToggle.isOn = false; }
        if (PlayerPrefsController.GetEasyToggle() == 1) { easyMode.isOn = true; } else { easyMode.isOn = false; }

        //Rain Effect
        if (PlayerPrefsController.GetRainToggle() == 1)
        {
        //Random menu Rain
        //rain.SetActive(Random.Range(0, 2) == 1);
        rain.SetActive(true);
        }
        else
        {
            rain.SetActive(false);
        }

    }

    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);

        }
        else
        {
            Debug.LogWarning("No Music Player found, did you start from Splash Screen?");
        }
    }
    public void SaveAndExit()
    {
        var volume = volumeSlider.value;
        PlayerPrefsController.SetMasterVolume(volume);
        //Player prefs file is an int, but rainToggle + EasyToggle are bools
        if (rainToggle.isOn == true) { PlayerPrefsController.SetRainToggle(1); }
        else { PlayerPrefsController.SetRainToggle(0); }
        if (easyMode.isOn == true) { PlayerPrefsController.SetEasyToggle(1); }
        else { PlayerPrefsController.SetEasyToggle(0); }
        goToMenu();
    }

    public void goToMenu()
    {
        settingsCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }

    public void goToSettings()
    {
        menuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }


}
