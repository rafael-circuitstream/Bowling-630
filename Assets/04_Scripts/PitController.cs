using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitController : MonoBehaviour
{
    public void ResetAllPins() //PLACE THEM IN ORIGINAL POSITION
    {
        foreach (Pin pin in pins)
        {
            pin.ResetToStartPosition();
        }
    }

    public Pin[] pins;
    GameManager manager;
    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }


    private void OnTriggerEnter(Collider other) //WHEN BALL HITS THE PIT
    {
        if(other.gameObject.CompareTag("Ball"))
        {

            //WE WANT TO START ANOTHER THROW
            Destroy(other.gameObject);
            Invoke("CheckPins", 1.5f); //DELAY TO CHECK FOR FALLEN PINS

        }    
    }

    public void CheckPins()
    {
        int amountOfPins = 0;
        int hitsInCurrentThrow = 0;

        foreach(Pin selectedPin in pins)
        {
            if (selectedPin.IsPinFallen()) //IF THEY ARE FALLEN, HIDE THEM AND ADD 1 TO AMOUNT
            {
                if (selectedPin.gameObject.activeInHierarchy) hitsInCurrentThrow++;

                amountOfPins += 1;

                selectedPin.gameObject.SetActive(false);
            }
        }

        //AMOUNT OF PINS IS STORING THE AMOUNT THAT ARE ON THE FLOOR

        scoreManager.SetFrameScore(amountOfPins);

        FindObjectOfType<UIManager>().ThrowHappened(scoreManager.currentFrame, hitsInCurrentThrow, manager.numberOfThrows);
        if (amountOfPins == 10) //IF ALL OF THEM ARE FALLEN
        {
            scoreManager.FinishFrame(); //FINISH THE FRAME
            manager.Strike(); //AND ALSO TELL THE GAME MANAGER THAT WE WANT ANOTHER BALL
            //AND RESET THE AMOUNT OF THROWNS
        }
        else
        {
            manager.PrepareForThrow(); //IF NOT I'LL GO FOR NEXT THROW
        }

        Debug.Log(amountOfPins);
    }


}
