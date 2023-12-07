using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController controller;
    Vector3 forward, strafe, vertical;

    public float forwardSpeed;
    public float strafeSpeed;

    public float verticalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        forward = forwardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;

        if(Input.GetKey(KeyCode.Space))
        {
            vertical = verticalSpeed * Vector3.up;
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            vertical = new Vector3(0,0,0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            vertical = -verticalSpeed * Vector3.up;
        }

        Vector3 finalVelocity = forward + strafe + vertical;

        controller.Move(finalVelocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            forwardSpeed = forwardSpeed * 2;
            strafeSpeed = strafeSpeed * 2;
            verticalSpeed = verticalSpeed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            forwardSpeed = forwardSpeed / 2;
            strafeSpeed = strafeSpeed / 2;
            verticalSpeed = verticalSpeed / 2;
        }
    }
}
