using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameManager manager;
    public PitController pit;
    public UIManager uiManager;

    public int currentFrame;
    public int totalScore;
    public int currentFrameScore;

    public void FinishFrame() //WHEN STRIKE OR ALL 10 PINS ARE FALLEN
    {
        pit.ResetAllPins();
        totalScore += currentFrameScore;
        uiManager.SetTotalScoreOnCurrentFrame(totalScore, currentFrame);
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
        if(pins == 10 && manager.numberOfThrows == 1)
        {
            uiManager.ShowStrikeImage();
        }

        if(pins == 10 && manager.numberOfThrows == 2)
        {
            uiManager.ShowSpareImage();
        }

        uiManager.SetScoreOnCurrentFrame(pins, manager.numberOfThrows, currentFrame);
        currentFrameScore = pins;
    }

}
