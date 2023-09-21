using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI finalScoreText;

    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    public void Reset()
    {
        gameOverText.gameObject.SetActive(false);
        finalScoreText.gameObject.SetActive(false);
    }
}
