
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text energyText;
    [SerializeField] int maxEnergy;
    [SerializeField] int energyRefillDuration;

    [SerializeField] AndroidNotificationManager notificationManager; 

    int energy;

    const string ENERGY_KEY = "Energy";
    const string ENERGYREADY_KEY = "EnergyReady";


    public void Start()
    {
        scoreText.text = "HighScore: "+ PlayerPrefs.GetInt(ScoreSystem.HIGHSCORE_KEY,0).ToString();
        EnergyCheck();
    }
    // energyready nezaman enerjinin dolmasý gerektiðini tutuyor

    public void Update()
    {
        EnergyCheck();
    }
    void EnergyCheck()
    {

        energy = PlayerPrefs.GetInt(ENERGY_KEY, maxEnergy);

        if (energy == 0)
        {
            string energyReady = PlayerPrefs.GetString(ENERGYREADY_KEY, string.Empty);

            if (energyReady != string.Empty)
            {
                System.DateTime energyReadyDate = System.DateTime.Parse(energyReady);

                if (System.DateTime.Now > energyReadyDate)
                {
                    energy = maxEnergy;
                    PlayerPrefs.SetInt(ENERGY_KEY, energy);
                }
            }

        }

        energyText.text = $"Energy: {energy}";
    }
    public void PlayGame()
    {
        if (energy < 1) return;

        energy--;
        PlayerPrefs.SetInt(ENERGY_KEY, energy);

        if(energy == 0)
        {
            System.DateTime energyReadyTime = System.DateTime.Now.AddMinutes(energyRefillDuration);
            PlayerPrefs.SetString(ENERGYREADY_KEY,energyReadyTime.ToString());

#if UNITY_ANDROID
            notificationManager.ScheduleNotification(energyReadyTime);
#endif
        }

        SceneManager.LoadScene("Game");
    }
}
