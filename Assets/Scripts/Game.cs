using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Text scoreUI;
    [SerializeField] private Text highscoreUI;
    [SerializeField] private GameObject lossPanel;
    private static event Action GameEnded;
    private const string GAMEPLAY_SCENE = "Gameplay";

    public int Score
    {
        get => score;

        set
        {
            score = value;
            if (scoreUI != null)
                scoreUI.text = "Score: " + score;
        }
    }

    private int score;
    private int highscore;

    private void Update()
    {
        Score = (int)Time.timeSinceLevelLoad;
    }

    private void Start()
    {
        SetHighscore();

        if (SceneManager.GetActiveScene().name == GAMEPLAY_SCENE)
        {
            GameEnded += ShowLossPanel;
            GameEnded += UpdateHighscore;
        }
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(GAMEPLAY_SCENE);
    }

    private void ShowLossPanel()
    {
        lossPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public static void EndGame()
    {
        GameEnded.Invoke();
    }

    private void SetHighscore()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
        }
        else
            highscore = 0;

        highscoreUI.text = "" + highscore;
    }

    private void UpdateHighscore()
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
            highscoreUI.text = "" + highscore;
            highscoreUI.gameObject.SetActive(true);
        }
    }

}
