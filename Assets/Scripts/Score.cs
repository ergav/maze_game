using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Score")]
public class Score : ScriptableObject
{
    public int score;

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}