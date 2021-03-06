using System.Threading;
using UnityEngine;

public static class ScoreManager
{
    static ScoreManager()
    {
        bestScore = GameDataLocalStorage.LoadData().score;
    }
    
    private static int currentScore;
    public static int bestScore;
    private static bool terminateCount;

    public static void StartScore()
    {
        currentScore = 0;
        terminateCount = false;
        Thread thread = new Thread(IncrementScore);
        thread.Start();
    }

    public static void finishScore()
    {
        terminateCount = true;
        if (bestScore < currentScore)
        {
            bestScore = currentScore;
            GameDataLocalStorage.SaveScore(bestScore);
        }
    }

    public static int CurrentScore()
    {
        return currentScore;
    }

    public static int BestScore()
    {
        return bestScore;
    }

    static void IncrementScore()
    {
        while (!terminateCount)
        {
            Thread.Sleep(100);
            currentScore++;
        }
    }
}