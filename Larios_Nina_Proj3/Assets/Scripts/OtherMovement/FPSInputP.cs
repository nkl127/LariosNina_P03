using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FPSInputP : MonoBehaviour {

    public event Action<Vector3> MoveInput = delegate { };
    public event Action JumpInput = delegate { };

    public ParticleSystem dust;

    private void Update()
    {
        DetectMoveInput();
        DetectJumpInput();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            dust.Play();
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            dust.Stop();
        }
    }

    void DetectMoveInput()
    {
        //   float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        if (yInput != 0)
        {
            //   Vector3 horizontalMovement = transform.right * xInput;
            Vector3 forwardMovement = transform.forward * yInput;
            Vector3 movement = (forwardMovement).normalized;
            MoveInput.Invoke(movement);
        }
    }
    void DetectJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpInput.Invoke();
        }
    }
}
