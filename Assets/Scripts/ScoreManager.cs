using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    static int score = 0;
    private static int bestScore = score;

    public static void IncreaseScore()
    {
        score++;
    }

    public static int GetScore()
    {
        return score;
    }
    public static void SetBestScore()
    {
        if (score > bestScore) bestScore = score;
    }

    public static int GetBestScore()
    {
        return bestScore;
    }

    public static void ResetScore()
    {
        score = 0;
    }
}
