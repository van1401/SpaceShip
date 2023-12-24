using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public int scorePlayer;
    public TMP_Text scoreTxt;
    public TMP_Text levelTxt;
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject LosePanel;
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject WarningQuitPanel;
    [SerializeField] GameObject Portal;
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject warningBoss;   
    [SerializeField] GameObject UpgradeWing;



    private void Start()
    {

    }

    private void Awake()
    {
        this.RegisterListener(EventID.EnemyDie, (sender, param) =>
        {
            addScore();
            this.PostEvent(EventID.checkScore);
        });
        this.RegisterListener(EventID.BossDie, (sender, param) =>
        {
            bossScore();
        });
        this.RegisterListener(EventID.LevelUp, (sender, param) =>
        {
            levelTxt.text = Player.Instance.level.ToString();
        });
        if (Instance == null)
        {
            Instance = this;
        }

        bossAppear();
        //defeatBoss();
        UpgradeWingAppear();
    }

    void Update()
    {
        scoreTxt.text = "Score:" + scorePlayer.ToString();
        YouWin();
    }

    public void addScore()
    {
        scorePlayer += 10;
    }
    
    public void bossScore()
    {
        scorePlayer += 1000;
    }

    public void Play()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }
    public void YouLose()
    {
        LosePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void YouWin()
    {
        if (Boss.GetComponent<BossController>()._enemyHp <= 0)
        {
            WinPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void WarningQuitOff()
    {
        WarningQuitPanel.SetActive(false);
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }


    public void bossAppear()
    {
        this.RegisterListener(EventID.SpawnDone, (sender, param) =>
        {
            warningBoss.SetActive(true);
            LeanTween.delayedCall(8f, () =>
            {
                warningBoss.SetActive(false);
            });
            Boss.SetActive(true);
            GetComponent<BulletController>().damage += 10;
        });
    }


    public void defeatBoss()
    {
        this.RegisterListener(EventID.BossDie, (sender, param) =>
        {
            Portal.SetActive(true);
        });
    }
    
    public void UpgradeWingAppear()
    {
        this.RegisterListener(EventID.checkScore, (sender, param) =>
        {
            if (scorePlayer > 800 && scorePlayer <= 900)
            {
                UpgradeWing.SetActive(true);
            }
        });
    }
}
