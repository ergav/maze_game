using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int lives;

    [SerializeField] private Score scoreObject;

    [SerializeField] private GameObject[] deathBarriers;
    
    //private int score;

    [SerializeField] private UIManager uiManager;
    
    // [SerializeField] private TextMeshProUGUI scoreText;
    // [SerializeField] private TextMeshProUGUI gameOverText;
    // [SerializeField] private TextMeshProUGUI livesText;
    // [SerializeField] private TextMeshProUGUI finalScoreText;

    
    [SerializeField]private Transform spawnPoint;

    private RotateBoard _rotateBoard;

    private void Start()
    {
        _rotateBoard = FindObjectOfType<RotateBoard>();
        scoreObject.score = 0;
        uiManager = FindObjectOfType<UIManager>();
    }

    public void Reset()
    {
        lives = 3;
        scoreObject.score = 0;
        _rotateBoard.enabled = true;
        transform.position = spawnPoint.position;
        uiManager.Reset();

    }
    
    private void Update()
    {
        if (lives == 0)
        {
            uiManager.gameOverText.gameObject.SetActive(true);
            _rotateBoard.enabled = false;
            gameObject.SetActive(false);
            uiManager.finalScoreText.gameObject.SetActive(true);
            uiManager.finalScoreText.text = "Your score is " + scoreObject.score;
        }

        uiManager.scoreText.text = "Points " + scoreObject.score.ToString();
        uiManager.livesText.text = "Tries " + lives.ToString();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Death Barrier"))
        {
            transform.position = spawnPoint.position;
            lives--;
            Death death = other.collider.GetComponent<Death>();
            scoreObject.AddScore(death.scoreToGive);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            Debug.Log("You Win");
            transform.position = spawnPoint.position;
            lives--;
            scoreObject.AddScore(20);
        }
    }
}
