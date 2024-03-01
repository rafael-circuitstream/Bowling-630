using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {

        // ! @ $ # & % + - PROHIBITED
        // NO SPACE
        
    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            Debug.Log("HELLO");
            timer = 0;
        }

        float direction = 0;
        
        if(direction > 0)
        {
            Vector3 newPosition = new Vector3(0.1f, 0, 0);
            transform.position += newPosition * Time.deltaTime;
        }

        if(direction < 0)
        {
            Vector3 newPosition = new Vector3(-0.1f, 0, 0);
            transform.position += newPosition * Time.deltaTime;
        }

        transform.Rotate(new Vector3(0, 3, 0));
        
    }
}
