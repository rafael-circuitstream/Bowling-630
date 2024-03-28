using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIFrame : MonoBehaviour
{
    public TextMeshProUGUI firstThrowText;
    public TextMeshProUGUI secondThrowText;
    public TextMeshProUGUI thirdThrowLastFrame; //WARNING!!!

    public TextMeshProUGUI totalScoreText;
    public TextMeshProUGUI frameTitleText;

    public bool strike;
    public bool spare;

    int firstThrowMemory;
    int secondThrowMemory;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetLastFrameScore()
    {

    }
    public void SetFrameNumber(int number)
    {
        frameTitleText.text = number.ToString();
    }

    public void UpdateIncreasedScore(int totalScore)
    {

    }
    public void SetTotalScoreText(int totalScore)
    {

        totalScoreText.text = totalScore.ToString();
    }

    public void SetFrameScore(int amountOfPins, int currentThrowNumber)
    {
        if(currentThrowNumber == 1)
        {
            firstThrowMemory = amountOfPins;
            if(amountOfPins == 10) //if I have a strike on the first throw
            {
                //SET SECOND TEXT TO BE A 'X'
                
                secondThrowText.text = "X";
                strike = true;
            }
            else
            {
                //CHANGE TEXT ON THE LEFT
                firstThrowText.text = amountOfPins.ToString();
            }


        }
        else if(currentThrowNumber == 2)
        {
            secondThrowMemory = amountOfPins - firstThrowMemory;

            if(firstThrowMemory + secondThrowMemory == 10) //if I have a 'spare' //IF FIRST THROW + SECOND THROW == 10
            {
                //SET SECOND TEXT TO BE A '/'
                secondThrowText.text = "/";
                spare = true;
            }
            else
            {
                //CHANGE TEXT ON THE RIGHT
                secondThrowText.text = secondThrowMemory.ToString();
            }

        }
    }
}
