using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    public GameObject TapCountText;
    public Text TimerText;
    public GameManager gameManager;
    public GameObject ResumePanel;
    public GameObject WinPanel;
    public GameObject GameOverPanel;
    public Text HighScoreText;
    public bool isPaused;

    int CounterFontSize;

    public Text CountDownTimerText;

    public AudioClip buttonClip;
    public AudioClip gameplaySound;
    public AudioClip gameWinSound;
    public AudioClip gameLoseMusic;
    public AudioSource btn_audio_source;
    public AudioSource bg_audio_source;

    public AudioClip[] BtnTapSounds;

    public Text LevelNumber;
    public Text TargetScore;
    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.text = "";
        CounterFontSize = TapCountText.GetComponent<Text>().fontSize;
        WinPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        ResumePanel.SetActive(false);
    }

    
    private void Update()
    {
        LevelNumber.text = "Level :" + gameManager.GetLevelNum();
        TargetScore.text = "Target Count :" + gameManager.GetTargetCount();
        TimerText.text = "Timer: "+ gameManager.Timer.ToString("f0");
        if(!gameManager.CountDownTimerHasEnded)
        CountDownTimerText.text = "Get READY " + gameManager.CountDownTimer.ToString("f0");
    }

    public void DisableCountDownTimer()
    {
        CountDownTimerText.gameObject.SetActive(false);
    }

    public void UpdateTapCountText() {
        TapCountText.GetComponent<Text>().fontSize = CounterFontSize * 2;
        TapCountText.GetComponent<Text>().text = gameManager.TapCount.ToString();
        PlayBtnSound();
    }

    public void ShowHighScore()
    {
        HighScoreText.GetComponent<Text>().text = "HighScore : " + GameManager.HighScore.ToString();
    }

    public void BackBtnClicked()
    {
        PlayBtnSound();
        SceneManager.LoadScene(0);
    }

    public void WinBtnClicked()
    {
        WinPanel.SetActive(true);
        GameOverPanel.SetActive(false);
        ResumePanel.SetActive(false);
    }

    public void GameOverBtnClicked()
    {
        WinPanel.SetActive(false);
        GameOverPanel.SetActive(true);
        ResumePanel.SetActive(false);
    }

    public void PauseBtnClicked()
    {
        WinPanel.SetActive(false);
        TimerText.gameObject.SetActive(false);
        GameOverPanel.SetActive(false);
        TapCountText.SetActive(false);
        isPaused = true;
        ResumePanel.SetActive(true);
        PlayBtnSound();
        Time.timeScale = 0;
    }

    public void ShowGameOverOrWinPanel()
    {
        if(gameManager.HasWon == true)
        {
            WinPanel.SetActive(true);
            bg_audio_source.clip = gameWinSound;
            bg_audio_source.Play();
        }else{
            GameOverPanel.SetActive(true);
            bg_audio_source.clip = gameLoseMusic;
            bg_audio_source.Play();
        }
        if (gameManager.TapCount <= 0)
            TapCountText.SetActive(false);
    }

    public void RestartGame()
    {
        PlayBtnSound();
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        PlayBtnSound();
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        Debug.Log("resume");
        isPaused = false;
        ResumePanel.SetActive(false);
        TimerText.gameObject.SetActive(true);
        TapCountText.SetActive(true);
        Time.timeScale = 1;
        PlayBtnSound();
    }

    public void PlayBtnSound()
    {
        int _randomIndex = Random.Range(0, BtnTapSounds.Length);
        AudioClip _clip = BtnTapSounds[_randomIndex];
        btn_audio_source.PlayOneShot(_clip);
    }

    public void NextLevel()
    {
        gameManager.IncreaseLevel();
        Debug.Log("Going to next level" + gameManager.GetLevelNum());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
