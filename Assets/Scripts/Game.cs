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
    private const string MENU_SCENE = "Menu";
    
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
            GameEnded += WaitAfterLoss;
        }
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(GAMEPLAY_SCENE);
        Time.timeScale = 1;
    }

    private void ShowLossPanel()
    {
        lossPanel.SetActive(true);
    }

    public static void EndGame()
    {
        GameEnded.Invoke();
        Time.timeScale = 0;
        Handheld.Vibrate();
    }

    private void WaitAfterLoss()
    {
        StartCoroutine(DelayEndGame());
    }

    private IEnumerator DelayEndGame()
    {
        yield return new WaitForSecondsRealtime(1);
        yield return new WaitUntil(() => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended);

        GameEnded -= ShowLossPanel;
        GameEnded -= UpdateHighscore;
        GameEnded -= WaitAfterLoss;
        SceneManager.LoadScene(MENU_SCENE);
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
