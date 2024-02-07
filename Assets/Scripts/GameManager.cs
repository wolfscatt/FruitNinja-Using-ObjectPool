using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<GameManager>();
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        score = 0;
        scoreText.text = $"Score: {score}";
    }
    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = $"Score: {score}";
    }
    public void Explode()
    {
        Time.timeScale = 0;
        // Show Game Over Panel
    }
}
