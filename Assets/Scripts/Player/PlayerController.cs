using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D CharacterController2D;
    public PlayerHide PlayerHide;

    public float runSpeed = 40f;
    float horizontalMovement = 0f;

    bool jump = false;
    bool stoppedJump = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
	    horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

	    if (Input.GetButtonDown("Jump"))
	    {
		    CharacterController2D.StartJump();
	    }

	    if (Input.GetButtonUp("Jump"))
	    {
		    CharacterController2D.StopJump();
	    }

	    if (Input.GetButton("Crouch"))
	    {
			// CharacterController2D.
	    }
    }

    private void FixedUpdate()
    {
	    CharacterController2D.Move(horizontalMovement * Time.fixedDeltaTime, false);
    }
}
