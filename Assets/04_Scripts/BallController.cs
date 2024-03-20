using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public AudioSource ballRollingSound;

    public GameObject _arrow;
    public Rigidbody _rigidbody;
    public float _speed;
    public float _pushForce;
    public float _maxDistance;

    bool _itWasThrown;

    void Start()
    {
    }

    public void PlayBallThrowSound()
    {
        ballRollingSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(_itWasThrown)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(_arrow.transform.up * _pushForce, ForceMode.Impulse);
            _itWasThrown = true;
            //play sound
            PlayBallThrowSound();
            _arrow.SetActive(false);
        }

        float direction = Input.GetAxisRaw("Horizontal");
        if (direction != 0)
        {
            Vector3 currentPosition = transform.position;

            if (currentPosition.x >= _maxDistance && direction > 0)
            {
                return;
            }

            if (currentPosition.x <= -_maxDistance && direction < 0)
            {
                return;
            }

            currentPosition.x += direction * Time.deltaTime * _speed;

            _rigidbody.MovePosition(currentPosition);
            //MOVING BALL HERE
        }

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Some collision happened " + collision.gameObject.name);
    }
}
