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
    float maxJumpHeight = 3f;
    float timeToMaxHeight = 0.4f;

    public float forwardInput;
    public float strafeInput;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;

    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxisRaw("Vertical");
        strafeInput = Input.GetAxisRaw("Horizontal");

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

        if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            vertical = Vector3.zero;
        }

        float targetSpeed = Input.GetKey(KeyCode.LeftShift) ? 12f : 8f;
        speed = Mathf.MoveTowards(speed, targetSpeed, 20f * Time.deltaTime);

        Vector3 finalVelocity = forward + strafe + vertical;

        controller.Move(finalVelocity * Time.deltaTime);
    }
}
