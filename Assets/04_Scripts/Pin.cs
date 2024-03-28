using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    
    public bool isFallen;
    public Rigidbody rigibody;
    Vector3 originalPosition;
    Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetToStartPosition()
    {
        rigibody.velocity = Vector3.zero;
        rigibody.angularVelocity = Vector3.zero;

        //set active true
        gameObject.SetActive(true);
        //move it to original position
        transform.position = originalPosition;
        //move it to original rotation
        transform.rotation = originalRotation;

    }
    public bool IsPinFallen()
    {
        isFallen = false;

        if (transform.rotation.z > 0.1f || transform.rotation.z < -0.1f
            || transform.rotation.x > 0.1f || transform.rotation.x < -0.1f)
        {
            isFallen = true;
        }

        return isFallen;
    }
}
