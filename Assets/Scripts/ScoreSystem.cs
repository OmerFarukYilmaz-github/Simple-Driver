using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    private float score=0;
    public const string HIGHSCORE_KEY="HighScore";


    // Update is called once per frame
    void Update()
    {
        score += 10 * Time.deltaTime;

        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public void OnDestroy()
    {
        // öyle bir deger yoksa 0 dönecek
        int highScore = PlayerPrefs.GetInt(HIGHSCORE_KEY, 0);

        if (score > highScore)
        {
            PlayerPrefs.SetInt(HIGHSCORE_KEY, Mathf.FloorToInt(score));
        }
    }
}
