using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static float speed;
    public Transform playerT;
    bool passed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        //check if the platform is still on the Screen.
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPosition.y > 1.2)
        {
            //Destroy the platform.
            Destroy(gameObject);            
        }
        if(!passed && playerT.position.y < transform.position.y)
        {
            passed = true;
            ScoreManager.currentScore++;
        }
    }

    
}
