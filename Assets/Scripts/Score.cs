using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score;

    private Text scoreText;

    public Spawner1 spawner2;

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        if (score >= 1000 && !spawner2.start)
        {
            spawner2.StartGame();
        }
    }

    public void AddScore(int score)
    {
        this.score += score;
        UpdateScore();
    }

    public void Enlarge()
    {
        scoreText.fontSize = 70;
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
