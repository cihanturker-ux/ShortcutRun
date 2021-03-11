using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isStarted = false;
    private bool isNotStarted = false;
    private bool isSettingsActive = false;
    private bool isSoundActive = false;
    private bool isVibrateActive = false;

    public GameObject settings;
    public GameObject settingsPanel;
    public GameObject settingsPanelOffButton;
    public GameObject soundOnButton;
    public GameObject soundOffButton;
    public GameObject vibrateOnButton;
    public GameObject vibrateOffButton;
    public GameObject playButton;

    private void Update()
    {
        if (!isNotStarted && Input.GetMouseButtonDown(0))
        {
            isStarted = true;
            isNotStarted = true;
            playButton.SetActive(false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        GameManager.isStarted = false;
    }

    public void Settings()
    {
        settingsPanel.SetActive(!isSettingsActive);
        isSettingsActive = !isSettingsActive;
        if (isSettingsActive)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void SettingsPanelOff()
    {
        settingsPanel.SetActive(!isSettingsActive);
        isSettingsActive = !isSettingsActive;
    }

    public void SoundButton()
    {
        soundOffButton.SetActive(!isSoundActive);
        isSoundActive = !isSoundActive;
    }

    public void Vibrate()
    {
        vibrateOffButton.SetActive(!isVibrateActive);
        isVibrateActive = !isVibrateActive;
    }
}
