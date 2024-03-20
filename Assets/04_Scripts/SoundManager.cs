using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource ballRollingSound;

    public void PlayBallThrowSound()
    {
        ballRollingSound.Play();
    }
}
