using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public UIFrame[] frames;

    public GameObject uiResults;
    public TextMeshProUGUI finalResultText;

    public GameObject spareImage;
    public GameObject strikeImage;

    // Start is called before the first frame update
    void Start()
    {
        for(int index = 0; index < frames.Length; index++)
        {
            frames[index].SetFrameNumber(index + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowStrikeImage()
    {
        strikeImage.SetActive(true);
        Invoke("HideImages", 2f);
    }

    public void ShowSpareImage()
    {
        spareImage.SetActive(true);
        Invoke("HideImages", 2f);
    }
    public void HideImages()
    {
        spareImage.SetActive(false);
        strikeImage.SetActive(false);
    }
    public void UpdatePreviousFrame(int totalScore, int currentFrame)
    {
        if(currentFrame - 1 >= 0)
        {
            frames[currentFrame - 1].SetTotalScoreText(totalScore);
        }
        
    }
    public void SetTotalScoreOnCurrentFrame(int totalScore, int currentFrame)
    {
        Debug.Log("CURRENT FRAME: " + currentFrame);
        frames[currentFrame].SetTotalScoreText(totalScore);
    }

    public void SetScoreOnCurrentFrame(int amountOfPins, int currentThrowNumber, int currentFrame)
    {
        frames[currentFrame].SetFrameScore(amountOfPins, currentThrowNumber);
    }

    public void FinishGame(int totalScore)
    {
        //SHOW THE UI RESULTS SCREEN
        uiResults.SetActive(true);
        //SET THE TOTAL SCORE TEXT TO SHOW THE TOTAL SCORE VALUE
        finalResultText.text = "FINAL SCORE: " + totalScore.ToString();
    }
}
