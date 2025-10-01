using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int TapCount;
    public GameplayUI gameplayUI;
    public float DefaultTimerValue = 5;
    public float Timer;
    public bool TimerHasEnded = false;
    int TargetCount;
    public bool HasWon;
    public static int HighScore;
    public float CountDownTimer;
    public bool CountDownTimerHasEnded;

    int LevelNum = 1;
    int baseLevelMultiplier = 10;
    // public AdsManager adsManager;


    // Start is called before the first frame update
    void Start()
    {
        CountDownTimer = 3;
        CountDownTimerHasEnded = false;
        GetHighScore();
        Timer = DefaultTimerValue;

       
        LevelNum = PlayerPrefs.GetInt("LevelNum",1);
        
        //if (PlayerPrefs.HasKey("LevelNum"))
        //{
        //    LevelNum = PlayerPrefs.GetInt("LevelNum");
        //}
        TargetCount = GetTapTargetCount(LevelNum);

        Debug.Log("Target Count is : " + TargetCount);
    }

    // Update is called once per frame
    void Update()
    {
        if(!CountDownTimerHasEnded)
        {
            CountDownTimer -= Time.deltaTime;
            if(CountDownTimer <= 0) 
            {
                CountDownTimerHasEnded = true;
                gameplayUI.DisableCountDownTimer();
                Debug.Log("Countdown" + CountDownTimerHasEnded);
            }
        }

       
        if(CountDownTimerHasEnded && TimerHasEnded == false)
        {
            Timer -= Time.deltaTime;
            if(Timer <= 0) 
            {
                TimerHasEnded = true;
                Timer = 0;
                if(TapCount > TargetCount)
                {
                    HasWon = true;
                }
                else{
                    HasWon = false;
                }
                // Game is Over!
                if(TapCount > HighScore)
                HighScore = TapCount;
                //adsManager.ShowInterstitialAd();
                gameplayUI.ShowGameOverOrWinPanel();
                gameplayUI.ShowHighScore();
                SaveHighScore();
                //Debug.Log("High Score is : " + HighScore);
            }
            
            if(!gameplayUI.isPaused && Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                return;
                TapCount = TapCount + 1;

                gameplayUI.UpdateTapCountText();
            }
        }
    }
    
    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        //Debug.Log("High Score Saved");
    }

    public void GetHighScore()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
    }

    public void ResetHighScore()
    {
        HighScore = 0;
        PlayerPrefs.SetInt("HighScore", HighScore);
        HighScore = PlayerPrefs.GetInt("HighScore");
        gameplayUI.RestartGame();
    }


    int GetTapTargetCount(int _levelNum)
    {
        int _temp = 0;
        _temp = baseLevelMultiplier * _levelNum;
        return _temp;
    }

    public void IncreaseLevel()
    {
        LevelNum++;

        PlayerPrefs.SetInt("LevelNum", LevelNum);
    }

    public int GetLevelNum()
    {
        return LevelNum;
    }

    public int GetTargetCount()
    {
        return TargetCount;
    }
}
