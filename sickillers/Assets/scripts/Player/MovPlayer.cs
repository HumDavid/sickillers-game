using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    CharacterController controller;

    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    float speed = 8f;

    float gravity;
    float jumpSpeed;
    float maxJumpHeight = 2.2f;
    float timeToMaxHeight = 0.4f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;

    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float strafeInput = Input.GetAxis("Horizontal");

        //force = input * speed * direction
        forward = forwardInput * speed * transform.forward;
        strafe = strafeInput * speed * transform.right;

        vertical += gravity * Time.deltaTime * Vector3.up;

        if (controller.isGrounded)
        {
            vertical = Vector3.down;
        }
        
        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            vertical = jumpSpeed * Vector3.up;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            while (speed < 12f)
            {
                speed += 1f * Time.deltaTime;
            }
        }
        else {             
            while (speed > 8f)
            {
                speed -= 1f * Time.deltaTime;
            }
        }

        Debug.Log(speed);

        Vector3 finalVelocity = forward + strafe + vertical;

        controller.Move(finalVelocity * Time.deltaTime);
    }
}
