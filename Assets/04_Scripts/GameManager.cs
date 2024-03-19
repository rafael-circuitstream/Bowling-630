using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numberOfThrows;
    public GameObject ballPrefab;
    public ScoreManager scoreManager;

    private void Start()
    {
        PrepareForThrow();
    }

    public void Strike() //WHEN ALL PINS ARE DOWN, NO MATTER THE THROW NUMBER
    {
        numberOfThrows = 0;
        PrepareForThrow();
    }

    public void PrepareForThrow() //ONE METHOD TO SPAWN BALLS
    {
        if (numberOfThrows == 2) //IF THROWN THE BALL TWICE, SAVE THE SCORE
        {
            numberOfThrows = 0;
            scoreManager.FinishFrame();
        }


        if (numberOfThrows < 2 && scoreManager.currentFrame < 10) //CREATING THE BALL
        {
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
            numberOfThrows++;


        }
    }
}
