using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject _arrow;
    public Rigidbody _rigidbody;
    public float _speed;
    public float _pushForce;
    public float _maxDistance;

    bool _itWasThrown;

    // Start is called before the first frame update
    void Start()
    {
        
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
