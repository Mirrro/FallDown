using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public SkinnedMeshRenderer skndMRenderer;

    public float inputHorz;
    public float accerlerationSpeed;
    public float maxSpeed = 1000;

    public bool bounced = false;
    public Animator aniCPlayer;
    public Animator aniCCamera;


    // Assign variables.
    void Start()
    {
        ScoreManager.currentScore = 0;
        skndMRenderer = GetComponent<SkinnedMeshRenderer>();
        aniCPlayer = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check if player is still alive
        isOnScreen();

        //Player move left and right.
        inputHorz = Input.GetAxis("Horizontal");
        if (inputHorz != 0)
        {
            rb.AddForce(new Vector3(inputHorz * accerlerationSpeed, 0, 0), ForceMode.Impulse);
        }
        //had some issues with the deacceleration of the Rigidbody. Tryed to use the Drag value but apparently this affects the Gravity as well.
        //worked around this issue by simply adding the opposit force of the current velocity.
        else
        {
            rb.AddForce(new Vector3(-rb.velocity.x / 10, 0, 0), ForceMode.Impulse);
        }

        //stretch, squash, rotate towards movement and a camera shake.
        if(rb.velocity.normalized != Vector3.zero)
        {
            gameObject.transform.rotation = Quaternion.LookRotation(rb.velocity.normalized, Vector3.up);
            skndMRenderer.SetBlendShapeWeight(0, (Mathf.Abs(rb.velocity.magnitude) / maxSpeed) * 100);
        }
        //squash the player if he stopped moving along the y axis and hasn't squashed yet.
        if (!bounced && rb.velocity.y >= 0)
        {
            bounced = true;
            aniCCamera.SetTrigger("shake");
            aniCPlayer.SetTrigger("squash");

        }
        //as soon as the player is moving on the y axis again, he is able to squash again
        else if (bounced && rb.velocity.y < -2)
        {
            bounced = false;
        }

        //clamp the speed of the rigidbody on x-axis.
        if (Mathf.Abs(rb.velocity.x) >= maxSpeed )
        {
            rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y, 0);
        }    
    }

    public void isOnScreen()
    {
        //check if players position is either below or above the screen.
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPosition.y > 1 || screenPosition.y < 0)
        {
            //load EndScene.
            SceneManager.LoadScene("EndScene");
        }
    }
}
