using UnityEngine;
using TMPro;

public class ShellJumpManager : MonoBehaviour
{
    public static ShellJumpManager Instance;

    [Header("Game Settings")]
    public float gameDuration = 30f;

    [Header("Game State")]
    public int score;

    public bool gameRunning;

    [Header("References")]
    public TMP_Text scoreText;

    public TMP_Text timerText;

    public GameObject resultPanel;

    public TMP_Text finalScoreText;

    public GameObject shellItem;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if(!gameRunning)
            return;

        UpdateTimer();

        UpdateUI();
    }

    void StartGame()
    {
        score = 0;

        gameRunning = true;

        resultPanel.SetActive(false);

        shellItem.SetActive(true);
    }

    void UpdateTimer()
    {
        gameDuration -= Time.deltaTime;

        if(gameDuration <= 0)
        {
            EndGame();
        }
    }

    public void AddScore(int amount)
    {
        if(!gameRunning)
            return;

        score += amount;
    }

    void UpdateUI()
    {
        scoreText.text =
            score.ToString();

        timerText.text =

            Mathf.CeilToInt(gameDuration).ToString() + " s";
    }

    void EndGame()
    {
        gameRunning = false;

        resultPanel.SetActive(true);

        shellItem.SetActive(false);

        GameData.ShellJumpScore = score;

        finalScoreText.text =
            "Final Score : " + score;

        Debug.Log("GAME OVER");

        
    }
}