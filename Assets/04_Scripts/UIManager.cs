using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public UIFrame[] frames;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScoreOnCurrentFrame(int amountOfPins, int currentThrowNumber, int currentFrame)
    {
        frames[currentFrame].SetFrameScore(amountOfPins, currentThrowNumber);
    }
}
