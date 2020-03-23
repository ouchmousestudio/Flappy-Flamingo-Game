using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master volume";
    const string HIGH_SCORE_KEY = "high score";
    const string RAIN_TOGGLE_KEY = "rain toggle";
    const string EASY_TOGGLE_KEY = "easy toggle";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;


    public static void SetMasterVolume(float volume)
    { 
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            //Debug.Log("Master volume set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume is out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 0.7f);
    }

    public static void SetHighScore(int highScore)
    {
        PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
    }

    public static void SetRainToggle(int rainToggle)
    {
        PlayerPrefs.SetInt(RAIN_TOGGLE_KEY, rainToggle);
    }

    public static int GetRainToggle()
    {
        return PlayerPrefs.GetInt(RAIN_TOGGLE_KEY, 1);
    }

    public static void SetEasyToggle(int easyMode)
    {
        PlayerPrefs.SetInt(EASY_TOGGLE_KEY, easyMode);
    }

    public static int GetEasyToggle()
    {
        return PlayerPrefs.GetInt(EASY_TOGGLE_KEY, 0);
    }
}
