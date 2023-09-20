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

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    
    [SerializeField]private Transform spawnPoint;

    private RotateBoard _rotateBoard;

    private void Start()
    {
        _rotateBoard = FindObjectOfType<RotateBoard>();
        gameOverText.gameObject.SetActive(false);
        scoreObject.score = 0;
    }

    public void Reset()
    {
        lives = 3;
        scoreObject.score = 0;
        gameOverText.gameObject.SetActive(false);
        _rotateBoard.enabled = true;
        transform.position = spawnPoint.position;
        finalScoreText.gameObject.SetActive(false);

    }
    
    private void Update()
    {
        if (lives == 0)
        {
            gameOverText.gameObject.SetActive(true);
            _rotateBoard.enabled = false;
            gameObject.SetActive(false);
            finalScoreText.gameObject.SetActive(true);
            finalScoreText.text = "Your score is " + scoreObject.score;
        }

        scoreText.text = "Points " + scoreObject.score.ToString();
        livesText.text = "Tries " + lives.ToString();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Death Barrier"))
        {
            transform.position = spawnPoint.position;
            lives--;
            Death death = other.collider.GetComponent<Death>();
            scoreObject.score+= death.scoreToGive;

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            Debug.Log("You Win");
            transform.position = spawnPoint.position;
            lives--;
            scoreObject.score += 20;
        }
    }
}
