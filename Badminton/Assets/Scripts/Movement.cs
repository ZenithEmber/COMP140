using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller; //Variable to initialise the controller we use for the movement.

    public float speed = 12f; //float for the speed at which the controller moves
    public float gravity = -9.81f;
    public float jumpHeight = 5f;
    private bool sprinting = false;

    public float CastDist = 1f; //float value that dictates the distance of the raycast

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        /*
         *inistialize the X and Z axis movement to keep track of which way we move. 
         * Can populate the values with the charactercontroller functions of input.GetAxis and the according direction axis
         */

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Calculate the movement multiply the transform so the movement is always in according to the way the character is looking, rather than the actual position in Unity
        Vector3 move = transform.right * x + transform.forward * z;

        //Move the character in the direction calculated above and adding the speed of movement and making it relative to the Time so the framerate does not influence it
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && Physics.Raycast(transform.position, Vector3.down, CastDist))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprinting = true;
            if (sprinting == true)
            {
                speed = 12f;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprinting = false;
            if (sprinting = false)
            {
                speed = 8f;
            }
        }
    }
}