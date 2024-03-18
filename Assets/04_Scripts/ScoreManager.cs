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
        currentFrameScore = 0;
        currentFrame++;
    }

    public void SetFrameScore(int pins)
    {
        uiManager.SetScoreOnCurrentFrame(pins, manager.numberOfThrows, currentFrame);
        currentFrameScore = pins;
    }

}
