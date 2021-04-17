using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D CharacterController2D;
    public float runSpeed = 40f;
    float horizontalMovement = 0f;
    bool jump = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
	    horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

	    if (Input.GetButtonDown("Jump"))
	    {
		    Debug.Log("IsJumping");
		    jump = true;
	    }
    }

    private void FixedUpdate()
    {
	    CharacterController2D.Move(horizontalMovement * Time.fixedDeltaTime, false, jump);
	    jump = false;
    }
}
