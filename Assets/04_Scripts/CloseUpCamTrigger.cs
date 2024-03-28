using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUpCamTrigger : MonoBehaviour
{
    public GameObject closeUpCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("BALL ENTERED SCRIPT");
            //Set camera active
            closeUpCamera.SetActive(true);
            Invoke(nameof(HideCloseUpCamera), 2.5f);
        }
    }

    public void HideCloseUpCamera()
    {
        Debug.Log("Camera being hidden");
        closeUpCamera.SetActive(false);
    }

}
