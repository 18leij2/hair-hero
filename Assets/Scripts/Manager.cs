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
    public TextMeshProUGUI waveText;
    public List<GameObject> startList;
    public GameObject StartScreen;
    public GameObject InstructionScreen;
    private bool start = true;
    private bool instruction = false;

    // Start is called before the first frame update
    void Start()
    {
        gameover.SetActive(false);

        foreach (GameObject obj in startList)
        {
            obj.SetActive(false);
        }
        StartScreen.SetActive(true);
        InstructionScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString() + " points";

        if (Input.GetKeyDown(KeyCode.Return) && start)
        {
            StartScreen.SetActive(false);
            InstructionScreen.SetActive(true);
            start = false;
            instruction = true;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && instruction)
        {
            InstructionScreen.SetActive(false);
            instruction = false;
            foreach (GameObject obj in startList)
            {
                obj.SetActive(true);
            }
        }
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

    public void SetWave(int wave)
    {
        waveText.text = "Wave " + wave.ToString();
    }
}
