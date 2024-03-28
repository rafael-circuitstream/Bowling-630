using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameManager manager;
    public PitController pit;
    public UIManager uiManager;

    public ScoreData[] scores = new ScoreData[10];
    public bool frameStrike;
    public bool frameSpare;
    public int currentFrame;
    public int totalScore;
    public int currentFrameScore;

    public int GetTotalScore()
    {
        int totalScore = 0;
        for (int i = 0; i <= currentFrame; i++)
        {
            totalScore += scores[i].score + scores[i].sum;
        }

        return totalScore;
    }
    public void FinishFrame() //WHEN STRIKE OR ALL 10 PINS ARE FALLEN
    {
        pit.ResetAllPins();
        totalScore += currentFrameScore;

        if(!scores[currentFrame].stillCounting)
            uiManager.SetTotalScoreOnCurrentFrame(GetTotalScore(), currentFrame);



        currentFrameScore = 0;
        currentFrame++;

        if(currentFrame == 10)
        {
            //GameOver();
            // OR
            uiManager.FinishGame(totalScore);
        }


    }

    public void GameOver()
    {

    }

    public void SetFrameScore(int pins)
    {

        for (int i = 0; i < currentFrame; i++)
        {
            if (scores[i].stillCounting)
            {
                scores[i].ValidateThrown(pins);
                if (!scores[i].stillCounting)
                {
                    uiManager.SetTotalScoreOnCurrentFrame(GetTotalScore(), i);
                }
            }

        }

        if (pins == 10 && manager.numberOfThrows == 1)
        {
            if (currentFrame < 9) //DONT DO THIS ON LAST FRAME
            {
                scores[currentFrame].throwsToCount = 2;
                scores[currentFrame].stillCounting = true;
            }
            

            uiManager.ShowStrikeImage();
        }

        if(pins == 10 && manager.numberOfThrows == 2)
        {
            if (currentFrame < 9) //DONT DO THIS ON LAST FRAME
            {
                scores[currentFrame].throwsToCount = 1;
                scores[currentFrame].stillCounting = true;
            }

            
            uiManager.ShowSpareImage();
        }

        scores[currentFrame].AddScore(pins);

        uiManager.SetScoreOnCurrentFrame(pins, manager.numberOfThrows, currentFrame);
        currentFrameScore = pins;
    }

}

[System.Serializable]
public class ScoreData
{
    public int score;
    public int sum;
    public int throwsToCount;
    public bool stillCounting;

    public void ValidateThrown(int pins)
    {
        sum += pins;
        throwsToCount--;
        if(throwsToCount <= 0) stillCounting = false;
    }
    public void AddScore(int score)
    {
        this.score = score;
    }
    public int GetFrameTotalScore()
    {
        return 0;
    }
}
