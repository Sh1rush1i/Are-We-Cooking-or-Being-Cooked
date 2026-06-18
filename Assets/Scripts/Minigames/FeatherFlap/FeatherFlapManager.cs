using UnityEngine;
using TMPro;

public class FeatherFlapManager : MonoBehaviour
{
    public static FeatherFlapManager Instance;

    public int score;

    public bool gameOver;

    public GameObject gameOverPanel;

    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public BirdController birdController;
    public GameObject gameObstacle;

    public ObstacleSpawner obstacleSpawner;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1;
        gameObstacle.SetActive(true);

    }

    void Update()
    {
        scoreText.text =
           score.ToString();
    }

    public void AddScore()
    {
        if(gameOver) return;

        score+= 1000;
    }

    public void GameOver()
    {
        if(gameOver) return;

        gameOver = true;

        birdController.enabled = false;

        obstacleSpawner.enabled = false;
        obstacleSpawner.CancelInvoke();

        Time.timeScale = 0f;


        gameOverPanel.SetActive(true);

        gameObstacle.SetActive(true);

        GameData.FeatherFlapsScore= score;

        finalScoreText.text =
            "Final Score : " + score;
    }
}