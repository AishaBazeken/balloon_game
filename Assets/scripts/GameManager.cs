using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float spawnInterval = 1f;
    public float balloonSpeed = 1f;
    public Text currentScoreText;
    public Text highScoreText;

    private int currentScore = 0;
    private int highScore = 0;
    private float timeSinceLastSpawn = 0f;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
        currentScoreText.text = "Score: " + currentScore;
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnBalloon();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnBalloon()
    {
        float randomX = Random.Range(-5f, 5f);
        Vector3 spawnPosition = new Vector3(randomX, -6f, 0f);
        Instantiate(balloonPrefab, spawnPosition, Quaternion.identity);
    }

    public void IncreaseScore()
    {
        currentScore++;
        currentScoreText.text = "Score: " + currentScore;
    }

    public void GameOver()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        // Показать сообщение о завершении игры
        highScoreText.text = "High Score: " + highScore;
        currentScoreText.text = "Game Over! Final Score: " + currentScore;
        Time.timeScale = 0; // Остановить игру
    }
}
