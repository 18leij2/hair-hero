using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public TextMeshProUGUI finalScore;
    public GameObject gameover;

    // Start is called before the first frame update
    void Start()
    {
        gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString() + " points";
    }

    public void AddScore(int score)
    {
        this.score += score;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameover.SetActive(true);
        finalScore.text = "Final Score: " + score.ToString();
    }
}
