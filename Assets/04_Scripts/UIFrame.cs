using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIFrame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _firstPoint;
    [SerializeField] private TextMeshProUGUI _secondPoint;
    [SerializeField] private TextMeshProUGUI _totalScore;
    int firstThrowCache;
    int secondThrowCache;
    private void Start()
    {
        _firstPoint.enabled = false;
        _secondPoint.enabled = false;
        _totalScore.enabled = false;

    }

    public void SetScore(int pins, int throwCount)
    {
        if(throwCount == 1)
        {
            firstThrowCache = pins;
            if(pins == 10)
            {
                _secondPoint.enabled = true;
                _secondPoint.text = "X";
            }
            else
            {
                _firstPoint.enabled = true;
                _firstPoint.text = pins.ToString();
            }
        }
        else if(throwCount == 2)
        {
            secondThrowCache = pins;
            _secondPoint.enabled = true;
            if (firstThrowCache + secondThrowCache == 10)
            {
                //SPARE
                _secondPoint.text = "/";
            }
            else
            {
                _secondPoint.text = pins.ToString();
            }

        }
    }

    public void ConcludeFrameUI(int totalScore)
    {
        _totalScore.enabled = true;
        _totalScore.text = totalScore.ToString();
    }
}
