using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Text scoreUI;
    [SerializeField] private GameObject lossPanel;
    private static event Action GameEnded;

    public float Score
    {
        get => score;

        set
        {
            score = value;
            if (scoreUI != null)
                scoreUI.text = "Score: " + score;
        }
    }

    private float score;

    private void Update()
    {
        Score = (int)Time.timeSinceLevelLoad;
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void Start()
    {
        GameEnded += ShowLossPanel;
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
}
