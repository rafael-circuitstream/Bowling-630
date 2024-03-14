using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public UIFrame[] _frames;
    public GameObject imageStrike;
    public GameObject imageSpare;

    private void Start()
    {
        
    }
    public void ThrowHappened(int frame, int score, int throwCount)
    {
        _frames[frame].SetScore(score, throwCount);
    }

    public void FrameFinished(int frame, int totalScore)
    {
        _frames[frame].ConcludeFrameUI(totalScore);
    }
}
