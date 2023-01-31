using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameController : MonoBehaviour {

    [SerializeField] private Image timerImage;
    [SerializeField] private float gameTime;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private TextMeshProUGUI highScoreText;
    public int score;
    private int highScore;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource alarmSource;
    [SerializeField] private AudioClip clipIntro;
    [SerializeField] private AudioClip clipGameTheme;
    [SerializeField] private AudioClip clipAlarmLong;
    [SerializeField] private AudioClip clipAlarmShort;

    private bool alarmStarted;

    public enum GameState {
        Waiting,
        Playing,
        GameOver
    }

    public static GameState currentGameState;

    private void Awake() {
        currentGameState = GameState.Waiting;
        UpdateGameAudio(audioSource, clipIntro, true);


        if (PlayerPrefs.HasKey("HighScore")) {
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }

    }

    private void Start() {
        score = 0;
        scoreText.text = "0";
    }

    private void Update() {
        
        if(currentGameState == GameState.Playing) {
            UpdateTimer();
        }
        
    }

    private void UpdateTimer() {
        timerImage.fillAmount = timerImage.fillAmount - (Time.deltaTime / gameTime);

        if(timerImage.fillAmount <= .2 && !alarmStarted) {
            StartAlarm();
        }

        if(timerImage.fillAmount<=0 && currentGameState == GameState.Playing) {
            StopAlarm();
        }
        
        if(timerImage.fillAmount <= 0) {
            GameOver();
        }


    }

    public void UpdateScore(int points) {
        if(currentGameState != GameState.Playing) 
            return;
        
        score = score + points;
        //Debug.Log(score);
        scoreText.text = score.ToString();
    }

    public void StartGame() {
        currentGameState = GameState.Playing;
        UpdateGameAudio(audioSource, clipGameTheme, true);
        
    }

    private void GameOver() {
        currentGameState = GameState.GameOver;
        UpdateGameAudio(audioSource, clipIntro, true);

        //Set GameOver screen active
        gameOverCanvas.SetActive(true);

        //Update PlayerPrefs High Score if final score > Highest Score
        if(score > PlayerPrefs.GetInt("HighScore")) {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }
    public void ResetGame() {
        currentGameState = GameState.Waiting;

        //put timer to initial setting
        timerImage.fillAmount = 1f;

        //reset score
        score = 0;
        scoreText.text = "0";

    }

    private void StartAlarm() {
        alarmSource.clip = clipAlarmLong;
        alarmSource.loop = true;
        alarmSource.Play();
        alarmStarted = true;
    }

    private void StopAlarm() {
        alarmSource.clip = clipAlarmShort;
        alarmSource.loop = false;
        alarmSource.Play();
    }

    private void UpdateGameAudio(AudioSource source, AudioClip clipToPlay, bool shouldLoop) {
       source.clip = clipToPlay;
       source.Play();
       source.loop = shouldLoop;

    }

}
